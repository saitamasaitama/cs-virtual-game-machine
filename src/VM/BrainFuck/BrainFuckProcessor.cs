using System;
using System.Collections.Generic;

namespace tiny_blockchain.VM.BrainFuck
{
  public enum REG
  {
    PC,
    SP
  }
  
  public class BrainFuckProcessor:Processor<BrainFuckWord,REG>
  {
    protected override Dictionary<REG,Register> InitRegister()
    {
      return new Dictionary<REG, Register>()
      {
        {REG.PC,new Register(32)}, //Program Counter
        {REG.SP,new Register(32)} // memory pointer,
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

      this.Registers[REG.PC]++;
      

    }
  }
}