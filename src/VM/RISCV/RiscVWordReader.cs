using System.IO;
using System.Text;

namespace tiny_blockchain.VM
{
  public class RiscVWordReader:WordReader<RV32I>
  {
    public RiscVWordReader(Stream input) : base(input)
    {
    }

    public RiscVWordReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public RiscVWordReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
    }

    public override WardMeta GetMeta()
    {
      return new WardMeta()
      {
        wordLengthBits = 32,
        Endian = TypeEndian.BIG_ENDIAN
      };
    }

    public override RV32I[] ReadWords()
    {
      throw new System.NotImplementedException();
    }
  }
}