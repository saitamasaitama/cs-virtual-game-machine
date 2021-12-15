using System.IO;
using System.Text;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckReader : WordReader<BrainFuckWord>
  {
    public BrainFuckReader(Stream input) : base(input)
    {
    }

    public BrainFuckReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public BrainFuckReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
    }

    public override WardMeta GetMeta()
    {
      return new WardMeta()
      {
        Endian = TypeEndian.BIG_ENDIAN,
        wordLengthBits = 3
      };
    }

    public override BrainFuckWord ReadWard()
    {
      throw new System.NotImplementedException();
    }
  }
}