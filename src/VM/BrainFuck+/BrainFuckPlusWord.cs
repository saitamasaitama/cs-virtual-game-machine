using System.Collections;
using System.Net;

namespace tiny_blockchain.VM.BrainFuck
{
  /// <summary>
  /// 4bit命令
  /// 4bit目は「繰り返し回数」
  /// 
  /// </summary>
  public enum TypeBrainFuckPlusCommand
  {
    POINTER_INC, // > 000
    POINTER_DEC,  // < 001
    POINTER_VAL_INC, // + 010
    POINTER_VAL_DEC,  // - 011
    WRITE_POINTER_VAL,  //. 100
    READ_INPUT_BYTE,  // , 101
    JUMP_NEXT,        // [ 110
    JUMP_BACK,

    //前のコマンドをN回繰り返す
    LOOP_2,
    LOOP_3,
    LOOP_4,
    LOOP_5,
    LOOP_6,
    LOOP_7,
    LOOP_8,
    
    //何もしない
    NOP 
  }
  

  public class BrainFuckPlusWord : Word
  {
    public const int WORD_BIT_SIZE = 4;
    
    public BrainFuckPlusWord(byte[] bytes) : base(bytes,WORD_BIT_SIZE)
    {
    }


    public static BrainFuckPlusWord From(TypeBrainFuckPlusCommand command)
    {
      return new BrainFuckPlusWord(
        new byte[]
          {(byte) command}
      );
    }

    public static implicit operator TypeBrainFuckPlusCommand(BrainFuckPlusWord w)
    {
      byte c = w.bytes[0];

      return (TypeBrainFuckPlusCommand) c;
    }

    public override string ToASMCode()
    {
      TypeBrainFuckPlusCommand c = this;
      switch (c)
      {
        case TypeBrainFuckPlusCommand.JUMP_BACK: return "]"; 
        case TypeBrainFuckPlusCommand.JUMP_NEXT: return "["; 
        case TypeBrainFuckPlusCommand.POINTER_DEC: return "<";  
        case TypeBrainFuckPlusCommand.POINTER_INC: return ">";  
        case TypeBrainFuckPlusCommand.POINTER_VAL_DEC: return "-";  
        case TypeBrainFuckPlusCommand.POINTER_VAL_INC: return "+";  
        case TypeBrainFuckPlusCommand.READ_INPUT_BYTE: return ",";  
        case TypeBrainFuckPlusCommand.WRITE_POINTER_VAL: return ".";

        default: return c.ToString();
      }
    }

    public override BitArray ToBitArray()
    {
      var result = new BitArray(this.bits);
      TypeBrainFuckPlusCommand code = this;
      int X = (int) code;
      for (int i = 0; i < this.bits; i++)
      {
        if ((X & 1) == 1)
        {
          result[i] = true;
        }
        X = X >> 1;
      }

      return result;
    }


    public override string ToString()
    {
      return ToASMCode();
    }
  }
}