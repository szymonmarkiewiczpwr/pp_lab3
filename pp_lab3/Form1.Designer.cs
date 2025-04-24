namespace pp_lab3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputImagePreview = new PictureBox();
            loadImageButton = new Button();
            processButton = new Button();
            negativeDisplayPictureBox = new PictureBox();
            thresholdDisplayPictureBox = new PictureBox();
            greenFilterDisplayPictureBox = new PictureBox();
            grayscaleDisplayPictureBox = new PictureBox();
            openInputFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)inputImagePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)negativeDisplayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thresholdDisplayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)greenFilterDisplayPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grayscaleDisplayPictureBox).BeginInit();
            SuspendLayout();
            // 
            // inputImagePreview
            // 
            inputImagePreview.Location = new Point(12, 12);
            inputImagePreview.Name = "inputImagePreview";
            inputImagePreview.Size = new Size(369, 426);
            inputImagePreview.TabIndex = 0;
            inputImagePreview.TabStop = false;
            // 
            // loadImageButton
            // 
            loadImageButton.Location = new Point(449, 111);
            loadImageButton.Name = "loadImageButton";
            loadImageButton.Size = new Size(106, 23);
            loadImageButton.TabIndex = 1;
            loadImageButton.Text = "Load";
            loadImageButton.UseVisualStyleBackColor = true;
            loadImageButton.Click += loadImageButton_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(449, 140);
            processButton.Name = "processButton";
            processButton.Size = new Size(106, 23);
            processButton.TabIndex = 2;
            processButton.Text = "Process";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += processButton_Click;
            // 
            // negativeDisplayPictureBox
            // 
            negativeDisplayPictureBox.Location = new Point(858, 12);
            negativeDisplayPictureBox.Name = "negativeDisplayPictureBox";
            negativeDisplayPictureBox.Size = new Size(223, 208);
            negativeDisplayPictureBox.TabIndex = 3;
            negativeDisplayPictureBox.TabStop = false;
            // 
            // thresholdDisplayPictureBox
            // 
            thresholdDisplayPictureBox.Location = new Point(620, 12);
            thresholdDisplayPictureBox.Name = "thresholdDisplayPictureBox";
            thresholdDisplayPictureBox.Size = new Size(232, 208);
            thresholdDisplayPictureBox.TabIndex = 4;
            thresholdDisplayPictureBox.TabStop = false;
            // 
            // greenFilterDisplayPictureBox
            // 
            greenFilterDisplayPictureBox.Location = new Point(620, 226);
            greenFilterDisplayPictureBox.Name = "greenFilterDisplayPictureBox";
            greenFilterDisplayPictureBox.Size = new Size(232, 212);
            greenFilterDisplayPictureBox.TabIndex = 5;
            greenFilterDisplayPictureBox.TabStop = false;
            // 
            // grayscaleDisplayPictureBox
            // 
            grayscaleDisplayPictureBox.Location = new Point(858, 226);
            grayscaleDisplayPictureBox.Name = "grayscaleDisplayPictureBox";
            grayscaleDisplayPictureBox.Size = new Size(223, 212);
            grayscaleDisplayPictureBox.TabIndex = 6;
            grayscaleDisplayPictureBox.TabStop = false;
            // 
            // openInputFileDialog
            // 
            openInputFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1093, 449);
            Controls.Add(grayscaleDisplayPictureBox);
            Controls.Add(greenFilterDisplayPictureBox);
            Controls.Add(thresholdDisplayPictureBox);
            Controls.Add(negativeDisplayPictureBox);
            Controls.Add(processButton);
            Controls.Add(loadImageButton);
            Controls.Add(inputImagePreview);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)inputImagePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)negativeDisplayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)thresholdDisplayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)greenFilterDisplayPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)grayscaleDisplayPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox inputImagePreview;
        private Button loadImageButton;
        private Button processButton;
        private PictureBox negativeDisplayPictureBox;
        private PictureBox thresholdDisplayPictureBox;
        private PictureBox greenFilterDisplayPictureBox;
        private PictureBox grayscaleDisplayPictureBox;
        private OpenFileDialog openInputFileDialog;
    }
}
