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
      return new BrainFuckProcessor();
    }

    public override void RunWard(BrainFuckWord w)
    {
      this.mainProcessor.ExecWord(w);
      
    }

    protected override WordReader<BrainFuckWord> loadReader(Stream stream)
    {
      return new BrainFuckReader(stream);
    }

  }
}