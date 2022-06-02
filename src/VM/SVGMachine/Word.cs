using System.Collections;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain.VM.SVGMachine
{

  

  public class Word : Core.Word
  {
    public const int WORD_BIT_SIZE = 4;
    
    public Word(byte[] bytes) : base(bytes,WORD_BIT_SIZE)
    {
    }


    public static BrainFuckPlusWord From(TypeBrainFuckPlusCommand command)
    {
      return new BrainFuckPlusWord(
        new byte[]
          {(byte) command}
      );
    }

    /*
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
    */


    public override string ToString()
    {
      return ToASMCode();
    }
    public override string ToASMCode()
    {
      throw new System.NotImplementedException();
    }
    public override BitArray ToBitArray()
    {
      throw new System.NotImplementedException();
    }
  }
}