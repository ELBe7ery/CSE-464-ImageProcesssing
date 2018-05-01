namespace ImageProcessing_Project
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
            this.loadButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.samePictureBox = new System.Windows.Forms.PictureBox();
            this.nextButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.previousButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.inferButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.lostPictureBox = new System.Windows.Forms.PictureBox();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.facesDetected = new System.Windows.Forms.PictureBox();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton4 = new MaterialSkin.Controls.MaterialFlatButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.addToDBButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.foundInfoBox = new System.Windows.Forms.RichTextBox();
            this.materialFlatButton5 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton6 = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.samePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lostPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facesDetected)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.AutoSize = true;
            this.loadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadButton.Depth = 0;
            this.loadButton.Location = new System.Drawing.Point(10, 90);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.loadButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.loadButton.Name = "loadButton";
            this.loadButton.Primary = false;
            this.loadButton.Size = new System.Drawing.Size(114, 36);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load image";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // samePictureBox
            // 
            this.samePictureBox.Location = new System.Drawing.Point(438, 195);
            this.samePictureBox.Name = "samePictureBox";
            this.samePictureBox.Size = new System.Drawing.Size(289, 207);
            this.samePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.samePictureBox.TabIndex = 2;
            this.samePictureBox.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.AutoSize = true;
            this.nextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextButton.Depth = 0;
            this.nextButton.Location = new System.Drawing.Point(607, 90);
            this.nextButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.nextButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.nextButton.Name = "nextButton";
            this.nextButton.Primary = false;
            this.nextButton.Size = new System.Drawing.Size(56, 36);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.AutoSize = true;
            this.previousButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousButton.Depth = 0;
            this.previousButton.Location = new System.Drawing.Point(671, 90);
            this.previousButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.previousButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.previousButton.Name = "previousButton";
            this.previousButton.Primary = false;
            this.previousButton.Size = new System.Drawing.Size(56, 36);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "prev";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // logBox
            // 
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.Location = new System.Drawing.Point(13, 456);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(419, 177);
            this.logBox.TabIndex = 3;
            this.logBox.Text = "Client started";
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Enabled = false;
            this.materialFlatButton1.Location = new System.Drawing.Point(10, 411);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(144, 36);
            this.materialFlatButton1.TabIndex = 4;
            this.materialFlatButton1.Text = "developer log";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            // 
            // inferButton
            // 
            this.inferButton.AutoSize = true;
            this.inferButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inferButton.Depth = 0;
            this.inferButton.Location = new System.Drawing.Point(326, 90);
            this.inferButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.inferButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.inferButton.Name = "inferButton";
            this.inferButton.Primary = false;
            this.inferButton.Size = new System.Drawing.Size(60, 36);
            this.inferButton.TabIndex = 1;
            this.inferButton.Text = "infer";
            this.inferButton.UseVisualStyleBackColor = true;
            this.inferButton.Click += new System.EventHandler(this.inferButton_Click);
            // 
            // lostPictureBox
            // 
            this.lostPictureBox.Location = new System.Drawing.Point(13, 195);
            this.lostPictureBox.Name = "lostPictureBox";
            this.lostPictureBox.Size = new System.Drawing.Size(246, 207);
            this.lostPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lostPictureBox.TabIndex = 2;
            this.lostPictureBox.TabStop = false;
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.AutoSize = true;
            this.materialFlatButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.Enabled = false;
            this.materialFlatButton2.Location = new System.Drawing.Point(13, 150);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(182, 36);
            this.materialFlatButton2.TabIndex = 4;
            this.materialFlatButton2.Text = "lost person image";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // facesDetected
            // 
            this.facesDetected.Location = new System.Drawing.Point(265, 195);
            this.facesDetected.Name = "facesDetected";
            this.facesDetected.Size = new System.Drawing.Size(167, 207);
            this.facesDetected.TabIndex = 2;
            this.facesDetected.TabStop = false;
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Enabled = false;
            this.materialFlatButton3.Location = new System.Drawing.Point(265, 150);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(143, 36);
            this.materialFlatButton3.TabIndex = 4;
            this.materialFlatButton3.Text = "face detected";
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            // 
            // materialFlatButton4
            // 
            this.materialFlatButton4.AutoSize = true;
            this.materialFlatButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton4.Depth = 0;
            this.materialFlatButton4.Enabled = false;
            this.materialFlatButton4.Location = new System.Drawing.Point(438, 150);
            this.materialFlatButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton4.Name = "materialFlatButton4";
            this.materialFlatButton4.Primary = false;
            this.materialFlatButton4.Size = new System.Drawing.Size(164, 36);
            this.materialFlatButton4.TabIndex = 4;
            this.materialFlatButton4.Text = "database match";
            this.materialFlatButton4.UseVisualStyleBackColor = true;
            // 
            // addToDBButton
            // 
            this.addToDBButton.AutoSize = true;
            this.addToDBButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addToDBButton.Depth = 0;
            this.addToDBButton.Location = new System.Drawing.Point(153, 90);
            this.addToDBButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addToDBButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.addToDBButton.Name = "addToDBButton";
            this.addToDBButton.Primary = false;
            this.addToDBButton.Size = new System.Drawing.Size(165, 36);
            this.addToDBButton.TabIndex = 1;
            this.addToDBButton.Text = "Add to database";
            this.addToDBButton.UseVisualStyleBackColor = true;
            this.addToDBButton.Click += new System.EventHandler(this.addToDBButton_Click);
            // 
            // foundInfoBox
            // 
            this.foundInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.foundInfoBox.Location = new System.Drawing.Point(438, 456);
            this.foundInfoBox.Name = "foundInfoBox";
            this.foundInfoBox.Size = new System.Drawing.Size(289, 177);
            this.foundInfoBox.TabIndex = 3;
            this.foundInfoBox.Text = "";
            // 
            // materialFlatButton5
            // 
            this.materialFlatButton5.AutoSize = true;
            this.materialFlatButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton5.Depth = 0;
            this.materialFlatButton5.Enabled = false;
            this.materialFlatButton5.Location = new System.Drawing.Point(438, 411);
            this.materialFlatButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton5.Name = "materialFlatButton5";
            this.materialFlatButton5.Primary = false;
            this.materialFlatButton5.Size = new System.Drawing.Size(128, 36);
            this.materialFlatButton5.TabIndex = 4;
            this.materialFlatButton5.Text = "information";
            this.materialFlatButton5.UseVisualStyleBackColor = true;
            // 
            // materialFlatButton6
            // 
            this.materialFlatButton6.AutoSize = true;
            this.materialFlatButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton6.Depth = 0;
            this.materialFlatButton6.Enabled = false;
            this.materialFlatButton6.Location = new System.Drawing.Point(10, 642);
            this.materialFlatButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton6.Name = "materialFlatButton6";
            this.materialFlatButton6.Primary = false;
            this.materialFlatButton6.Size = new System.Drawing.Size(587, 36);
            this.materialFlatButton6.TabIndex = 4;
            this.materialFlatButton6.Text = "ain shams faculty of engineering 2018 image processing class";
            this.materialFlatButton6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(757, 693);
            this.Controls.Add(this.materialFlatButton4);
            this.Controls.Add(this.materialFlatButton3);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.materialFlatButton6);
            this.Controls.Add(this.materialFlatButton5);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.foundInfoBox);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.lostPictureBox);
            this.Controls.Add(this.facesDetected);
            this.Controls.Add(this.samePictureBox);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.addToDBButton);
            this.Controls.Add(this.inferButton);
            this.Controls.Add(this.loadButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "CSE Image Processing Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.samePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lostPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facesDetected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton loadButton;
        private System.Windows.Forms.PictureBox samePictureBox;
        private MaterialSkin.Controls.MaterialFlatButton nextButton;
        private MaterialSkin.Controls.MaterialFlatButton previousButton;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialFlatButton inferButton;
        private System.Windows.Forms.PictureBox lostPictureBox;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private System.Windows.Forms.PictureBox facesDetected;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton4;
        public System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialFlatButton addToDBButton;
        public System.Windows.Forms.RichTextBox foundInfoBox;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton6;
    }
}

