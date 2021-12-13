namespace tiny_blockchain.VM
{
  public struct Ward
  {
    public byte[] bytes;
    
    public Ward(byte[] bytes)
    {
      this.bytes = bytes;
    }

    public static explicit operator byte[](Ward w)
    {
      return w.bytes;
    }
  }
}