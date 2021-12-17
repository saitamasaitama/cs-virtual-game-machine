using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain.VM.BrainFuckPlus
{
  public enum REG
  {
    SP
  }

  public interface IBrainFuckPlusRegister
  {
    int MemoryPointer { get; set; }
    
  }

  public class BrainFuckPlusProcessor: 
    Processor<BrainFuckPlusWord>,IBrainFuckPlusRegister
  {
    public int MemoryPointer { get; set; }
    public int PointerAddress
    {
      get { return MemoryPointer; }
      set { MemoryPointer = value; }
    }

    public byte PointerValue
    {
      get { return this.memory[PointerAddress]; }
      set { this.memory[PointerAddress] = value; }
    }

    protected override void ExecWord(BrainFuckPlusWord w)
    {
      TypeBrainFuckPlusCommand c = w;
      //Console.WriteLine($"Exec Word {c} [{ProgramCounter}] *[{PointerValue}]");
      //program.DumpInfo(ProgramCounter);
      switch (c)
      {
        case TypeBrainFuckPlusCommand.JUMP_BACK:
          //プログラムカウンタループ
          JumpBack(); 
          break;
        case TypeBrainFuckPlusCommand.JUMP_NEXT:
          JumpNext();
          break;
        case TypeBrainFuckPlusCommand.POINTER_DEC:
          PointerAddress--;
          break;
        case TypeBrainFuckPlusCommand.POINTER_INC:
          PointerAddress++;
          break;
        case TypeBrainFuckPlusCommand.POINTER_VAL_DEC:
          PointerValue--;
          break;
        case TypeBrainFuckPlusCommand.POINTER_VAL_INC:
          PointerValue++;
          break;
        case TypeBrainFuckPlusCommand.READ_INPUT_BYTE:
          PointerValue = Read1Byte();
          break;
        case TypeBrainFuckPlusCommand.WRITE_POINTER_VAL:
          byte[] wr = new byte[]
          {
            PointerValue
          };
          string s= Encoding.ASCII.GetString(wr);
          Console.Write($"{s}");
          break;
      }
    }

    private void JumpNext()
    {
      if (PointerValue == 0)
      {
        while (program[ProgramCounter] == TypeBrainFuckPlusCommand.JUMP_BACK)
        {
          ProgramCounter++;
        }
      }
      else
      {
        
      }
    }


    private void JumpBack()
    {
      if (PointerValue != 0)
      {
        while (program[ProgramCounter]!=TypeBrainFuckPlusCommand.JUMP_NEXT)
        {
          ProgramCounter--;
        }  
      }
      
    }


    private byte Read1Byte()
    {
      byte result;
      using (BinaryReader reader = new BinaryReader(Console.OpenStandardInput()))
      {
        bool success = false;
        byte[] b = new byte[] { };
        while (success == false)
        {
          b = reader.ReadBytes(1);
          success = b.Length == 1;
        }

        result = b[0];
      }

      return result;
    }

    public BrainFuckPlusProcessor(Memory mainMemory) : base(mainMemory)
    {
      MemoryPointer = 0;
    }


    
  }
}