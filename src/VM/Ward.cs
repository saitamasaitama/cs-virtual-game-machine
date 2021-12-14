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
  }
}