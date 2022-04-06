using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MangaLibraryManager.Core.Utilities
{
    public static class MetadataFactory
    {
        private static string sFilePath;

        public static bool READ = false;
        public static string NAME = "";
        public static List<string> TAGS = new List<string>();
        public static List<string> COMPRESSED = new List<string>();

        public static void Save()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();

                writer.WritePropertyName("name");
                writer.WriteValue(NAME);

                writer.WritePropertyName("compressed");
                writer.WriteStartArray();
                COMPRESSED.ForEach(c => writer.WriteValue(c));
                writer.WriteEndArray();

                writer.WritePropertyName("tags");
                writer.WriteStartArray();
                TAGS.ForEach(c => writer.WriteValue(c));
                writer.WriteEndArray();

                writer.WriteEndObject();

            }
            using (StreamWriter fs = new StreamWriter(sFilePath, false))
            {
                fs.Write(sb.ToString());
                fs.Flush();
            }
        }

        public static void Ensure(string filePath)
        {
            sFilePath = filePath;
            if(!File.Exists(filePath))
            {
                READ = false;
                NAME = Path.GetFileName(Path.GetDirectoryName(filePath));
                Save();
            }

            String json = File.ReadAllText(filePath);

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        switch (reader.Value)
                        {
                            case "read":
                                reader.Read();
                                READ = (bool)reader.Value;
                                break;
                            case "compressed":
                                reader.Read();
                                COMPRESSED = new List<string>();
                                do
                                {
                                    reader.Read();
                                    if((reader.TokenType != JsonToken.EndArray)) COMPRESSED.Add(reader.Value.ToString());
                                } while (reader.TokenType != JsonToken.EndArray);
                                break;
                            case "tags":
                                reader.Read();
                                TAGS = new List<string>();
                                do
                                {
                                    reader.Read();
                                    if ((reader.TokenType != JsonToken.EndArray)) TAGS.Add(reader.Value.ToString());
                                } while (reader.TokenType != JsonToken.EndArray);
                                break;
                        }
                    }
                }

            }
            

        }

    }
}
