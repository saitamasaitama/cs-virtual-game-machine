using System.IO;
using System.Text;
using tiny_blockchain.VM;

namespace tiny_blocn.VM
{
  public abstract class WordWriter<WORD>:BinaryWriter
    where WORD:Word
  {
    
    private int 

    public void WriteWard(WORD w)
    {
      this.Write(w);
    }

    public void WriteWords(WORD[] w)
    {
      
    }
    
  }
}