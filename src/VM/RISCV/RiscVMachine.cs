using System.IO;
using System.Reflection.PortableExecutable;

namespace tiny_blockchain.VM
{
  public class RiscVMachine:Machine<RV32I>
  {

    public RiscVMachine(MachineMeta meta) : base(meta)
    {
    }
    
    protected override Processor<RV32I> InitProsessor()
    {
      return new RiscVProseccor();
    }

    protected override void RunWord(RV32I w)
    {
      throw new System.NotImplementedException();
    }

    protected override WordReader<RV32I> loadReader(Stream stream)
    {
      throw new System.NotImplementedException();
    }

  }
}