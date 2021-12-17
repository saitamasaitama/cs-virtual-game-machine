using System;

namespace tiny_blockchain.VM
{
  [Serializable]
  public struct Memory
  {
    private byte[] bytes;

    public Memory(int size)
    {
      bytes = new byte[size];
    }

    public byte this[int index]
    {
      get { return bytes[index]; }
      set { bytes[index] = value; }
    }

    public static implicit operator byte[](Memory memory)
    {
      return memory.bytes;
    }
  }
}