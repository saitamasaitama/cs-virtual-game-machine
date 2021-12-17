using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  public enum RISCV_REG
  {
    
  }
  
  public class RiscVProseccor:Processor<RV32I>
  {

    protected override void ExecWord(RV32I w)
    {
      throw new System.NotImplementedException();
    }

    public RiscVProseccor(Memory mainMemory) : base(mainMemory)
    {
    }
  }
}