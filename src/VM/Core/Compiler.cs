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
    }
    
    public Word[] IRString2Wards()
    {
      var result = new List<Word>();
      return result.ToArray();
    }
    
    
   
    
    


    

    public string String2IR()
    {
      return "";
    }
  }
}