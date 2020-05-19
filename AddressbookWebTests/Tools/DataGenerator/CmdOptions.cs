using CommandLine;
namespace DataGenerator
{
    public class CmdOptions
    {
        [Option('t', "dataType", Required = true, HelpText = "Data type: contacts or groups")]
        public string DataType { get; set; }

        [Option('c', "count")]
        public string Count { get; set; } = "1";

        [Option('f', "fileName", Required = true, HelpText = "Data type: contacts or groups")]
        public string FileName { get; set; }

        [Option('d', "dataFormat", Required = true, HelpText = "Data format: csv, xml or JSON")]
        public string DataFormat { get; set; }
    }
}
