using System.Collections.Generic;
using System.IO;
using System.Linq;
using tiny_blockchain.VM.Core;
using tiny_blocn.VM;

namespace tiny_blockchain.VM
{
  public abstract class Compiler<WORD>
  where WORD:Word
  {
    public byte[] Source2Bytes(string source)
    {
      WORD[] words = Source2Words(source);
      byte[] header=CreateSourceHeader(words);
      
      return header.Concat(words.ToBytes()).ToArray();
    }

    public abstract byte[] CreateSourceHeader(WORD[] words);
    public abstract string DeCompileFromWords(WORD[] words);
    public abstract WORD[] Source2Words(string source);
    public abstract WORD[] ByteCode2Words(byte[] code);
  }
}