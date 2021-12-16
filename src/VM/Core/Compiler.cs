using System.Collections.Generic;
using System.IO;
using tiny_blockchain.VM.Core;
using tiny_blocn.VM;

namespace tiny_blockchain.VM
{
  public abstract class Compiler<WORD>
  where WORD:Word
  {
    public byte[] Source2Bytes(string source)
    {
      return Source2Wards(source).ToBytes();
    }

    public abstract WORD[] Source2Wards(string source);
    
  }
}