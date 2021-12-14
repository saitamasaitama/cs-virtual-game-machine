using System.Collections;

namespace tiny_blockchain.VM
{
  public class Ward
  {
    public byte[] bytes;
    
    public Ward(byte[] bytes)
    {
      this.bytes = bytes;
    }

    public static implicit operator byte[](Ward w)
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
  }
}