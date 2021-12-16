using System.Collections.Generic;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckCompiler:Compiler<BrainFuckWord>
  {
    public Dictionary<string, TypeBrainFuckCommand> CharacterTable = new Dictionary<string, TypeBrainFuckCommand>()
    {
      {"]",TypeBrainFuckCommand.JUMP_BACK},
      {"[", TypeBrainFuckCommand.JUMP_NEXT},
      {"<", TypeBrainFuckCommand.POINTER_DEC},
      {">", TypeBrainFuckCommand.POINTER_INC},
      {"-", TypeBrainFuckCommand.POINTER_VAL_DEC},
      {"+", TypeBrainFuckCommand.POINTER_VAL_INC},
      {",", TypeBrainFuckCommand.READ_INPUT_BYTE},
      {".", TypeBrainFuckCommand.WRITE_POINTER_VAL},
      

    };
    
    private BrainFuckWord fromString(string c)
    {
      //ここには必ずキーに相当するものが来る
      return BrainFuckWord.From(CharacterTable[c]);
    }

    
    public override BrainFuckWord[] Source2Wards(string source)
    {
      List<BrainFuckWord> result = new List<BrainFuckWord>();
      //ソースから1文字ずつ
      foreach (char c in source)
      {
        
        if (!CharacterTable.ContainsKey(c.ToString())) continue;
        result.Add(fromString(c.ToString()));
        
      }

      return result.ToArray();
    }
  }
}