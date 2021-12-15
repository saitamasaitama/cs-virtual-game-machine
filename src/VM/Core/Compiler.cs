using System.Collections.Generic;
using System.IO;
using tiny_blocn.VM;

namespace tiny_blockchain.VM
{
  public abstract class Compiler<WORD>
  where WORD:Word
  {
    public byte[] Source2Bytes(string source)
    {
      //WordWriter
      return Source2Wards(source).ToBytes();
    }

    public WORD[] Source2Wards(string source)
    {
      var result = new List<WORD>();

      return result.ToArray();
    }
    
    
    
    
   
    
    


    

    public string String2IR()
    {
      return "";
    }
  }
}