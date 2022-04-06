using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MangaLibraryManager.Core.Utilities
{
    public static class ConfigurationFactory
    {
        public static bool IMAGE_COMPRESSION_ENABLED = false;

        public static string IMAGE_FORMAT = "JPEG";
        public static int IMAGE_QUALITY = 8;
        public static int IMAGE_WIDTH = 1080;
        public static int IMAGE_HEIGHT = 1440;
        public static int DEVICE = 0;

        public static string ARCHIVE_OUTPUT_FORMAT = "CBZ";
        public static int ARCHIVE_COMPRESSION_LEVEL = 0;
        public static bool ARCHIVE_SAME_OUTPUT_AS_SOURCE = true;
        public static bool ARCHIVE_OVERWRITE_SOURCE = false;
        public static string ARCHIVE_OUTPUT = "";
        public static string SOURCE_FOLDER = "";

        public static int ADVANCED_COMPRESS_TASKS = 4;
        public static bool ADVANCED_SPLIT_DOUBLEPAGE = false;
        public static bool ADVANCED_IS_JAPANESE_READING = false;
        public static bool ADVANCED_RENAME_TARGET = false;
        public static bool ADVANCED_COPIELOCALE = true;
        public static bool ADVANCED_DELETE_SOURCE = false;
        public static string ADVANCED_TARGET_NAME_TEMPLATE = "";
        public static bool ADVANCED_IGNORE_ARCHIVE_CHECK = false;
        public static bool ADVANCED_FUSION = false;
        public static bool ADVANCED_JPEGOPTIM = false;

        public static bool SETTINGS_PROCESS_IMAGES_IN_MEMORY = false;

        public static string IMAGE_MAGICK_VERSION = "7.10.Q16";
        public static string IMAGE_MAGICK_COLORS = "GRAY";
        public static string IMAGE_MAGICK_OPTIONS = "";
        public static void Save()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                writer.WriteStartObject();

                writer.WritePropertyName("IMAGE_COMPRESSION_ENABLED");
                writer.WriteValue(IMAGE_COMPRESSION_ENABLED);
                writer.WritePropertyName("IMAGE_FORMAT");
                writer.WriteValue(IMAGE_FORMAT);
                writer.WritePropertyName("IMAGE_QUALITY");
                writer.WriteValue(IMAGE_QUALITY);
                writer.WritePropertyName("IMAGE_WIDTH");
                writer.WriteValue(IMAGE_WIDTH);
                writer.WritePropertyName("IMAGE_HEIGHT");
                writer.WriteValue(IMAGE_HEIGHT);
                writer.WritePropertyName("ARCHIVE_OUTPUT_FORMAT");
                writer.WriteValue(ARCHIVE_OUTPUT_FORMAT);
                writer.WritePropertyName("ARCHIVE_COMPRESSION_LEVEL");
                writer.WriteValue(ARCHIVE_COMPRESSION_LEVEL);
                writer.WritePropertyName("ARCHIVE_SAME_OUTPUT_AS_SOURCE");
                writer.WriteValue(ARCHIVE_SAME_OUTPUT_AS_SOURCE);
                writer.WritePropertyName("ARCHIVE_OVERWRITE_SOURCE");
                writer.WriteValue(ARCHIVE_OVERWRITE_SOURCE);
                writer.WritePropertyName("ARCHIVE_OUTPUT");
                writer.WriteValue(ARCHIVE_OUTPUT);
                writer.WritePropertyName("ADVANCED_SPLIT_DOUBLEPAGE");
                writer.WriteValue(ADVANCED_SPLIT_DOUBLEPAGE);
                writer.WritePropertyName("ADVANCED_RENAME_TARGET");
                writer.WriteValue(ADVANCED_RENAME_TARGET);
                writer.WritePropertyName("ADVANCED_COPIELOCALE");
                writer.WriteValue(ADVANCED_COPIELOCALE);
                writer.WritePropertyName("ADVANCED_DELETE_SOURCE");
                writer.WriteValue(ADVANCED_DELETE_SOURCE);
                writer.WritePropertyName("ADVANCED_TARGET_NAME_TEMPLATE");
                writer.WriteValue(ADVANCED_TARGET_NAME_TEMPLATE);
                writer.WritePropertyName("ADVANCED_IGNORE_ARCHIVE_CHECK");
                writer.WriteValue(ADVANCED_IGNORE_ARCHIVE_CHECK);
                writer.WritePropertyName("ADVANCED_FUSION");
                writer.WriteValue(ADVANCED_FUSION);
                writer.WritePropertyName("ADVANCED_JPEGOPTIM");
                writer.WriteValue(ADVANCED_JPEGOPTIM);
                writer.WritePropertyName("ADVANCED_COMPRESS_TASKS");
                writer.WriteValue(ADVANCED_COMPRESS_TASKS);

                writer.WritePropertyName("DEVICE");
                writer.WriteValue(DEVICE);
                writer.WritePropertyName("SOURCE_FOLDER");
                writer.WriteValue(SOURCE_FOLDER);
                writer.WritePropertyName("IMAGE_MAGICK_VERSION");
                writer.WriteValue(IMAGE_MAGICK_VERSION);

                writer.WritePropertyName("IMAGE_MAGICK_COLORS");
                writer.WriteValue(IMAGE_MAGICK_COLORS);

                writer.WritePropertyName("IMAGE_MAGICK_OPTIONS");
                writer.WriteValue(IMAGE_MAGICK_OPTIONS);

                writer.WriteEndObject();

            }
            using (StreamWriter fs = new StreamWriter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json"), false))
            {
                fs.Write(sb.ToString());
                fs.Flush();
            }
        }

        public static void Load()
        {
            String json = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.json"));
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if(reader.TokenType == JsonToken.PropertyName)
                    {
                        switch (reader.Value)
                        {
                            case "IMAGE_COMPRESSION_ENABLED":
                                reader.Read();
                                IMAGE_COMPRESSION_ENABLED = (bool)reader.Value;
                                break;
                            case "IMAGE_FORMAT":
                                reader.Read();
                                IMAGE_FORMAT = reader.Value.ToString();
                                break;
                            case "IMAGE_QUALITY":
                                reader.Read();
                                IMAGE_QUALITY = Convert.ToInt32(reader.Value);
                                break;
                            case "IMAGE_WIDTH":
                                reader.Read();
                                IMAGE_WIDTH = Convert.ToInt32(reader.Value);
                                break;
                            case "IMAGE_HEIGHT":
                                reader.Read();
                                IMAGE_HEIGHT = Convert.ToInt32(reader.Value);
                                break;
                            case "ARCHIVE_OUTPUT_FORMAT":
                                reader.Read();
                                ARCHIVE_OUTPUT_FORMAT = reader.Value.ToString();
                                break;
                            case "ARCHIVE_COMPRESSION_LEVEL":
                                reader.Read();
                                ARCHIVE_COMPRESSION_LEVEL = Convert.ToInt32(reader.Value);
                                break;
                            case "ARCHIVE_SAME_OUTPUT_AS_SOURCE":
                                reader.Read();
                                ARCHIVE_SAME_OUTPUT_AS_SOURCE =(bool)reader.Value;
                                break;
                            case "ARCHIVE_OUTPUT":
                                reader.Read();
                                ARCHIVE_OUTPUT = reader.Value.ToString();
                                break;
                            case "ADVANCED_SPLIT_DOUBLEPAGE":
                                reader.Read();
                                ADVANCED_SPLIT_DOUBLEPAGE =(bool)reader.Value;
                                break;
                            case "ADVANCED_RENAME_TARGET":
                                reader.Read();
                                ADVANCED_RENAME_TARGET =(bool)reader.Value;
                                break;
                            case "ADVANCED_COPIELOCALE":
                                reader.Read();
                                ADVANCED_COPIELOCALE =(bool)reader.Value;
                                break;
                            case "ADVANCED_DELETE_SOURCE":
                                reader.Read();
                                ADVANCED_DELETE_SOURCE =(bool)reader.Value;
                                break;
                            case "ADVANCED_TARGET_NAME_TEMPLATE":
                                reader.Read();
                                ADVANCED_TARGET_NAME_TEMPLATE = reader.Value.ToString();
                                break;
                            case "ADVANCED_IGNORE_ARCHIVE_CHECK":
                                reader.Read();
                                ADVANCED_IGNORE_ARCHIVE_CHECK= (bool)reader.Value;
                                break;
                            case "ADVANCED_FUSION":
                                reader.Read();
                                ADVANCED_FUSION = (bool)reader.Value;
                                break;
                            case "SOURCE_FOLDER":
                                reader.Read();
                                SOURCE_FOLDER = reader.Value.ToString();

                                break;
                            case "ADVANCED_JPEGOPTIM":
                                reader.Read();
                                ADVANCED_JPEGOPTIM = (bool)reader.Value;
                                break;
                            case "DEVICE":
                                reader.Read();
                                DEVICE = Convert.ToInt32(reader.Value);
                                break;
                            case "ADVANCED_COMPRESS_TASKS":
                                reader.Read();
                                ADVANCED_COMPRESS_TASKS = Convert.ToInt32(reader.Value);
                                break;
                            case "IMAGE_MAGICK_VERSION":
                                reader.Read();
                                IMAGE_MAGICK_VERSION = reader.Value.ToString();
                                break;
                            case "IMAGE_MAGICK_COLORS":
                                reader.Read();
                                IMAGE_MAGICK_COLORS = reader.Value.ToString();
                                break;
                            case "ARCHIVE_OVERWRITE_SOURCE":
                                reader.Read();
                                ARCHIVE_OVERWRITE_SOURCE = (bool)reader.Value;
                                break;
                            case "IMAGE_MAGICK_OPTIONS":
                                reader.Read();
                                IMAGE_MAGICK_OPTIONS= reader.Value.ToString();
                                break;
                        }
                    }
                }
                
            }

        }

    }
}
