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
      throw new System.NotImplementedException();
    }

    public override Compiler<RV32I> GetCompiler()
    {
      throw new System.NotImplementedException();
    }

    public override WordReader<RV32I> GetReader(Stream stream)
    {
      throw new System.NotImplementedException();
    }
  }
}