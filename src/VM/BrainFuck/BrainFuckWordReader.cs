using System.IO;
using System.Text;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckWordReader:WordReader<BrainFuckWord>
  {
    public BrainFuckWordReader(Stream input) : base(input)
    {
    }

    public BrainFuckWordReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public BrainFuckWordReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
    }

    public override WardMeta GetMeta()
    {
      return new WardMeta()
      {

      };
    }

    public override BrainFuckWord ReadWord()
    {
      throw new System.NotImplementedException();
    }
  }
}