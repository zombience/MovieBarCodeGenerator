using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;



namespace MovieBarCodeGenerator
{
    static public class AudioProcessor
    {
        const string audioLog = "audio_log.txt";
        const string pyFile = "main.py";


        static public void Init()
        {
            File.Create(audioLog);
        }

        static public void ProcessAudio(string args, CancellationToken cancellationToken)
        {

            if(!File.Exists(@"audio_processing\main.py"))
            {
                throw new Exception(@"couldn't find audio_processing\main.py");
            }


            string status =
                $@"
                running python with args: {args}
                ";

            File.AppendAllText(audioLog, status);

            var process = Process.Start(new ProcessStartInfo
            {
                FileName                = SettingsHandler.PythonExe,
                Arguments               = $@"audio_processing\{pyFile} {args}",
                UseShellExecute         = false, 
                RedirectStandardOutput  = true,
                RedirectStandardError   = true

            });

            using (cancellationToken.Register(() => process.Kill()))
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            using (StreamReader sr = process.StandardOutput)
            {
                var output = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(output)) File.AppendAllText(audioLog, output);
                
            }
            
            using (StreamReader sr = process.StandardError)
            {
                var output =sr.ReadToEnd();
                if (!string.IsNullOrEmpty(output)) File.AppendAllText(audioLog, output);
            }

            //using (Process process = Process.Start(start))
            //{
            //    using (StreamReader reader = process.StandardOutput)
            //    {
            //        string result = reader.ReadToEnd();
            //        File.AppendAllText(audioLog, result);
            //    }
            //}
        }
        
    }
}
