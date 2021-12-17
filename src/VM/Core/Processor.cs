using System;

namespace tiny_blockchain.VM
{
  /// <summary>
  /// CPU相当
  /// </summary>
  public abstract class Processor<WORD>
    where WORD : Word
  {
    //public Register[] Registers;
    protected int ProgramCounter = 0;
    protected Memory memory;
    protected ProgramCode<WORD> program;
    

    public Processor(Memory mainMemory)
    {
      this.memory = mainMemory;
    }

    public void RunProgram(ProgramCode<WORD> program)
    {
      this.program = program;
      Run();
    }

    private void Run()
    {
      while (0<= ProgramCounter &&　ProgramCounter < program.words.Length　)
      {
        
        ExecWord(this.program[ProgramCounter]);
        ProgramCounter++;
      }
      //Console.WriteLine("Program End");
      Console.Write("\n");
    }
    
    protected abstract void ExecWord(WORD w);
  }
}