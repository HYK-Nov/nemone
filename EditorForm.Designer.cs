namespace Nemone
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rd35 = new System.Windows.Forms.RadioButton();
            this.rd30 = new System.Windows.Forms.RadioButton();
            this.rd25 = new System.Windows.Forms.RadioButton();
            this.rd20 = new System.Windows.Forms.RadioButton();
            this.rd15 = new System.Windows.Forms.RadioButton();
            this.rd10 = new System.Windows.Forms.RadioButton();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rd35);
            this.groupBox.Controls.Add(this.rd30);
            this.groupBox.Controls.Add(this.rd25);
            this.groupBox.Controls.Add(this.rd20);
            this.groupBox.Controls.Add(this.rd15);
            this.groupBox.Controls.Add(this.rd10);
            this.groupBox.Location = new System.Drawing.Point(29, 61);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(189, 338);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // rd35
            // 
            this.rd35.AutoSize = true;
            this.rd35.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd35.Location = new System.Drawing.Point(48, 282);
            this.rd35.Name = "rd35";
            this.rd35.Size = new System.Drawing.Size(92, 28);
            this.rd35.TabIndex = 5;
            this.rd35.TabStop = true;
            this.rd35.Text = "35x35";
            this.rd35.UseVisualStyleBackColor = true;
            this.rd35.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // rd30
            // 
            this.rd30.AutoSize = true;
            this.rd30.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd30.Location = new System.Drawing.Point(48, 233);
            this.rd30.Name = "rd30";
            this.rd30.Size = new System.Drawing.Size(92, 28);
            this.rd30.TabIndex = 4;
            this.rd30.TabStop = true;
            this.rd30.Text = "30x30";
            this.rd30.UseVisualStyleBackColor = true;
            this.rd30.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // rd25
            // 
            this.rd25.AutoSize = true;
            this.rd25.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd25.Location = new System.Drawing.Point(48, 184);
            this.rd25.Name = "rd25";
            this.rd25.Size = new System.Drawing.Size(92, 28);
            this.rd25.TabIndex = 3;
            this.rd25.TabStop = true;
            this.rd25.Text = "25x25";
            this.rd25.UseVisualStyleBackColor = true;
            this.rd25.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // rd20
            // 
            this.rd20.AutoSize = true;
            this.rd20.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd20.Location = new System.Drawing.Point(48, 135);
            this.rd20.Name = "rd20";
            this.rd20.Size = new System.Drawing.Size(92, 28);
            this.rd20.TabIndex = 2;
            this.rd20.TabStop = true;
            this.rd20.Text = "20x20";
            this.rd20.UseVisualStyleBackColor = true;
            this.rd20.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // rd15
            // 
            this.rd15.AutoSize = true;
            this.rd15.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd15.Location = new System.Drawing.Point(48, 86);
            this.rd15.Name = "rd15";
            this.rd15.Size = new System.Drawing.Size(86, 28);
            this.rd15.TabIndex = 1;
            this.rd15.TabStop = true;
            this.rd15.Text = "15x15";
            this.rd15.UseVisualStyleBackColor = true;
            this.rd15.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // rd10
            // 
            this.rd10.AutoSize = true;
            this.rd10.Checked = true;
            this.rd10.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd10.Location = new System.Drawing.Point(48, 37);
            this.rd10.Name = "rd10";
            this.rd10.Size = new System.Drawing.Size(86, 28);
            this.rd10.TabIndex = 0;
            this.rd10.TabStop = true;
            this.rd10.Text = "10x10";
            this.rd10.UseVisualStyleBackColor = true;
            this.rd10.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // tableLayout
            // 
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayout.Controls.Add(this.panel2, 1, 0);
            this.tableLayout.Controls.Add(this.panel1, 0, 0);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(1262, 753);
            this.tableLayout.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.groupBox);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.btnConvert);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1012, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 747);
            this.panel2.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(29, 652);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 57);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = true;
            this.btnLoad.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoad.Location = new System.Drawing.Point(29, 582);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(189, 57);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.AutoSize = true;
            this.btnConvert.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConvert.Location = new System.Drawing.Point(29, 516);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(189, 57);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "이미지 변환";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 747);
            this.panel1.TabIndex = 6;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.tableLayout);
            this.Font = new System.Drawing.Font("Pretendard Variable", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "네모 만들기";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.tableLayout.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton rd30;
        private System.Windows.Forms.RadioButton rd25;
        private System.Windows.Forms.RadioButton rd20;
        private System.Windows.Forms.RadioButton rd15;
        private System.Windows.Forms.RadioButton rd10;
        private System.Windows.Forms.RadioButton rd35;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}