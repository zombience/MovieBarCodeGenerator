using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MovieBarCodeGenerator
{
    static public class SettingsHandler
    {

        const string settingsFile = "settings.json";
        static Settings settings;


        #region file props
        static public string SourceDir
        {
            get { return settings.sourceDir; }
            set
            {
                settings.sourceDir = value;
                Save();
            }
        }
        static public string OutputDir
        {
            get { return settings.outputDir; }
            set
            {
                settings.outputDir = value;
                Save();
            }
        }
        static public string PythonExe
        {
            get { return settings.pythonExe; }
            set
            {
                settings.pythonExe = value;
                Save();
            }
        }
        #endregion

        #region image props
        static public int BarCount
        {
            get { return settings.barCount; }
            set
            {
                settings.barCount = value;
                Save();
            }
        }

        static public int ImageWidth
        {
            get { return settings.imageWidth; }
            set
            {
                settings.imageWidth = value;
                Save();
            }
        }

        static public int BarWidth
        {
            get { return settings.barWidth; }
            set
            {
                settings.barWidth = value;
                Save();
            }
        }

        static public int ? ImageHeight
        {
            get { return settings.imageHeight; }
            set
            {
                settings.imageHeight = value;
                Save();
            }
        }

        static public bool UseInputHeight
        {
            get { return settings.useInputHeight; }
            set
            {
                settings.useInputHeight = value;
                Save();
            }
        }

        static public bool ShouldCreateSmoothDuplicate
        {
            get { return settings.generateSmooth; }
            set
            {
                settings.generateSmooth = value;
                Save();
            }
        }
        #endregion

        #region audio settings
        static public int ChunkSize
        {
            get { return settings.chunkSize; }
            set
            {
                settings.chunkSize = value;
                Save();
            }
        }
        
        #endregion

        static public void Load()
        {
            try
            {
                using (StreamReader sr = new StreamReader(settingsFile))
                {
                    var rawFile = sr.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<Settings>(rawFile);
                }
            }
            catch (FileNotFoundException e)
            {
                settings = new Settings();
                var json = JsonConvert.SerializeObject(settings);
                File.WriteAllText(settingsFile, json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static public void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(settings);
                File.WriteAllText(settingsFile, json);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Serializable]
        public class Settings
        {
            public string
                sourceDir,
                outputDir,
                pythonExe;

            public int 
                imageWidth  = 1000,
                barWidth    = 1,
                barCount    = 1000;

            public int? imageHeight;

            public bool 
                generateSmooth,
                useInputHeight;

            public int chunkSize = 4020;
        
        }
    }
}
