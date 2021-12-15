using System.Collections;
using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  public abstract class WordSequence<WORD> :Queue<WORD>
  where WORD:Word
  {
    public byte[] ToBytes()
    {

      return new byte[] { };
    }
    
    
  }
}