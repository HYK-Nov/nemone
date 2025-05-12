namespace Nemone
{
    partial class ImageBinarizeForm
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
            this.imgBefore = new System.Windows.Forms.PictureBox();
            this.imgAfter = new System.Windows.Forms.PictureBox();
            this.binarySlider = new System.Windows.Forms.TrackBar();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binarySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBefore
            // 
            this.imgBefore.Location = new System.Drawing.Point(111, 57);
            this.imgBefore.Name = "imgBefore";
            this.imgBefore.Size = new System.Drawing.Size(307, 280);
            this.imgBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBefore.TabIndex = 0;
            this.imgBefore.TabStop = false;
            // 
            // imgAfter
            // 
            this.imgAfter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgAfter.Location = new System.Drawing.Point(525, 57);
            this.imgAfter.Name = "imgAfter";
            this.imgAfter.Size = new System.Drawing.Size(307, 280);
            this.imgAfter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgAfter.TabIndex = 1;
            this.imgAfter.TabStop = false;
            // 
            // binarySlider
            // 
            this.binarySlider.Location = new System.Drawing.Point(343, 387);
            this.binarySlider.Maximum = 256;
            this.binarySlider.Name = "binarySlider";
            this.binarySlider.Size = new System.Drawing.Size(257, 56);
            this.binarySlider.TabIndex = 3;
            this.binarySlider.Value = 128;
            this.binarySlider.ValueChanged += new System.EventHandler(this.binarySlider_ValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Pretendard Variable", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Location = new System.Drawing.Point(371, 476);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(200, 60);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "적용하기";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ImageBinarizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(942, 593);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.binarySlider);
            this.Controls.Add(this.imgAfter);
            this.Controls.Add(this.imgBefore);
            this.Font = new System.Drawing.Font("Pretendard Variable", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ImageBinarizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "이미지 변환";
            ((System.ComponentModel.ISupportInitialize)(this.imgBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binarySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBefore;
        private System.Windows.Forms.PictureBox imgAfter;
        private System.Windows.Forms.TrackBar binarySlider;
        private System.Windows.Forms.Button btnApply;
    }
}