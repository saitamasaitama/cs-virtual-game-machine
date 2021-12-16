namespace tiny_blockchain.VM
{
  public struct ProgramCode<WORD>
    where WORD:Word
  {
    public WORD[] words;

    public static ProgramCode<WORD> From(WORD[] src)
    {
      return new ProgramCode<WORD>()
      {
        words = src
        
      };
    }

    public static implicit operator WORD[](ProgramCode<WORD> code)
    {
      return code.words;
    } 
  }
}