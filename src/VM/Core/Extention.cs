using System;
using System.Linq;
using System.Text;

namespace tiny_blockchain.VM.Core
{

  public static class WordExtention
  {
    public static byte[] ToBytes(this Word[] words)
    {
      Int64 totalBit = words.Sum(w => w.bits);
      Int64 totalBytes = totalBit % 8 == 0 ? totalBit / 8 : totalBit / 8 + 1;

      Console.WriteLine($"WORDS={words.Length}TotalBit={totalBit} TotalByte={totalBytes}");
      //bitごとに計算
      for (int i = 0; i < words.Length; i++)
      {

      }
      return new byte[totalBytes];
    }

    public static string ToHexString(this byte[] bytes)
    {
      StringBuilder sb = new StringBuilder();

      foreach (byte b in bytes)
      {
        sb.Append(b.ToString("x"));
      }

      return sb.ToString();
    }
    
  }
}