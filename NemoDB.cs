using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nemone
{
    public static class NemoDB
    {
        private const string Dbpath = "puzzle.db";

        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection($"Data Source={Dbpath};Verseion=3");
            conn.Open();
            return conn;
        }

        // 초기 DB 설정
        public static void InitDatabase()
        {
            var conn = GetConnection();
            var cmd = new SQLiteCommand(@"
                CREATE TABLE IF NOT EXISTS puzzles (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    title TEXT NOT NULL,
                    grid_size INTEGER NOT NULL,
                    grid_state TEXT NOT NULL,
                    created_at TEXT NOT NULL DEFAULT (DATETIME('now', 'localtime'))
                );
                CREATE TABLE IF NOT EXISTS play_status (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    puzzle_id INTEGER NOT NULL,
                    title TEXT NOT NULL,
                    last_played_at TEXT NULL,
                    is_completed INTEGER NOT NULL DEFAULT 0,
                    process TEXT NOT NULL,
                    FOREIGN KEY(puzzle_id) REFERENCES puzzles(id) ON DELETE CASCADE
                );", conn);
            cmd.ExecuteNonQuery();  // 결과값X
        }

        // 퍼즐 DB 저장
        public static int EnsurePuzzleInDb(string title, int gridSize, int[][] gridState)
        {
            string now = DateTime.Now.ToString("s");

            using (SQLiteConnection conn = GetConnection())
            {
                //  이미 존재하는 퍼즐이면 id 반환
                using (SQLiteCommand check = new SQLiteCommand($"SELECT id FROM puzzles WHERE title='{title}'", conn))
                {
                    var result = check.ExecuteScalar(); // 결과 반환
                    if (result != null) return Convert.ToInt32(result);
                }

                string gridStateJson = JsonConvert.SerializeObject(gridState);

                SQLiteCommand insert = new SQLiteCommand($@"
                    INSERT INTO puzzles (title, grid_size, grid_state, created_at)
                    VALUES ('{title}', {gridSize}, '{gridStateJson}', '{DateTime.Now.ToString("o")}');
                ", conn);
                insert.ExecuteNonQuery();

                return (int)conn.LastInsertRowId;
            }
        }

        // 퍼즐 내역 저장
        public static void SavePlayStatus(int puzzleId, string title, int[,] gridState, bool isCompleted)
        {
            string now = DateTime.Now.ToString("s");
            string process = JsonConvert.SerializeObject(gridState);

            using (SQLiteConnection conn = GetConnection())
            {
                //  이미 존재하는 퍼즐이면 id 반환
                using (SQLiteCommand check = new SQLiteCommand($"SELECT id FROM play_status WHERE puzzle_id={puzzleId}", conn))
                {
                    var result = check.ExecuteScalar(); // 결과 반환
                    if (result != null)
                    {
                        SQLiteCommand update = new SQLiteCommand($@"
                            UPDATE play_status SET 
                            last_played_at='{now}', is_completed={(isCompleted ? 1 : 0)}, process='{process}'
                            WHERE id={Convert.ToInt32(result)}
                        ", conn);
                        update.ExecuteNonQuery();
                    }
                    else
                    {
                        SQLiteCommand insert = new SQLiteCommand($@"
                            INSERT INTO play_status (puzzle_id, title, last_played_at, process)
                            VALUES ({puzzleId}, '{title}', '{now}', '{process}');
                        ", conn);
                        insert.ExecuteNonQuery();
                    }
                }
            }
        }

        // 전체 퍼즐 내역 불러오기
        public static List<PlayStatus> LoadPlayStatus()
        {
            var result = new List<PlayStatus>();

            using (var conn = GetConnection())
            {
                using (var cmd = new SQLiteCommand("SELECT * FROM play_status", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new PlayStatus
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            PuzzleId = reader.GetInt32(reader.GetOrdinal("puzzle_id")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            Process = JsonConvert.DeserializeObject<int[,]>(reader.GetString(reader.GetOrdinal("process"))),
                            IsCompleted = reader.GetInt32(reader.GetOrdinal("is_completed")) == 1 ? true : false 
                        });
                    }
                }
            }

            return result;
        }

        // 특정 퍼즐 내역 불러오기
        public static PlayStatus LoadPlayStatusByPuzzleId(int puzzleId)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM play_status WHERE puzzle_id={puzzleId};", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PlayStatus
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                PuzzleId = reader.GetInt32(reader.GetOrdinal("puzzle_id")),
                                Title = reader.GetString(reader.GetOrdinal("title")),
                                Process = JsonConvert.DeserializeObject<int[,]>(reader.GetString(reader.GetOrdinal("process"))),
                                IsCompleted = reader.GetInt32(reader.GetOrdinal("is_completed")) == 1 ? true : false
                            };
                        }
                    }
                }
            }

            return null;
        }

        // 특정 퍼즐 정답 불러오기
        public static int[,] GetPuzzleSolutionById(int id)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT grid_size, grid_state FROM puzzles WHERE id={id};", conn))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int gridSize = reader.GetInt32(reader.GetOrdinal("grid_size"));
                            int[,] gridState = JsonConvert.DeserializeObject<int[,]>(reader.GetString(reader.GetOrdinal("grid_state")));

                            return gridState;
                        }
                    }
                }
            }

            return null;
        }
    }
}
