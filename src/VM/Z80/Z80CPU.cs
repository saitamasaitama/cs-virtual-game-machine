namespace tiny_blockchain.VM.Z80
{
  public class Z80CPU:Processor<Z80Ward>
  {

    protected override Register[] InitRegister()
    {
      throw new System.NotImplementedException();
    }

    public override void ExecWord(Z80Ward w)
    {
      throw new System.NotImplementedException();
    }
  }

  public class Z80Ward : Word
  {
    public Z80Ward(byte[] bytes) : base(bytes,4)
    {
    }

    public override string ToASMCode()
    {
      return "";
    }
  }
}