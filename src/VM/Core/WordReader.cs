using System.IO;
using System.Text;

namespace tiny_blockchain.VM
{
  /// <summary>
  /// 現在使っていない
  /// </summary>
  /// <typeparam name="WORD"></typeparam>
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

    public bool isReadable =>
      this.BaseStream.CanRead;
    //最短のwordCountまで読み込む
    public abstract WORD[] ReadWords();

  }
}