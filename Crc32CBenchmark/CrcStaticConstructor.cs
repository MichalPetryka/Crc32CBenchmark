using System;

namespace Crc32CBenchmark
{
	public static class CrcStaticConstructor
	{
		private const uint Poly = 0x82F63B78U;
		private static readonly uint[] Table;

		static CrcStaticConstructor()
		{
			Table = new uint[256 * 8];
			for (uint i = 0; i < 256; i++)
			{
				uint res = i;
				for (int t = 0; t < 8; t++)
				{
					for (int k = 0; k < 8; k++)
						res = (res & 1) == 1 ? Poly ^ (res >> 1) : res >> 1;
					Table[t * 256 + i] = res;
				}
			}
		}

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
				^ Table[1024 + ((crc >> 24) ^ bytes[3])];
		}
	}
}
