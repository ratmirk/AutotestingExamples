using System;
using System.IO;
using AddressbookWebTests;
using CommandLine;

namespace DataGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args).WithParsed(RunOptions);
        }

        static void RunOptions(CmdOptions opts)
        {
            var count = int.Parse(opts.Count);
            using (var sw = new StreamWriter(opts.FileName))
            {
                switch (opts.DataFormat)
                {
                    case "csv":
                    { 
                        for (int i = 0; i < count; i++)
                        {
                            sw.WriteLine($"{Randomizer.GenerateRandomString(7)}," +
                                         $"{Randomizer.GenerateRandomString(7)}," +
                                         $"{Randomizer.GenerateRandomString(7)}");
                        }
                        break;
                    }
                    case "xml":
                        // TODO
                        break;
                    case "JSON":
                        // TODO
                        break;
                    default:
                        throw new ArgumentException("Invalid format");
                }
            }
        }
    }
}
