using Newtonsoft.Json;
namespace WhatADayVS
{
    class Configuration
    {
        public string saves_path;
        [JsonConstructor]
        public Configuration(string Path)
        {
            saves_path = Path;
        }
    }
}
