using System.Collections.Generic;

namespace tiny_blockchain.VM
{
  public class RiscVProseccor:Processor
  {

    protected override Register[] InitRegister()
    {
      List<Register> result = new List<Register>();
      
      result.Add(new Register());

      return result.ToArray();
    }
  }
}