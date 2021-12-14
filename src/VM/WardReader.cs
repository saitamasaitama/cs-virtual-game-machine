using System.IO;
using System.Text;

namespace tiny_blockchain.VM
{
  public class WardReader:BinaryReader
  {
    
    
    public WardReader(Stream input) : base(input)
    {
      
    }
    public WardReader(Stream input, Encoding encoding) : base(input, encoding)
    {
      
    }
    public WardReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
      
    }

    public Ward ReadWard()
    {
      byte[] bytes= this.ReadBytes(4);
      return new Ward(bytes);
    }

  }
}