namespace tiny_blockchain.VM.Wards
{
  public class RDType :RV32I,IRD
  {

    public int RD=>this.ReadBits(7, 4);
    public RDType(byte[] bytes) : base(bytes)
    {
    }
  }
  
  public class RType:RDType,IRType
  {

    public RType(byte[] bytes) : base(bytes)
    {
    }

    
    public int funct3=> this.ReadBits(11, 3);
    public int rs1=> this.ReadBits(14, 5);
    public int rs2=> this.ReadBits(19, 5);
    public int funct7=> this.ReadBits(24, 7);
  }

  public class IType :RDType, IIType
  {

    public IType(byte[] bytes) : base(bytes)
    {
    }
    public int funct3=> this.ReadBits(11, 3);
    public int rs1=>this.ReadBits(14, 5);
    public int imm11=>this.ReadBits(19,12);
  }

  public class SType : RV32I, ISType
  {

    public SType(byte[] bytes) : base(bytes)
    {
    }
    public int imm4=> this.ReadBits(7, 4);
    public int funct3=> this.ReadBits(11, 3);
    public int rs1=>this.ReadBits(14, 5);
    public int rs2=> this.ReadBits(19, 5);
    public int imm11=> this.ReadBits(24, 7);
  }

  public class BType : RV32I, IBType
  {

    public BType(byte[] bytes) : base(bytes)
    {
    }
    public int imm4 => this.ReadBits(7, 4);
    public int funct3=> this.ReadBits(11, 3);
    public int rs1=>this.ReadBits(14, 5);
    public int rs2=> this.ReadBits(19, 5);
    public int imm12=>this.ReadBits(24, 7);
  }


  public class UType :RDType, IUType
  {
    public UType(byte[] bytes) : base(bytes)
    {
    }
    public int imm31=>this.ReadBits(11,20);
  }

  public class JType :RDType, IJType
  {

    public JType(byte[] bytes) : base(bytes)
    {
    }
    public int imm20=>this.ReadBits(11,20);
  }
  
}