using System.IO;
using tiny_blockchain.VM.BrainFuck;
using tiny_blockchain.VM.BrainFuck_;

namespace tiny_blockchain.VM.SVGMachine
{
  public class Machine:Machine<BrainFuckPlusWord>
  {
    public Machine(MachineMeta meta) : base(meta)
    {
      
    }

    protected override Processor<BrainFuckPlusWord> InitProsessor()
    {
      return new BrainFuck_.BrainFuckPlusProcessor(mainMemory);
    }

    public override Compiler<BrainFuckPlusWord> GetCompiler()
    {
      return new BrainFuckPlusCompiler();
    }

    public override WordReader<BrainFuckPlusWord> GetReader(Stream stream)
    {
      throw new System.NotImplementedException();
    }
  }

}