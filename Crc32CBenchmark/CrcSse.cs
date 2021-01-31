using System.Runtime.Intrinsics.X86;

namespace Crc32CBenchmark
{
	public static class CrcSse
	{
		public static uint Crc32(uint crc, ulong data)
		{
			return (uint)Sse42.X64.Crc32(crc, data);
		}
	}
}
