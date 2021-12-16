namespace tiny_blockchain.VM.BrainFuck
{
  public enum TypeBrainFuckCommand
  {
    /**
> ポインタをインクリメントする。ポインタをptrとすると、C言語の「ptr++;」に相当する。
< ポインタをデクリメントする。C言語の「ptr--;」に相当。
+ ポインタが指す値をインクリメントする。C言語の「(*ptr)++;」に相当。
- ポインタが指す値をデクリメントする。C言語の「(*ptr)--;」に相当。
. ポインタが指す値を出力に書き出す。C言語の「putchar(*ptr);」に相当。
, 入力から1バイト読み込んで、ポインタが指す先に代入する。C言語の「*ptr=getchar();」に相当。
[ ポインタが指す値が0なら、対応する ] の直後にジャンプする。C言語の「while(*ptr){」に相当。
] ポインタが指す値が0でないなら、対応する [ （の直後[注釈 1]）にジャンプする。C言語の「}」に相当[注釈 2]。 
   */
    POINTER_INC,
    POINTER_DEC,
    POINTER_VAL_INC,
    POINTER_VAL_DEC,
    WRITE_POINTER_VAL,
    READ_INPUT_BYTE,
    JUMP_NEXT,
    JUMP_BACK
  }

  public class BrainFuckWord : Word
  {
    public BrainFuckWord(byte[] bytes) : base(bytes,3)
    {
    }


    public static BrainFuckWord From(TypeBrainFuckCommand command)
    {
      return new BrainFuckWord(
        new byte[]
          {(byte) command}
      );
    }

    public static implicit operator TypeBrainFuckCommand(BrainFuckWord w)
    {
      byte c = w.bytes[0];

      return (TypeBrainFuckCommand) c;
    }

    public override string ToASMCode()
    {
      TypeBrainFuckCommand c = this;
      switch (c)
      {
        case TypeBrainFuckCommand.JUMP_BACK: return "]";
        case TypeBrainFuckCommand.JUMP_NEXT: return "[";
        case TypeBrainFuckCommand.POINTER_DEC: return "<";
        case TypeBrainFuckCommand.POINTER_INC: return ">";
        case TypeBrainFuckCommand.POINTER_VAL_DEC: return "-";
        case TypeBrainFuckCommand.POINTER_VAL_INC: return "+";
        case TypeBrainFuckCommand.READ_INPUT_BYTE: return ",";
        case TypeBrainFuckCommand.WRITE_POINTER_VAL: return ".";

        default: return "";
      }
    }

    
  }
}