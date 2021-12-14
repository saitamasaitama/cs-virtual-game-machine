namespace tiny_blockchain.VM.Wards
{
  public interface IBaseRISCV
  {
    int opcode { get; }
  }
  
  /// <summary>
  /// RD付きのインターフェース
  /// </summary>
  public interface IRD
  {
    int RD { get; }
  }

  public interface IRType:IRD
  {
    int funct3 { get; }
    int rs1 { get; }
    int rs2 { get; }
    int funct7 { get; }
  }
  
  
  public interface IIType:IRD
  {
    int funct3 { get; }
    int rs1 { get; }
    int imm11 { get; }
    
  }

  
  public interface ISType
  {
    int imm4 { get; }
    int funct3 { get; }
    int rs1 { get; }
    int rs2 { get; }
    int imm11 { get; }
    
  }
  public interface IBType
  {
    
    int imm4 { get; }
    int funct3 { get; }
    int rs1 { get; }
    int rs2 { get; }
    int imm12 { get; }
    
  }
  public interface IUType:IRD
  {
    int imm31 { get; }
  }
  public interface IJType:IRD
  {
    int imm20 { get; }
  }
  
}