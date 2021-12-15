using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  public class RiscVProseccor:Processor<RV32I>
  {

    protected override Register[] InitRegister()
    {
      List<Register> result = new List<Register>();
      
      result.Add(new Register());

      return result.ToArray();
    }

    public override void ExecWord(RV32I w)
    {
      throw new System.NotImplementedException();
    }
  }
}