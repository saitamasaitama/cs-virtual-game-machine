using System;
using System.Collections;
using System.Linq;

namespace tiny_blockchain.VM
{
  public abstract class Word
  {
    public int bits;
    public byte[] bytes;
    
    public Word(byte[] bytes,int bits)
    {
      this.bytes = bytes;
      this.bits = bits;
    }

    public static implicit operator byte[](Word w)
    {
      return w.bytes;
    }

    public int ReadBits(int start, int length)
    {
      int result = 0;
      BitArray b = new BitArray(this.bytes);
      for (int i = 0; i < length; i++)
      {
        result = result << 1;
        if (b[start + i])
        {
          result += 1;
        }
      }
      return result;
    }
    public bool this[int index]
    {
      get
      {
        BitArray b = new BitArray(this.bytes);
        return b[index];
      }
    }

    public abstract string ToASMCode();
  }

  public static class WordExtention
  {
    public static byte[] ToBytes(this Word[] words)
    {
      Int64 totalBit = words.Sum(w => w.bits) / 8;
      Int64 totalBytes = totalBit % 8 == 0 ? totalBit / 8 : totalBit / 8 + 1;
      
      //bitごとに計算
      for (int i = 0; i < words.Length; i++)
      {
        
      }
      
      
      return new byte[totalBytes];
    }
  }
}