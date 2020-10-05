using System;
using System.Collections.Generic;
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
            Console.ReadKey();
        }

        static void RunOptions(CmdOptions opts)
        {
            var count = int.Parse(opts.Count);
            using (var sw = new StreamWriter(opts.FileName))
            {
                switch (opts.DataFormat.ToLower())
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
                    case "json":
                        // TODO
                        break;
                    default:
                        Console.WriteLine("Invalid format. Type --help to display the help screen.");
                        break;
                }
            }
        }

        static List<ContactData> CreateContactData(int count)
        {
            var contactData = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contactData.Add(new ContactData
                {
                    FirstName = Randomizer.GenerateRandomString(7),
                    LastName = Randomizer.GenerateRandomString(7),
                    MiddleName = Randomizer.GenerateRandomString(7),
                    Email = Randomizer.GenerateRandomString(7),
                    NickName = Randomizer.GenerateRandomString(7),
                });
            }
            return contactData;
        }
        static List<GroupData> CreateGroupData(int count)
        {
            var groupData = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groupData.Add(new GroupData(Randomizer.GenerateRandomString(7),
                    Randomizer.GenerateRandomString(7),
                    Randomizer.GenerateRandomString(7)));
            }
            return groupData;
        }
    }
}
