using System.IO;
using System.Text;
using tiny_blockchain.VM;

namespace tiny_blocn.VM
{
  /// <summary>
  /// 現在使ってない
  /// </summary>
  /// <typeparam name="WORD"></typeparam>
  public abstract class WordWriter<WORD>:BinaryWriter
    where WORD:Word
  {
    
    

    public void WriteWard(WORD w)
    {
      this.Write(w);
    }

    public void WriteWords(WORD[] w)
    {
      
    }
    
  }
}