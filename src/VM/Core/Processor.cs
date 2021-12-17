using System;
using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  /// <summary>
  /// CPU相当
  /// </summary>
  public abstract class Processor<WORD,REGISTOR_NAME>
    where REGISTOR_NAME:Enum
    where WORD : Word
  {
    //public Register[] Registers;
    public Dictionary<REGISTOR_NAME, Register> Registers;

    protected abstract Dictionary<REGISTOR_NAME,Register> InitRegister();

    public Processor()
    {
      this.Registers = InitRegister();
    }

    public abstract void ExecWord(WORD w);
  }
}