namespace tiny_blockchain.VM
{

  public struct Register
  {
    private byte[] bytes;

    public Register(int bits)
    {
      this.bytes = new byte[bits/8];
    }


    public static explicit operator byte[](Register register)
    {
      return register.bytes;
    }
  }
}