namespace tiny_blockchain.VM
{
  /// <summary>
  /// CPU相当
  /// </summary>
  public abstract class Processor
  {
    
    public Register[] Registers;

    protected abstract Register[] InitRegister();

    public Processor()
    {
      this.Registers = InitRegister();
    }
  }
}