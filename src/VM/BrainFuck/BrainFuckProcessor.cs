using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tiny_blockchain.VM.BrainFuck
{
  public enum REG
  {
    SP
  }

  public interface IBrainFuckRegister
  {
    int MemoryPointer { get; set; }
    
  }

  public class BrainFuckProcessor: 
    Processor<BrainFuckWord>,IBrainFuckRegister
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

    protected override void ExecWord(BrainFuckWord w)
    {
      TypeBrainFuckCommand c = w;
      //Console.WriteLine($"Exec Word {c} [{ProgramCounter}] *[{PointerValue}]");
      //program.DumpInfo(ProgramCounter);
      switch (c)
      {
        case TypeBrainFuckCommand.JUMP_BACK:
          //プログラムカウンタループ
          JumpBack(); 
          break;
        case TypeBrainFuckCommand.JUMP_NEXT:
          JumpNext();
          break;
        case TypeBrainFuckCommand.POINTER_DEC:
          PointerAddress--;
          break;
        case TypeBrainFuckCommand.POINTER_INC:
          PointerAddress++;
          break;
        case TypeBrainFuckCommand.POINTER_VAL_DEC:
          PointerValue--;
          break;
        case TypeBrainFuckCommand.POINTER_VAL_INC:
          PointerValue++;
          break;
        case TypeBrainFuckCommand.READ_INPUT_BYTE:
          PointerValue = Read1Byte();
          break;
        case TypeBrainFuckCommand.WRITE_POINTER_VAL:
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
        while (program[ProgramCounter] == TypeBrainFuckCommand.JUMP_BACK)
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
        while (program[ProgramCounter]!=TypeBrainFuckCommand.JUMP_NEXT)
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

    public BrainFuckProcessor(Memory mainMemory) : base(mainMemory)
    {
      MemoryPointer = 0;
    }


    
  }
}