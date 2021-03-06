using System.IO;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain.VM.BrainFuck_
{
  public class BrainFuckPlusMachine:Machine<BrainFuckPlusWord>
  {
    public BrainFuckPlusMachine(MachineMeta meta) : base(meta)
    {
      
    }

    protected override Processor<BrainFuckPlusWord> InitProsessor()
    {
      return new BrainFuckPlusProcessor(mainMemory);
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