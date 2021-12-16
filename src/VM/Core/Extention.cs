using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tiny_blockchain.VM.BrainFuck;

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
      var resultBitArray= new BitArray((int)totalBit);
      var result = new byte[totalBytes];
      //bitごとに計算
      Int64 bitIndex = 0;
      for (int i = 0; i < words.Length; i++)
      {
        Word w = words[i];
        byte[] wint = w;
        byte b = wint[0];
        //TypeBrainFuckCommand command = w;
        
        BitArray wbits = new BitArray(w);
        //この時点までは合ってる
//        Console.WriteLine($@"Write-Word={w} Bit={Convert.ToString(b, 2)}  {wbits.ToBitsString()}");
 
        //逆から
        for (int j = w.bits-1; 0<= j; j--)
        {
          //対象のbitを取る
          resultBitArray[(int) bitIndex] = wbits[j];          
          //result wbits
          bitIndex++;
        }
      }
      
      Console.WriteLine($"Writed={resultBitArray.ToBitsString()}");
      
      resultBitArray.CopyTo(result,0);
      return result;
    }

    public static string ToString(this BrainFuckWord[] words)
    {
      StringBuilder sb = new StringBuilder();

      foreach (Word word in words)
      {
        sb.Append(word);
      }

      return sb.ToString();
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

    public static string ToBitsString(this BitArray bitArray,int offset=0)
    {
      StringBuilder sb = new StringBuilder();
      int count = 0;
      for (int i = offset; i < bitArray.Count; i++)
      {
        sb.Append(bitArray[i] ? "1" : "0");
        if (count % 3 == 2)
        {
          sb.Append(":");
        }

        count++;
      }

      return sb.ToString();
    }
    
  }
}