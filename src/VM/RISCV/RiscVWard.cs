using System;
using System.Collections;
using tiny_blockchain.VM.Wards;

namespace tiny_blockchain.VM
{
  
  
  public class RV32I:Word,IBaseRISCV
  {

    public RV32I(byte[] bytes) : base(bytes,32)
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
    public override string ToASMCode()
    {
      throw new NotImplementedException();
    }

    public override BitArray ToBitArray()
    {
      throw new NotImplementedException();
    }
  }
  
  public class RV64I:Word
  {

    public RV64I(byte[] bytes) : base(bytes,64)
    {
      if (bytes.Length != 8)
      {
        throw new Exception("Length Invalid");
      }
      
    }

    public override string ToASMCode()
    {
      throw new NotImplementedException();
    }

    public override BitArray ToBitArray()
    {
      throw new NotImplementedException();
    }
  }

}