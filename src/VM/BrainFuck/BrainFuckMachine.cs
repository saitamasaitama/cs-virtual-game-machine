using System.IO;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckMachine:Machine<BrainFuckWord>
  {
    public BrainFuckMachine(MachineMeta meta) : base(meta)
    {
      
    }

    protected override Processor<BrainFuckWord> InitProsessor()
    {
      return new BrainFuckProcessor(mainMemory);
    }

    public override Compiler<BrainFuckWord> GetCompiler()
    {
      return new BrainFuckCompiler();
    }

    public override WordReader<BrainFuckWord> GetReader(Stream stream)
    {
      return new BrainFuckWordReader(stream);
    }
  }
}