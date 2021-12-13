namespace tiny_blockchain.VM
{
  public class RiscVMachine:Machine
  {

    public RiscVMachine(MachineMeta meta) : base(meta)
    {
    }
    
    protected override Processor InitProsessor()
    {
      return new RiscVProseccor();
    }
  }
}