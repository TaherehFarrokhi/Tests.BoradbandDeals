using System.IO;

namespace Tests.BroadbandDeals.Core.Tests
{
    public class FileFixture
    {
        public FileFixture()
        {
            Data = File.ReadAllText("deals.json");
            Stream = GenerateStreamFromString(Data);
        }

        public string Data { get; }
        
        public Stream Stream { get; }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}