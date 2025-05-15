namespace Nemone
{
    partial class MainHubForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.container = new System.Windows.Forms.SplitContainer();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnNewMake = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // container.Panel1
            // 
            this.container.Panel1.Controls.Add(this.btnExportPdf);
            this.container.Panel1.Controls.Add(this.btnLoadFile);
            this.container.Panel1.Controls.Add(this.btnNewMake);
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.flowLayoutPanel);
            this.container.Size = new System.Drawing.Size(980, 800);
            this.container.SplitterDistance = 100;
            this.container.TabIndex = 0;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExportPdf.Location = new System.Drawing.Point(827, 25);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(120, 50);
            this.btnExportPdf.TabIndex = 5;
            this.btnExportPdf.Text = "네모 내보내기";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadFile.Location = new System.Drawing.Point(701, 25);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(120, 50);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.Text = "네모 불러오기";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnNewMake
            // 
            this.btnNewMake.Location = new System.Drawing.Point(575, 25);
            this.btnNewMake.Name = "btnNewMake";
            this.btnNewMake.Size = new System.Drawing.Size(120, 50);
            this.btnNewMake.TabIndex = 4;
            this.btnNewMake.Text = "네모 만들기";
            this.btnNewMake.UseVisualStyleBackColor = true;
            this.btnNewMake.Click += new System.EventHandler(this.btnNewMake_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(100, 30, 100, 30);
            this.flowLayoutPanel.Size = new System.Drawing.Size(980, 696);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // MainHubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 800);
            this.Controls.Add(this.container);
            this.Font = new System.Drawing.Font("Pretendard Variable", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainHubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "네모네";
            this.Load += new System.EventHandler(this.MainHubForm_Load);
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnNewMake;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}

