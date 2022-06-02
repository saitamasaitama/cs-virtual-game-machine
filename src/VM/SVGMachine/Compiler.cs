using System;
using System.Collections.Generic;
using System.Text;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain.VM.SVGMachine
{
  public class Compiler:Compiler<BrainFuckPlusWord>
  {
    public Dictionary<string, TypeBrainFuckPlusCommand> CharacterTable = 
      new Dictionary<string, TypeBrainFuckPlusCommand>()
    {
      {"]", TypeBrainFuckPlusCommand.JUMP_BACK},
      {"[", TypeBrainFuckPlusCommand.JUMP_NEXT},
      {"<", TypeBrainFuckPlusCommand.POINTER_DEC},
      {">", TypeBrainFuckPlusCommand.POINTER_INC},
      {"-", TypeBrainFuckPlusCommand.POINTER_VAL_DEC},
      {"+", TypeBrainFuckPlusCommand.POINTER_VAL_INC},
      {",", TypeBrainFuckPlusCommand.READ_INPUT_BYTE},
      {".", TypeBrainFuckPlusCommand.WRITE_POINTER_VAL},

      //追加分
      {"2", TypeBrainFuckPlusCommand.LOOP_2},
      {"3", TypeBrainFuckPlusCommand.LOOP_3},
      {"4", TypeBrainFuckPlusCommand.LOOP_4},
      {"5", TypeBrainFuckPlusCommand.LOOP_5},
      {"6", TypeBrainFuckPlusCommand.LOOP_6},
      {"7", TypeBrainFuckPlusCommand.LOOP_7},
      {"8", TypeBrainFuckPlusCommand.LOOP_8},
      {"_", TypeBrainFuckPlusCommand.NOP},
    };
    
    private BrainFuckPlusWord fromString(string c)
    {
      //ここには必ずキーに相当するものが来る
      return BrainFuckPlusWord.From(CharacterTable[c]);
    }

    public override byte[] CreateSourceHeader(BrainFuckPlusWord[] words)
    {
      //頭4バイトはワード数
      return BitConverter.GetBytes(words.Length); 
    }

    public override string DeCompileFromWords(BrainFuckPlusWord[] words)
    {
      StringBuilder sb = new StringBuilder();

      foreach (BrainFuckPlusWord word in words)
      {
        sb.Append(word.ToASMCode());
      }

      return sb.ToString();
    }

    /// <summary>
    /// これは正しい
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public override BrainFuckPlusWord[] Source2Words(string source)
    {
      List<BrainFuckPlusWord> result = new List<BrainFuckPlusWord>();
      //ソースから1文字ずつ
      foreach (char c in source)
      {
        if (!CharacterTable.ContainsKey(c.ToString())) continue;
        string cs = c.ToString();
        BrainFuckPlusWord w = fromString(cs);
        result.Add(w);
      }
      return result.ToArray();
    }

  }
}