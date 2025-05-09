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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd30 = new System.Windows.Forms.RadioButton();
            this.rd25 = new System.Windows.Forms.RadioButton();
            this.rd20 = new System.Windows.Forms.RadioButton();
            this.rd15 = new System.Windows.Forms.RadioButton();
            this.rd10 = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1012, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 753);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd30);
            this.groupBox1.Controls.Add(this.rd25);
            this.groupBox1.Controls.Add(this.rd20);
            this.groupBox1.Controls.Add(this.rd15);
            this.groupBox1.Controls.Add(this.rd10);
            this.groupBox1.Location = new System.Drawing.Point(10, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 281);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rd30
            // 
            this.rd30.AutoSize = true;
            this.rd30.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rd30.Location = new System.Drawing.Point(29, 225);
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
            this.rd25.Location = new System.Drawing.Point(29, 178);
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
            this.rd20.Location = new System.Drawing.Point(29, 131);
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
            this.rd15.Location = new System.Drawing.Point(29, 84);
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
            this.btnLoad.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoad.Location = new System.Drawing.Point(18, 586);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(220, 59);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(18, 663);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(220, 59);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnGrid
            // 
            this.pnGrid.Location = new System.Drawing.Point(0, 0);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1016, 758);
            this.pnGrid.TabIndex = 3;
            // 
            // MakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnGrid);
            this.Font = new System.Drawing.Font("Pretendard Variable", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MakeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MakeForm";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Panel pnGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd30;
        private System.Windows.Forms.RadioButton rd25;
        private System.Windows.Forms.RadioButton rd20;
        private System.Windows.Forms.RadioButton rd15;
        private System.Windows.Forms.RadioButton rd10;
    }
}