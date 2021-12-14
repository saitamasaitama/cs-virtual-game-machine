using System.IO;
using System.Text;

namespace tiny_blockchain.VM
{
  public class WardWriter:BinaryWriter
  {

    public void WriteWard(Ward w)
    {
      
      this.Write(w);
    }
    
  }
}