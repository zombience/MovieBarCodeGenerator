//Copyright 2011-2018 Melvyn Laily
//https://zerowidthjoiner.net

//This file is part of MovieBarCodeGenerator.

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieBarCodeGenerator
{
    public partial class MainForm : Form
    {
        const string GenerateButtonText = "Generate";
        const string CancelButtonText = "Cancel";
        
        FolderBrowserDialog _targetFolderDialog;
        FfmpegWrapper       _ffmpegWrapper;
        ImageProcessor      _imageProcessor;

        CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// this is here not because ffmpeg is limited in movie file types, 
        /// but rather that we need a way to filter to make sure we're opening movie files
        /// and not some invalid filetype
        /// add any filetypes as needed
        /// </summary>
        string[] validMovieExtensions = new string[]
        {
            "mov",
            "avi",
            "mp4",
            "mkv",
            "wmv"
        };


        public MainForm()
        {
            InitializeComponent();

            var executingAssembly = Assembly.GetExecutingAssembly();
            Icon = Icon.ExtractAssociatedIcon(executingAssembly.Location);
            Text += $" - {executingAssembly.GetName().Version}";


            AudioProcessor.Init(); // clear logfile
            SettingsHandler.Load();
            imageHeightTextBox.ReadOnly = SettingsHandler.UseInputHeight;
            barCountTextBox.Text        = SettingsHandler.BarCount.ToString();
            smoothCheckBox.Checked      = SettingsHandler.ShouldCreateSmoothDuplicate;
            chunkSizeTextBox.Text       = SettingsHandler.ChunkSize.ToString();
            fileCountProgress.Visible   = false;

            _sourceFolderDialog.RootFolder = Environment.SpecialFolder.Desktop;
            _targetFolderDialog = new FolderBrowserDialog();

            

            if (!string.IsNullOrEmpty(SettingsHandler.SourceDir))
            {
                _targetFolderDialog.SelectedPath = SettingsHandler.SourceDir;
                inputPathTextBox.Text = SettingsHandler.SourceDir;

            }
            if (!string.IsNullOrEmpty(SettingsHandler.OutputDir))
            {
                _sourceFolderDialog.SelectedPath = SettingsHandler.OutputDir;
                outputPathTextBox.Text = SettingsHandler.OutputDir;
            }



            #region find python

            if (!string.IsNullOrEmpty(SettingsHandler.PythonExe))
            {
                _locatePythonDialog.FileName = SettingsHandler.PythonExe;
                pythonLocTextBox.Text = SettingsHandler.PythonExe;
            }
            else
            {
                _locatePythonDialog.FileName = "";
            }

            string pythonPath = Directory.GetDirectories("C:\\", "Python3*").FirstOrDefault();
            if (string.IsNullOrEmpty(pythonPath))
            {
                pythonPath = Directory.GetDirectories("C:\\Program Files\\", "Python3*").FirstOrDefault();
            }
            if (string.IsNullOrEmpty(pythonPath))
            {
                pythonPath = Path.Combine("%AppData%", "Local\\Programs");
            }

            _locatePythonDialog.InitialDirectory = pythonPath;
            #endregion

            _ffmpegWrapper = new FfmpegWrapper("ffmpeg.exe");
            _imageProcessor = new ImageProcessor();

            useInputHeightForOutputCheckBox.Checked = true;
            generateButton.Text = GenerateButtonText;
        }


        #region Generate Button (main actions)

        private async void generateButton_Click(object sender, EventArgs e)
        {

            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
                generateButton.Text = GenerateButtonText;
                progressBar1.Value = progressBar1.Minimum;
                return;
            }

            #region Validate Params
            try
            {
                ValidateParams();
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion

            #region Loop through files, Send to ffmpeg
            var files = Directory.GetFiles(SettingsHandler.SourceDir)
                .Where(f => validMovieExtensions
                    .Any(ext => f.EndsWith(ext)))
                //.Select(f => Path.GetFileName(f))
                .ToArray();
            //MessageBox.Show(this, $" Will operate on: {files.Length} files", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Actually create the barcode:
            
            fileCountProgress.Visible = true;
            for (int i = 0; i < files.Length; i++)
            {
                // Register progression callback and ready cancellation source:
                fileCountProgress.Text = $"processing {i} of {files.Length} images";
                var progress = new PercentageProgressHandler(percentage =>
                {
                    var progressBarValue = Math.Min(100, (int)Math.Round(percentage * 100, MidpointRounding.AwayFromZero));
                    Invoke(new Action(() =>
                    {
                        if (_cancellationTokenSource != null)
                        {
                            progressBar1.Value = progressBarValue;
                        }
                    }));
                });

                _cancellationTokenSource = new CancellationTokenSource();
                var cancellationLocalRef = _cancellationTokenSource;

                string outputFile = Path.Combine(SettingsHandler.OutputDir, Path.GetFileName(files[i]));  
                outputFile = Path.ChangeExtension(outputFile, "png");

                //MessageBox.Show(this,
                //    $" Source Fie: {files[i]}, " +
                //    $"Target File: {outputFile} ",
                //    "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);



                Bitmap result       = null;
                string audioFile    = string.Empty;
                try
                {
                    generateButton.Text = CancelButtonText;
                    generateButton.Enabled = false;
                    // Prevent the user from cancelling for 1sec (it might not be obvious the generation has started)
                    var dontCare = Task.Delay(1000).ContinueWith(t =>
                    {
                        try
                        {
                            Invoke(new Action(() => generateButton.Enabled = true));
                        }
                        catch { }
                    });

                    await Task.Run(() =>
                    {
                        (result, audioFile) = _imageProcessor.CreateBarCode(files[i], _ffmpegWrapper, _cancellationTokenSource.Token, progress);
                        var args = $"-file {audioFile} -chunk {SettingsHandler.ChunkSize}";
                        AudioProcessor.ProcessAudio(args, _cancellationTokenSource.Token);

                    }, _cancellationTokenSource.Token);

                    //await Task.Run(() =>
                    //{
                    //    var args = $"-file {audioFile} -chunk {SettingsHandler.ChunkSize}";
                    //    AudioProcessor.ProcessAudio(args, _cancellationTokenSource.Token);
                    //}, _cancellationTokenSource.Token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $@"Sorry, something went wrong. Here is all the info available at the time of the error (press Ctrl+C to copy it).
                            Input: {files[i]}
                            Output width: {SettingsHandler.ImageWidth}
                            Output height: {SettingsHandler.ImageHeight}
                            Bar width: {SettingsHandler.BarWidth}
                            Error: {ex}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    generateButton.Text = GenerateButtonText;
                    _cancellationTokenSource?.Dispose();
                    _cancellationTokenSource = null;
                }

                if (cancellationLocalRef.IsCancellationRequested)
                {
                    return;
                }

                // Save the barcode:

                try
                {
                    // for some reason this app is now hanging if files already exist
                    if(File.Exists(outputFile))
                    {
                        File.Delete(outputFile);
                    }
                    result.Save(outputFile, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $" Unable to save the image: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (SettingsHandler.ShouldCreateSmoothDuplicate)
                {

                    Bitmap smoothed;
                    try
                    {
                        smoothed = _imageProcessor.GetSmoothedCopy(result);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"An error occured while creating the smoothed version of the barcode. Error: {ex}",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        var outFile = outputFile.Replace(".png", "_smoothed.png");
                        if(File.Exists(outFile))
                        {
                            File.Delete(outFile);
                        }
                        smoothed.Save(outputFile.Replace(".png", "_smoothed.png"),  System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $" Unable to save the smoothed image: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fileCountProgress.Text = $"finished processing {files.Length} images";
            #endregion
            
        }
        #endregion

        private void ValidateParams()
        {
            var inputPath = inputPathTextBox.Text.Trim(new[] { '"' });
            if (!Directory.Exists(inputPath))
            {
                throw new Exception("The input file does not exist.");
            }

            var outputPath = outputPathTextBox.Text.Trim(new[] { '"' });

            void ValidateOutputPath(ref string path)
            {
                if (path.Any(x => Path.GetInvalidPathChars().Contains(x)))
                {
                    throw new Exception("The output path is invalid.");
                }
            }

            ValidateOutputPath(ref outputPath);

            string smoothedOutputPath = null;
            if (smoothCheckBox.Checked)
            {
                SettingsHandler.ShouldCreateSmoothDuplicate = smoothCheckBox.Checked;
                smoothedOutputPath = Path.Combine(Path.GetDirectoryName(outputPath), "_smoothed");
                ValidateOutputPath(ref smoothedOutputPath);
            }

            if (!int.TryParse(barWidthTextBox.Text, out var barWidth) || barWidth <= 0)
            {
                throw new Exception("Invalid bar width.");
            }

            if (!int.TryParse(imageWidthTextBox.Text, out var imageWidth) || imageWidth <= 0)
            {
                throw new Exception("Invalid output width.");
            }
            
            if (!useInputHeightForOutputCheckBox.Checked)
            {
                if (int.TryParse(imageHeightTextBox.Text, out var nonNullableImageHeight) && nonNullableImageHeight > 0)
                {
                    SettingsHandler.ImageHeight = nonNullableImageHeight;
                     
                }
                else
                {
                    throw new Exception("Invalid output height.");
                }
            }
        }

        #region UI interactions
        private void browseInputPathButton_Click(object sender, EventArgs e)
        {
            if (_sourceFolderDialog.ShowDialog(owner: this) == DialogResult.OK)
            {
                inputPathTextBox.Text = _sourceFolderDialog.SelectedPath;
                SettingsHandler.SourceDir = _sourceFolderDialog.SelectedPath;
            }
        }

        private void browseOutputPathButton_Click(object sender, EventArgs e)
        {
            if (_targetFolderDialog.ShowDialog(owner: this) == DialogResult.OK)
            {
                outputPathTextBox.Text = _targetFolderDialog.SelectedPath;
                SettingsHandler.OutputDir = _targetFolderDialog.SelectedPath;
            }
        }
        private void browseForPythonPathButton_Click(object sender, EventArgs e)
        {
            if(_locatePythonDialog.ShowDialog(owner: this) == DialogResult.OK)
            {
                SettingsHandler.PythonExe = _locatePythonDialog.FileName;
                pythonLocTextBox.Text = _locatePythonDialog.FileName;
            }
        }

        private void useInputHeightForOutputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            imageHeightTextBox.ReadOnly = useInputHeightForOutputCheckBox.Checked;
            SettingsHandler.UseInputHeight = useInputHeightForOutputCheckBox.Checked;
        }
        

        private void imageWidthTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(imageWidthTextBox.Text, out var imageWidth)
             && int.TryParse(barWidthTextBox.Text, out var barWidth))
            {
                try
                {
                    var newBarCount = (int)Math.Round((double)imageWidth / barWidth);
                    SettingsHandler.BarCount = newBarCount;
                    barCountTextBox.Text = newBarCount.ToString();
                }
                catch { }
            }
        }

        private void barCountTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(barCountTextBox.Text, out var barCount)
                && int.TryParse(imageWidthTextBox.Text, out var imageWidth))
            {
                try
                {
                    var newBarWidth = (int)Math.Round((double)imageWidth / barCount);
                    SettingsHandler.BarWidth = newBarWidth;
                    barWidthTextBox.Text = newBarWidth.ToString();
                }
                catch { }
            }
        }

        private void barWidthTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(barWidthTextBox.Text, out var barWidth)
                && int.TryParse(imageWidthTextBox.Text, out var imageWidth))
            {
                try
                {
                    var newBarCount = (int)Math.Round((double)imageWidth / barWidth);
                    SettingsHandler.BarCount = newBarCount;
                    barCountTextBox.Text = newBarCount.ToString();
                }
                catch { }
            }
        }
        private void chunkSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(chunkSizeTextBox.Text, out var size))
            {
                SettingsHandler.ChunkSize = size;
            }
        }

        private void aboutButton_Click(object sender, EventArgs e) => new AboutBox().ShowDialog();

        #endregion

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void _sourceFolderDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

    }

    public class PercentageProgressHandler : IProgress<double>
    {
        private readonly Action<double> _handler;

        public PercentageProgressHandler(Action<double> handler)
        {
            _handler = handler;
        }
        public void Report(double value) => _handler(value);
    }
}
