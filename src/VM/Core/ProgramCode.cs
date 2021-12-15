namespace tiny_blockchain.VM
{
  public struct ProgramCode
  {
    public Word[] wards;
    
    
    public static implicit operator Word[](ProgramCode code)
    {
      return code.wards;
    } 
  }
}