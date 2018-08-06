namespace MovieBarCodeGenerator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.inputPathTextBox = new System.Windows.Forms.TextBox();
            this.browseInputPathButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pythonLocLabel = new System.Windows.Forms.Label();
            this.pythonLocTextBox = new System.Windows.Forms.TextBox();
            this.browseForPythonButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.browseOutputPathButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.audioParamsBox = new System.Windows.Forms.GroupBox();
            this.smoothCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.barWidthTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.barCountTextBox = new System.Windows.Forms.TextBox();
            this.useInputHeightForOutputCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageHeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.imageWidthTextBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.aboutButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._sourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._locatePythonDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileCountProgress = new System.Windows.Forms.TextBox();
            this.chunkSizeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPathTextBox
            // 
            this.inputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPathTextBox.Location = new System.Drawing.Point(9, 58);
            this.inputPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputPathTextBox.Name = "inputPathTextBox";
            this.inputPathTextBox.Size = new System.Drawing.Size(548, 26);
            this.inputPathTextBox.TabIndex = 1;
            // 
            // browseInputPathButton
            // 
            this.browseInputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseInputPathButton.Location = new System.Drawing.Point(568, 54);
            this.browseInputPathButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseInputPathButton.Name = "browseInputPathButton";
            this.browseInputPathButton.Size = new System.Drawing.Size(112, 35);
            this.browseInputPathButton.TabIndex = 2;
            this.browseInputPathButton.Text = "Browse...";
            this.browseInputPathButton.UseVisualStyleBackColor = true;
            this.browseInputPathButton.Click += new System.EventHandler(this.browseInputPathButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(597, 542);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(112, 35);
            this.generateButton.TabIndex = 13;
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input video path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pythonLocLabel);
            this.groupBox1.Controls.Add(this.pythonLocTextBox);
            this.groupBox1.Controls.Add(this.browseForPythonButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.outputPathTextBox);
            this.groupBox1.Controls.Add(this.browseOutputPathButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.inputPathTextBox);
            this.groupBox1.Controls.Add(this.browseInputPathButton);
            this.groupBox1.Location = new System.Drawing.Point(18, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(690, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // pythonLocLabel
            // 
            this.pythonLocLabel.AutoSize = true;
            this.pythonLocLabel.Location = new System.Drawing.Point(9, 174);
            this.pythonLocLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pythonLocLabel.Name = "pythonLocLabel";
            this.pythonLocLabel.Size = new System.Drawing.Size(156, 20);
            this.pythonLocLabel.TabIndex = 9;
            this.pythonLocLabel.Text = "Python.exe Location:";
            this.pythonLocLabel.Click += new System.EventHandler(this.label8_Click);
            // 
            // pythonLocTextBox
            // 
            this.pythonLocTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pythonLocTextBox.Location = new System.Drawing.Point(9, 199);
            this.pythonLocTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pythonLocTextBox.Name = "pythonLocTextBox";
            this.pythonLocTextBox.Size = new System.Drawing.Size(548, 26);
            this.pythonLocTextBox.TabIndex = 7;
            // 
            // browseForPythonButton
            // 
            this.browseForPythonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseForPythonButton.Location = new System.Drawing.Point(568, 195);
            this.browseForPythonButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseForPythonButton.Name = "browseForPythonButton";
            this.browseForPythonButton.Size = new System.Drawing.Size(112, 35);
            this.browseForPythonButton.TabIndex = 8;
            this.browseForPythonButton.Text = "Browse...";
            this.browseForPythonButton.UseVisualStyleBackColor = true;
            this.browseForPythonButton.Click += new System.EventHandler(this.browseForPythonPathButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output image path:";
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPathTextBox.Location = new System.Drawing.Point(9, 125);
            this.outputPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(548, 26);
            this.outputPathTextBox.TabIndex = 3;
            // 
            // browseOutputPathButton
            // 
            this.browseOutputPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseOutputPathButton.Location = new System.Drawing.Point(568, 121);
            this.browseOutputPathButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.browseOutputPathButton.Name = "browseOutputPathButton";
            this.browseOutputPathButton.Size = new System.Drawing.Size(112, 35);
            this.browseOutputPathButton.TabIndex = 4;
            this.browseOutputPathButton.Text = "Browse...";
            this.browseOutputPathButton.UseVisualStyleBackColor = true;
            this.browseOutputPathButton.Click += new System.EventHandler(this.browseOutputPathButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.audioParamsBox);
            this.groupBox2.Controls.Add(this.smoothCheckBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.barWidthTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.barCountTextBox);
            this.groupBox2.Controls.Add(this.useInputHeightForOutputCheckBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.imageHeightTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.imageWidthTextBox);
            this.groupBox2.Location = new System.Drawing.Point(20, 259);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(690, 152);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode parameters";
            // 
            // audioParamsBox
            // 
            this.audioParamsBox.Location = new System.Drawing.Point(1, 150);
            this.audioParamsBox.Name = "audioParamsBox";
            this.audioParamsBox.Size = new System.Drawing.Size(689, 77);
            this.audioParamsBox.TabIndex = 19;
            this.audioParamsBox.TabStop = false;
            this.audioParamsBox.Text = "groupBox3";
            // 
            // smoothCheckBox
            // 
            this.smoothCheckBox.AutoSize = true;
            this.smoothCheckBox.Location = new System.Drawing.Point(523, 45);
            this.smoothCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.smoothCheckBox.Name = "smoothCheckBox";
            this.smoothCheckBox.Size = new System.Drawing.Size(155, 44);
            this.smoothCheckBox.TabIndex = 11;
            this.smoothCheckBox.Text = "Also generate\r\na smooth version";
            this.toolTip1.SetToolTip(this.smoothCheckBox, "A second image will be generated, with smoothed bars.\r\nThe file will be created n" +
        "ext to the specified output path, and will have the \"_smoothed\" suffix.");
            this.smoothCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Note: bar width will take precedence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Bar width:";
            // 
            // barWidthTextBox
            // 
            this.barWidthTextBox.Location = new System.Drawing.Point(387, 58);
            this.barWidthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barWidthTextBox.Name = "barWidthTextBox";
            this.barWidthTextBox.Size = new System.Drawing.Size(80, 26);
            this.barWidthTextBox.TabIndex = 10;
            this.barWidthTextBox.Text = "1";
            this.barWidthTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.barWidthTextBox_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bar count:";
            // 
            // barCountTextBox
            // 
            this.barCountTextBox.Location = new System.Drawing.Point(285, 58);
            this.barCountTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.barCountTextBox.Name = "barCountTextBox";
            this.barCountTextBox.Size = new System.Drawing.Size(80, 26);
            this.barCountTextBox.TabIndex = 9;
            this.barCountTextBox.Text = "1000";
            this.barCountTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.barCountTextBox_KeyUp);
            // 
            // useInputHeightForOutputCheckBox
            // 
            this.useInputHeightForOutputCheckBox.AutoSize = true;
            this.useInputHeightForOutputCheckBox.Location = new System.Drawing.Point(9, 98);
            this.useInputHeightForOutputCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.useInputHeightForOutputCheckBox.Name = "useInputHeightForOutputCheckBox";
            this.useInputHeightForOutputCheckBox.Size = new System.Drawing.Size(253, 24);
            this.useInputHeightForOutputCheckBox.TabIndex = 8;
            this.useInputHeightForOutputCheckBox.Text = "Same height as the input video";
            this.useInputHeightForOutputCheckBox.UseVisualStyleBackColor = true;
            this.useInputHeightForOutputCheckBox.CheckedChanged += new System.EventHandler(this.useInputHeightForOutputCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "x";
            // 
            // imageHeightTextBox
            // 
            this.imageHeightTextBox.Location = new System.Drawing.Point(118, 58);
            this.imageHeightTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageHeightTextBox.Name = "imageHeightTextBox";
            this.imageHeightTextBox.Size = new System.Drawing.Size(80, 26);
            this.imageHeightTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Image size:";
            // 
            // imageWidthTextBox
            // 
            this.imageWidthTextBox.Location = new System.Drawing.Point(9, 58);
            this.imageWidthTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageWidthTextBox.Name = "imageWidthTextBox";
            this.imageWidthTextBox.Size = new System.Drawing.Size(80, 26);
            this.imageWidthTextBox.TabIndex = 6;
            this.imageWidthTextBox.Text = "1000";
            this.imageWidthTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.imageWidthTextBox_KeyUp);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(75, 542);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(513, 35);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(20, 542);
            this.aboutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(46, 35);
            this.aboutButton.TabIndex = 12;
            this.aboutButton.Text = "?";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            // 
            // _sourceFolderDialog
            // 
            this._sourceFolderDialog.RootFolder = System.Environment.SpecialFolder.CommonPictures;
            this._sourceFolderDialog.HelpRequest += new System.EventHandler(this._sourceFolderDialog_HelpRequest);
            // 
            // _locatePythonDialog
            // 
            this._locatePythonDialog.FileName = "_locatePythonDialog";
            this._locatePythonDialog.Filter = "\"python executable|*.exe|All files|*.*\"";
            this._locatePythonDialog.InitialDirectory = "C:\\";
            // 
            // fileCountProgress
            // 
            this.fileCountProgress.BackColor = System.Drawing.SystemColors.Info;
            this.fileCountProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.fileCountProgress.Location = new System.Drawing.Point(75, 581);
            this.fileCountProgress.Name = "fileCountProgress";
            this.fileCountProgress.ReadOnly = true;
            this.fileCountProgress.Size = new System.Drawing.Size(513, 26);
            this.fileCountProgress.TabIndex = 14;
            this.fileCountProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chunkSizeTextBox
            // 
            this.chunkSizeTextBox.Location = new System.Drawing.Point(11, 66);
            this.chunkSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chunkSizeTextBox.Name = "chunkSizeTextBox";
            this.chunkSizeTextBox.Size = new System.Drawing.Size(80, 26);
            this.chunkSizeTextBox.TabIndex = 18;
            this.chunkSizeTextBox.TextChanged += new System.EventHandler(this.chunkSizeTextBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chunkSizeTextBox);
            this.groupBox3.Location = new System.Drawing.Point(18, 419);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(690, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Audio Parameters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Chunk size:";
            this.label8.Click += new System.EventHandler(this.label8_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 614);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.fileCountProgress);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generateButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(800, 700);
            this.MinimumSize = new System.Drawing.Size(741, 452);
            this.Name = "MainForm";
            this.Text = "Movie BarCode Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.Button browseInputPathButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button browseOutputPathButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox barWidthTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox barCountTextBox;
        private System.Windows.Forms.CheckBox useInputHeightForOutputCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imageHeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imageWidthTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox smoothCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog _sourceFolderDialog;
        private System.Windows.Forms.Label pythonLocLabel;
        private System.Windows.Forms.TextBox pythonLocTextBox;
        private System.Windows.Forms.Button browseForPythonButton;
        private System.Windows.Forms.OpenFileDialog _locatePythonDialog;
        private System.Windows.Forms.TextBox fileCountProgress;
        private System.Windows.Forms.GroupBox audioParamsBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox chunkSizeTextBox;
    }
}

