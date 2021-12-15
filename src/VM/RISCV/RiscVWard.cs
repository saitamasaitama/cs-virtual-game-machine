using System;
using tiny_blockchain.VM.Wards;

namespace tiny_blockchain.VM
{
  
  
  public class RV32I:Word,IBaseRISCV
  {

    public RV32I(byte[] bytes) : base(bytes)
    {
      if (bytes.Length != 4)
      {
        throw new Exception("Length Invalid");
      }
    }
    
    

    protected int OperatorCode
    {
      get
      {
        return this.ReadBits(0,7);
      }
    }
    public int opcode => OperatorCode;
  }
  
  public class RV64I:Word
  {

    public RV64I(byte[] bytes) : base(bytes)
    {
      if (bytes.Length != 8)
      {
        throw new Exception("Length Invalid");
      }
      
    }
  }

}