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
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnNewMake = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.container)).BeginInit();
            this.container.Panel1.SuspendLayout();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
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
            // btnLoadFile
            // 
            this.btnLoadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadFile.Location = new System.Drawing.Point(831, 25);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(120, 50);
            this.btnLoadFile.TabIndex = 3;
            this.btnLoadFile.Text = "가져오기";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnNewMake
            // 
            this.btnNewMake.Location = new System.Drawing.Point(705, 25);
            this.btnNewMake.Name = "btnNewMake";
            this.btnNewMake.Size = new System.Drawing.Size(120, 50);
            this.btnNewMake.TabIndex = 4;
            this.btnNewMake.Text = "새로 만들기";
            this.btnNewMake.UseVisualStyleBackColor = true;
            this.btnNewMake.Click += new System.EventHandler(this.btnNewMake_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.button1);
            this.flowLayoutPanel.Controls.Add(this.button2);
            this.flowLayoutPanel.Controls.Add(this.button3);
            this.flowLayoutPanel.Controls.Add(this.button4);
            this.flowLayoutPanel.Controls.Add(this.button5);
            this.flowLayoutPanel.Controls.Add(this.button6);
            this.flowLayoutPanel.Controls.Add(this.button7);
            this.flowLayoutPanel.Controls.Add(this.button8);
            this.flowLayoutPanel.Controls.Add(this.button9);
            this.flowLayoutPanel.Controls.Add(this.button10);
            this.flowLayoutPanel.Controls.Add(this.button11);
            this.flowLayoutPanel.Controls.Add(this.button12);
            this.flowLayoutPanel.Controls.Add(this.button13);
            this.flowLayoutPanel.Controls.Add(this.button14);
            this.flowLayoutPanel.Controls.Add(this.button15);
            this.flowLayoutPanel.Controls.Add(this.button16);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(30);
            this.flowLayoutPanel.Size = new System.Drawing.Size(980, 696);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 173);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(222, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 173);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(411, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(183, 173);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(600, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(183, 173);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(33, 212);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(183, 173);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(222, 212);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 173);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(411, 212);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(183, 173);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(600, 212);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(183, 173);
            this.button8.TabIndex = 7;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(33, 391);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(183, 173);
            this.button9.TabIndex = 8;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(222, 391);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(183, 173);
            this.button10.TabIndex = 9;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(411, 391);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(183, 173);
            this.button11.TabIndex = 10;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(600, 391);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(183, 173);
            this.button12.TabIndex = 11;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(33, 570);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(183, 173);
            this.button13.TabIndex = 12;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(222, 570);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(183, 173);
            this.button14.TabIndex = 13;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(411, 570);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(183, 173);
            this.button15.TabIndex = 14;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(600, 570);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(183, 173);
            this.button16.TabIndex = 15;
            this.button16.Text = "button16";
            this.button16.UseVisualStyleBackColor = true;
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
            this.Text = "nemone";
            this.container.Panel1.ResumeLayout(false);
            this.container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.container)).EndInit();
            this.container.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnNewMake;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
    }
}

