using System;

namespace Crc32CBenchmark
{
	public static partial class CrcPrecomputedTable
	{
		public static unsafe uint Crc32(uint crc, ulong data)
		{
			ReadOnlySpan<byte> bytes = new(&data, sizeof(ulong));
			return Table[768 + bytes[4]]
				^ Table[512 + bytes[5]]
				^ Table[256 + bytes[6]]
				^ Table[bytes[7]]
				^ Table[1792 + ((byte)crc ^ bytes[0])]
				^ Table[1536 + ((byte)(crc >> 8) ^ bytes[1])]
				^ Table[1280 + ((byte)(crc >> 16) ^ bytes[2])]
				^ Table[1024 + (int)((crc >> 24) ^ bytes[3])];
		}
	}
}
