using System.IO;
using System.Text;

namespace tiny_blockchain.VM
{
  public abstract class WordReader<WORD>:BinaryReader
  where WORD:Word
  {
    public WardMeta Meta;

    public abstract WardMeta GetMeta();
    
    public WordReader(Stream input) : base(input)
    {
      this.Meta = GetMeta();
    }
    public WordReader(Stream input, Encoding encoding) : base(input, encoding)
    {
      this.Meta = GetMeta();
    }
    public WordReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
      this.Meta = GetMeta();
    }

    public abstract WORD ReadWard();

    public bool isReadable =>
      this.BaseStream.CanRead;
    

    //最短のwordCountまで読み込む
    public WORD[] ReadWords()
    {
      return new WORD[]{};
    }
  }
}