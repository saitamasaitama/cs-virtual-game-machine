using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  public enum RISCV_REG
  {
    
  }
  
  public class RiscVProseccor:Processor<RV32I,RISCV_REG>
  {
    
    protected override Dictionary<RISCV_REG, Register> InitRegister()
    {
      throw new System.NotImplementedException();
    }

    public override void ExecWord(RV32I w)
    {
      throw new System.NotImplementedException();
    }
  }
}