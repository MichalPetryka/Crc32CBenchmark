using System;

namespace Crc32CBenchmark
{
	public static class CrcNoTable
	{
		private const uint Poly = 0x82F63B78U;

		public static unsafe uint Crc32(uint crc, ulong data)
		{
			ReadOnlySpan<byte> bytes = new(&data, sizeof(ulong));
			for (int i = 0; i < bytes.Length; i++)
			{
				crc ^= bytes[i];
				for (int j = 0; j < 8; j++)
				{
					uint t = ~((crc & 1) - 1);
					crc = (crc >> 1) ^ (Poly & t);
				}
			}

			return crc;
		}
	}
}
