namespace tiny_blockchain.VM
{
  /// <summary>
  /// CPU相当
  /// </summary>
  public abstract class Processor<WORD>
    where WORD : Word
  {
    public Register[] Registers;

    protected abstract Register[] InitRegister();

    public Processor()
    {
      this.Registers = InitRegister();
    }

    public abstract void ExecWord(WORD w);
  }
}