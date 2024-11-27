namespace Assignment1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.outputBox = new System.Windows.Forms.PictureBox();
            this.difBox = new System.Windows.Forms.PictureBox();
            this.histogram1 = new System.Windows.Forms.PictureBox();
            this.histogram2 = new System.Windows.Forms.PictureBox();
            this.openImage = new System.Windows.Forms.Button();
            this.Threshold = new System.Windows.Forms.Button();
            this.imageQuan = new System.Windows.Forms.Button();
            this.histogram = new System.Windows.Forms.Button();
            this.imageDifference = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(103, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 217);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(574, 39);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(413, 217);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;

            // 
            // difBox
            // 
            this.difBox.Location = new System.Drawing.Point(1075, 39);
            this.difBox.Name = "difBox";
            this.difBox.Size = new System.Drawing.Size(379, 217);
            this.difBox.TabIndex = 2;
            this.difBox.TabStop = false;
            // 
            // histogram1
            // 
            this.histogram1.Location = new System.Drawing.Point(84, 333);
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(625, 263);
            this.histogram1.TabIndex = 3;
            this.histogram1.TabStop = false;
            // 
            // histogram2
            // 
            this.histogram2.Location = new System.Drawing.Point(862, 333);
            this.histogram2.Name = "histogram2";
            this.histogram2.Size = new System.Drawing.Size(592, 263);
            this.histogram2.TabIndex = 4;
            this.histogram2.TabStop = false;
            // 
            // openImage
            // 
            this.openImage.Location = new System.Drawing.Point(40, 687);
            this.openImage.Name = "openImage";
            this.openImage.Size = new System.Drawing.Size(189, 63);
            this.openImage.TabIndex = 5;
            this.openImage.Text = "Open Button";
            this.openImage.UseVisualStyleBackColor = true;
            this.openImage.Click += new System.EventHandler(this.button1_Click);
            // 
            // Threshold
            // 
            this.Threshold.Location = new System.Drawing.Point(331, 687);
            this.Threshold.Name = "Threshold";
            this.Threshold.Size = new System.Drawing.Size(202, 63);
            this.Threshold.TabIndex = 6;
            this.Threshold.Text = "Threshold";
            this.Threshold.UseVisualStyleBackColor = true;
            this.Threshold.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageQuan
            // 
            this.imageQuan.Location = new System.Drawing.Point(637, 673);
            this.imageQuan.Name = "imageQuan";
            this.imageQuan.Size = new System.Drawing.Size(192, 91);
            this.imageQuan.TabIndex = 7;
            this.imageQuan.Text = "Image\r\nQuantization";
            this.imageQuan.UseVisualStyleBackColor = true;
            this.imageQuan.Click += new System.EventHandler(this.imageQuan_Click);
            // 
            // histogram
            // 
            this.histogram.Location = new System.Drawing.Point(959, 673);
            this.histogram.Name = "histogram";
            this.histogram.Size = new System.Drawing.Size(192, 91);
            this.histogram.TabIndex = 8;
            this.histogram.Text = "Histogram \r\nEqualization\r\n";
            this.histogram.UseVisualStyleBackColor = true;
            this.histogram.Click += new System.EventHandler(this.histogram_Click);
            // 
            // imageDifference
            // 
            this.imageDifference.Location = new System.Drawing.Point(1259, 701);
            this.imageDifference.Name = "imageDifference";
            this.imageDifference.Size = new System.Drawing.Size(243, 63);
            this.imageDifference.TabIndex = 9;
            this.imageDifference.Text = "Image Difference";
            this.imageDifference.UseVisualStyleBackColor = true;
            this.imageDifference.Click += new System.EventHandler(this.imageDifference_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Input Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(693, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 45);
            this.label2.TabIndex = 11;
            this.label2.Text = "Output Image";

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1153, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 36);
            this.label3.TabIndex = 12;
            this.label3.Text = "Different Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(277, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 36);
            this.label4.TabIndex = 13;
            this.label4.Text = "Input Histogram";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1025, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 36);
            this.label5.TabIndex = 14;
            this.label5.Text = "Output Histogram";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1514, 841);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageDifference);
            this.Controls.Add(this.histogram);
            this.Controls.Add(this.imageQuan);
            this.Controls.Add(this.Threshold);
            this.Controls.Add(this.openImage);
            this.Controls.Add(this.histogram2);
            this.Controls.Add(this.histogram1);
            this.Controls.Add(this.difBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox outputBox;
        private System.Windows.Forms.PictureBox difBox;
        private System.Windows.Forms.PictureBox histogram1;
        private System.Windows.Forms.PictureBox histogram2;
        private System.Windows.Forms.Button openImage;
        private System.Windows.Forms.Button Threshold;
        private System.Windows.Forms.Button imageQuan;
        private System.Windows.Forms.Button histogram;
        private System.Windows.Forms.Button imageDifference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

