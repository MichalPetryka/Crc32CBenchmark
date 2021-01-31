using BenchmarkDotNet.Running;

namespace Crc32CBenchmark
{
	internal class Program
	{
		private static void Main()
		{
			BenchmarkRunner.Run<Benchmark>();
		}
	}
}
