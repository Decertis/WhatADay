using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace WhatADayVS
{
    class DataController
    {
        private static string config_path = @"Config.json";
        private static string default_saves_path = @"Data.json";
        private static Configuration config;
        public static void Save()
        {
            string path;
            if (config != null)
                path = config.saves_path;
            else
                path = default_saves_path;
            using (StreamWriter streamWriter = File.CreateText(path))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(Model.Events));
            }
        } 
        public static void Load()
        {
            if (File.Exists(config_path))
            {
                config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(config_path));
            }
            else
            {
                using (StreamWriter streamWriter = File.CreateText(config_path))
                {
                    Configuration config = new Configuration(default_saves_path);
                    streamWriter.WriteLine(JsonConvert.SerializeObject(config));
                }
                Load();
            }
            if (File.Exists(config.saves_path))
            {
                Model.Events = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText(config.saves_path));
            }
            else
            {
                Save();
                Load();
            }
        }
    }
}
