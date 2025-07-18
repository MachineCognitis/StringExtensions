
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringExtensions.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringProcessing>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    public class StringProcessing
    {
        public static readonly string originalString = "Hello, World!";

        [Benchmark]
        public void ExtractNumbers()
        {
            string subString = originalString.Substring(7, 5);
        }

        [Benchmark]
        public void ExtractNumbersWithSpan()
        {
            ReadOnlySpan<char> subString = originalString.AsSpan().Slice(7, 5);

        }
    }
}
