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

    public static implicit operator byte[](Memory memory)
    {
      return memory.bytes;
    }

  }

}