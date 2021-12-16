using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tiny_blockchain.VM.Core
{

  public static class WordExtention
  {
    /// <summary>
    /// BitArrayではいずれ破綻するため要ブラッシュアップ
    /// </summary>
    /// <param name="words"></param>
    /// <returns></returns>
    public static byte[] ToBytes(this Word[] words)
    {
      Int64 totalBit = words.Sum(w => w.bits);
      Int64 totalBytes = totalBit % 8 == 0 ? totalBit / 8 : totalBit / 8 + 1;
      var bitArray= new BitArray((int)totalBit);
      var result = new byte[totalBytes];
      //bitごとに計算
      Int64 bitIndex = 0;
      for (int i = 0; i < words.Length; i++)
      {
        Word w = words[i];
        BitArray wbits = new BitArray(w);
        for (int j = 0; j < w.bits; j++)
        {
          //対象のbitを取る
          bitArray[(int) bitIndex] = wbits[j];          
          //result wbits
          bitIndex++;
        }
      }
      bitArray.CopyTo(result,0);
      return result;
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