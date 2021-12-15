using System;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckProcessor:Processor<BrainFuckWord>
  {
    protected override Register[] InitRegister()
    {
      return new Register[]
      {
        new (32), // memory pointer,
        new (32)  //Program Counter
      };
    }

    public override void ExecWord(BrainFuckWord w)
    {
      
      TypeBrainFuckCommand c=w;
      Console.WriteLine($"Exec Word {c}");
      switch (c)
      {
        case TypeBrainFuckCommand.JUMP_BACK: 
          
          break;
        case TypeBrainFuckCommand.JUMP_NEXT: break;
          break;
        case TypeBrainFuckCommand.POINTER_DEC: break;
        case TypeBrainFuckCommand.POINTER_INC: break;
        case TypeBrainFuckCommand.POINTER_VAL_DEC: break;
        case TypeBrainFuckCommand.POINTER_VAL_INC: break;
        case TypeBrainFuckCommand.READ_INPUT_BYTE: break;
        case TypeBrainFuckCommand.WRITE_POINTER_VAL: break;
          
        
        default: break;
      }

      this.Registers[1].Count++;
      

    }
  }
}