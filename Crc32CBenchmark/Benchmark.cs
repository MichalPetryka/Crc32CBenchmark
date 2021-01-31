using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Crc32CBenchmark
{
	[SimpleJob(RuntimeMoniker.NetCoreApp50)]
	public class Benchmark
	{
		private const uint Crc = uint.MaxValue;
		private const ulong Data = ulong.MaxValue;

		[Benchmark(Description = "SSE")]
		public uint Sse()
		{
			return CrcSse.Crc32(Crc, Data);
		}

		[Benchmark(Description = "Precomputed Table", Baseline = true)]
		public uint PrecomputedTable()
		{
			return CrcPrecomputedTable.Crc32(Crc, Data);
		}

		[Benchmark(Description = "Static constructor table")]
		public uint GeneratedTable()
		{
			return CrcStaticConstructor.Crc32(Crc, Data);
		}

		[Benchmark(Description = "No table")]
		public uint NoTable()
		{
			return CrcNoTable.Crc32(Crc, Data);
		}
	}
}
