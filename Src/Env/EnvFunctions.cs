using Amicitia.IO.Binary;
using System.Text;

namespace P5ENVEditor.Env
{
    internal static class EnvFunctions
    {
        private static readonly List<uint> supportedEnvVersions = new List<uint>
        {
            0x1105070, //17846384 (most common, 413 files use it, 693 bytes)
            0x1105060, //17846368 (also common, 195 files use it, 693 bytes)
            0x1105050, //17846352 (env0020_013_010, only file that uses it, 693 bytes)
            0x1105040, //17846336 (env0001_101_010 uses it, 55 files use it, 680 bytes)
            0x1105030, //17846320 (env0000_100_000 uses it, 52 files use it, 680 bytes)
            0x1105020, //17846304 (env0157_002_000 uses it, 26 files use it, 672 bytes)
            0x1105010, //17846288 (env0001_006_000 uses it, 10 files use it, 672 bytes)
            0x1105000, //17846272 (env0002_001_000 uses it, 28 files use it, 668 bytes)
            0x1104990, //17844624 (env0012_002_000, only file that uses it, 668 bytes)
            0x1104970, //17844592 (env0153_010_000 uses it, 5 files use it, 668 bytes) Field1F6 doesn't save back properly for some reason
            0x1104960, //17844576 (env0002_008_030 uses it, only file that uses it, 664 bytes)
            0x1104950, //17844560 (env0221_001_000 uses it, only file that uses it, 664 bytes)
            0x1104940, //17844544 (env0001_101_000 uses it, 2 files use it, 664 bytes)
            0x1104920, //17844512 (env0001_110_000 uses it, 2 files use it, 664 bytes)
            0x1104910, //17844496 (env0222_003_000, only file that uses it, 664 bytes)
            0x1104900  //17844480 (env0222_001_000, 3 files use it, 664 bytes)
        };

        public static uint envVersionCheck;
        public static EnvHeader loadedENVHeader;
        public static EnvParams loadedENVParams;
        public static string? loadedENVFilePath;
        public static long loadedENVFileLength;

        public static void LoadENVFile(string envFilePath)
        {
            if (!string.IsNullOrWhiteSpace(envFilePath))
            {
                if (envFilePath.EndsWith(".ENV", StringComparison.OrdinalIgnoreCase))
                {
                    using var reader = new BinaryObjectReader(envFilePath, Endianness.Big, Encoding.ASCII);

                    var envHeader = new EnvHeader(reader);

                    if (envHeader.fileMagic == 1195791152)
                    {
                        Logger.WriteToLog($"ENV version: 0x{envHeader.gfsVersion:X}", LogLevel.Info);
                        envVersionCheck = envHeader.gfsVersion;

                        if (supportedEnvVersions.Contains(envVersionCheck))
                        {
                            var envParams = new EnvParams(reader);
                            long envFileLength = new FileInfo(envFilePath).Length;

                            if (reader.Position != envFileLength)
                            {
                                throw new InvalidDataException($"Failed to open ENV file, only {reader.Position} out of {envFileLength} bytes were read.");
                            }

                            //only store the ENV data after everything has been read properly
                            loadedENVHeader = envHeader;
                            loadedENVParams = envParams;
                            loadedENVFilePath = envFilePath;
                            loadedENVFileLength = envFileLength;
                        }
                        else
                        {
                            throw new NotSupportedException($"Invalid or unsupported ENV version detected (0x{envHeader.gfsVersion:X}). " +
                                $"Currently, only vanilla Persona 5 ENV files are supported.");
                        }
                    }
                    else
                    {
                        throw new InvalidDataException($"{Path.GetFileName(envFilePath)} is not a valid ENV file. " +
                            "Currently, only vanilla Persona 5 ENV files are supported.");
                    }
                }
                else
                {
                    throw new InvalidDataException($"{Path.GetFileName(envFilePath)} is not an ENV file.");
                }
            }
            else
            {
                throw new ArgumentException("No file has been selected.");
            }
        }

        public static void SaveENVFile(EnvHeader newHeader, EnvParams newParams, string envSaveFilePath)
        {
            if (!string.IsNullOrWhiteSpace(envSaveFilePath))
            {
                string tempFilePath = envSaveFilePath + ".tmp";

                using (var writer = new BinaryObjectWriter(tempFilePath, Endianness.Big, Encoding.ASCII))
                {
                    newHeader.WriteHeader(writer);
                    newParams.WriteParams(writer);
                }

                CompareENVFileSize(tempFilePath, loadedENVFileLength);     
                File.Move(tempFilePath, envSaveFilePath, true);
            }
            else
            {
                throw new ArgumentException("Save file path cannot be empty.");
            }
        }

        private static void CompareENVFileSize(string envFilePath, long originalFileLength)
        {
            long outputFileLength = new FileInfo(envFilePath).Length;

            if (outputFileLength != originalFileLength)
            {
                throw new InvalidDataException($"Output ENV file is not the correct file size. " +
                        $"The expected size was {originalFileLength} bytes. The output size was {outputFileLength} bytes.");
            }
        }
    }
}
