using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Security.Cryptography;
using System.Diagnostics;


namespace Nemone
{
    public partial class MainHubForm : Form
    {

        public MainHubForm()
        {
            InitializeComponent();
            NemoDB.InitDatabase();
        }

        private void OtherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            MainHubForm_Load(null, null);
        }

        private void btnNewMake_Click(object sender, EventArgs e)
        {
            EditorForm makeForm = new EditorForm();
            makeForm.FormClosed += OtherForm_FormClosed;
            makeForm.Show();
            this.Hide();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Nemo Files (*.nemo)|*.nemo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayForm playForm = new PlayForm(ofd.FileName);
                playForm.FormClosed += OtherForm_FormClosed;
                playForm.Show();
                this.Hide();
            }
            ofd.FileName = "";
        }

        private void MainHubForm_Load(object sender, EventArgs e)
        {
            var playStatuses = NemoDB.LoadPlayStatus();

            flowLayoutPanel.Controls.Clear();

            foreach (var status in playStatuses)
            {
                var btn = new Button();
                btn.Text = $"{status.Title} {(status.IsCompleted ? "\r\n\r\n완성" : "")}";
                btn.Tag = status;
                btn.BackColor = Color.White;
                btn.Width = 80;
                btn.Height = 80;

                btn.Click += PlayStatusBtn_Click;

                flowLayoutPanel.Controls.Add(btn);
            }
        }

        private void PlayStatusBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            var playStatus = btn.Tag as PlayStatus;
            if (playStatus == null) return;

            PlayForm playForm = new PlayForm(playStatus);
            playForm.FormClosed += OtherForm_FormClosed;
            playForm.Show();
            this.Hide();
        }

        private async void btnExportPdf_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Nemo Files (*.nemo)|*.nemo";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PlayForm playForm = new PlayForm(ofd.FileName, true);
                // 완전 투명하게 만들고 보이게 하기
                playForm.Opacity = 0;
                playForm.Show();

                // 강제로 레이아웃 다시 계산 및 렌더링 대기
                playForm.PerformLayout();
                playForm.Refresh();
                await Task.Delay(100);  // 0.1초 대기 (렌더링 안정화용)


                sfd.Filter = "PDF 파일 (*.pdf)|*.pdf";
                sfd.FileName = $"{Path.GetFileNameWithoutExtension(ofd.FileName)}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // ProgressForm을 비모달로 띄움
                    ProgressForm progress = new ProgressForm();
                    progress.StartPosition = FormStartPosition.CenterParent;
                    progress.Show();

                    // 백그라운드 작업
                    await Task.Run(() =>
                    {
                        SavePlayFormAsPdf(playForm, sfd.FileName);

                        // UI 스레드로 돌아와서 progress 닫기
                        Invoke((MethodInvoker)(() =>
                        {
                            progress.Close();
                            progress.Dispose();
                        }));

                        MessageBox.Show("PDF 내보내기 완료");
                    });
                }

                // PDF 저장 후 폼 닫기
                playForm.Close();
            }
        }

        private void SavePlayFormAsPdf(PlayForm playForm, string filePath)
        {
            using (Bitmap bmp = playForm.CaptureTableLayoutPanel())
            {
                if (bmp == null)
                {
                    MessageBox.Show("캡처할 컨트롤이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.AddPage();

                    // A4 용지 크기로 설정 (포인트 단위)
                    page.Width = XUnit.FromMillimeter(210);
                    page.Height = XUnit.FromMillimeter(297);

                    // 패딩 값 (포인트 단위)
                    double padding = 20;

                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            ms.Position = 0;

                            using (XImage image = XImage.FromStream(ms))
                            {
                                double maxWidth = page.Width.Point - 2 * padding;
                                double maxHeight = page.Height.Point - 2 * padding;

                                double imgWidth = image.PixelWidth * 72.0 / image.HorizontalResolution;
                                double imgHeight = image.PixelHeight * 72.0 / image.VerticalResolution;

                                double ratioX = maxWidth / imgWidth;
                                double ratioY = maxHeight / imgHeight;
                                double ratio = Math.Min(ratioX, ratioY);

                                double drawWidth = imgWidth * ratio;
                                double drawHeight = imgHeight * ratio;

                                // 패딩을 고려해서 중앙 정렬
                                double posX = padding + (maxWidth - drawWidth) / 2;
                                double posY = padding + (maxHeight - drawHeight) / 2;

                                gfx.DrawImage(image, posX, posY, drawWidth, drawHeight);
                            }
                        }
                    }

                    document.Save(filePath);
                }
            }
        }
    }
}
