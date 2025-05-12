namespace Nemone
{
    partial class MakeForm
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rd30 = new System.Windows.Forms.RadioButton();
            this.rd25 = new System.Windows.Forms.RadioButton();
            this.rd20 = new System.Windows.Forms.RadioButton();
            this.rd15 = new System.Windows.Forms.RadioButton();
            this.rd10 = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.container = new System.Windows.Forms.SplitContainer();
            this.rd35 = new System.Windows.Forms.RadioButton();
            this.rd40 = new System.Windows.Forms.RadioButton();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.AutoSize = true;
            this.btnConvert.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConvert.Location = new System.Drawing.Point(33, 515);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(242, 57);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "이미지 변환";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rd40);
            this.groupBox.Controls.Add(this.rd35);
            this.groupBox.Controls.Add(this.rd30);
            this.groupBox.Controls.Add(this.rd25);
            this.groupBox.Controls.Add(this.rd20);
            this.groupBox.Controls.Add(this.rd15);
            this.groupBox.Controls.Add(this.rd10);
            this.groupBox.Location = new System.Drawing.Point(33, 29);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(242, 425);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // rd30
            // 
            this.rd30.AutoSize = true;
            this.rd30.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd30.Location = new System.Drawing.Point(29, 245);
            this.rd30.Name = "rd30";
            this.rd30.Size = new System.Drawing.Size(92, 28);
            this.rd30.TabIndex = 4;
            this.rd30.TabStop = true;
            this.rd30.Text = "30x30";
            this.rd30.UseVisualStyleBackColor = true;
            this.rd30.CheckedChanged += new System.EventHandler(this.rd30_CheckedChanged);
            // 
            // rd25
            // 
            this.rd25.AutoSize = true;
            this.rd25.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd25.Location = new System.Drawing.Point(29, 193);
            this.rd25.Name = "rd25";
            this.rd25.Size = new System.Drawing.Size(92, 28);
            this.rd25.TabIndex = 3;
            this.rd25.TabStop = true;
            this.rd25.Text = "25x25";
            this.rd25.UseVisualStyleBackColor = true;
            this.rd25.CheckedChanged += new System.EventHandler(this.rd25_CheckedChanged);
            // 
            // rd20
            // 
            this.rd20.AutoSize = true;
            this.rd20.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd20.Location = new System.Drawing.Point(29, 141);
            this.rd20.Name = "rd20";
            this.rd20.Size = new System.Drawing.Size(92, 28);
            this.rd20.TabIndex = 2;
            this.rd20.TabStop = true;
            this.rd20.Text = "20x20";
            this.rd20.UseVisualStyleBackColor = true;
            this.rd20.CheckedChanged += new System.EventHandler(this.rd20_CheckedChanged);
            // 
            // rd15
            // 
            this.rd15.AutoSize = true;
            this.rd15.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd15.Location = new System.Drawing.Point(29, 89);
            this.rd15.Name = "rd15";
            this.rd15.Size = new System.Drawing.Size(86, 28);
            this.rd15.TabIndex = 1;
            this.rd15.TabStop = true;
            this.rd15.Text = "15x15";
            this.rd15.UseVisualStyleBackColor = true;
            this.rd15.CheckedChanged += new System.EventHandler(this.rd15_CheckedChanged);
            // 
            // rd10
            // 
            this.rd10.AutoSize = true;
            this.rd10.Checked = true;
            this.rd10.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd10.Location = new System.Drawing.Point(29, 37);
            this.rd10.Name = "rd10";
            this.rd10.Size = new System.Drawing.Size(86, 28);
            this.rd10.TabIndex = 0;
            this.rd10.TabStop = true;
            this.rd10.Text = "10x10";
            this.rd10.UseVisualStyleBackColor = true;
            this.rd10.CheckedChanged += new System.EventHandler(this.rd10_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.AutoSize = true;
            this.btnLoad.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoad.Location = new System.Drawing.Point(33, 581);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(242, 57);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(33, 651);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(242, 57);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.Transparent;
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.btnSave);
            this.container.Panel2.Controls.Add(this.btnLoad);
            this.container.Panel2.Controls.Add(this.btnConvert);
            this.container.Panel2.Controls.Add(this.groupBox);
            this.container.Size = new System.Drawing.Size(1262, 753);
            this.container.SplitterDistance = 950;
            this.container.TabIndex = 4;
            // 
            // rd35
            // 
            this.rd35.AutoSize = true;
            this.rd35.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd35.Location = new System.Drawing.Point(29, 297);
            this.rd35.Name = "rd35";
            this.rd35.Size = new System.Drawing.Size(92, 28);
            this.rd35.TabIndex = 5;
            this.rd35.TabStop = true;
            this.rd35.Text = "35x35";
            this.rd35.UseVisualStyleBackColor = true;
            this.rd35.CheckedChanged += new System.EventHandler(this.rd35_CheckedChanged);
            // 
            // rd40
            // 
            this.rd40.AutoSize = true;
            this.rd40.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd40.Location = new System.Drawing.Point(29, 349);
            this.rd40.Name = "rd40";
            this.rd40.Size = new System.Drawing.Size(92, 28);
            this.rd40.TabIndex = 6;
            this.rd40.TabStop = true;
            this.rd40.Text = "40x40";
            this.rd40.UseVisualStyleBackColor = true;
            this.rd40.CheckedChanged += new System.EventHandler(this.rd40_CheckedChanged);
            // 
            // MakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.container);
            this.Font = new System.Drawing.Font("Pretendard Variable", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "MakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "nemone";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.container.Panel2.ResumeLayout(false);
            this.container.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton rd30;
        private System.Windows.Forms.RadioButton rd25;
        private System.Windows.Forms.RadioButton rd20;
        private System.Windows.Forms.RadioButton rd15;
        private System.Windows.Forms.RadioButton rd10;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.RadioButton rd35;
        private System.Windows.Forms.RadioButton rd40;
    }
}