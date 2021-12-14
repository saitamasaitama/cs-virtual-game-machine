namespace tiny_blockchain.VM
{
  public struct ProgramCode
  {
    public Ward[] wards;
    
    
    public static implicit operator Ward[](ProgramCode code)
    {
      return code.wards;
    } 
  }
}