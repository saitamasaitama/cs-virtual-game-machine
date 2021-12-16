using System;
using System.Collections;
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

    public override byte[] CreateSourceHeader(BrainFuckWord[] words)
    {
      //頭4バイトはワード数
      return BitConverter.GetBytes(words.Length); 
    }

    public override BrainFuckWord[] Source2Words(string source)
    {
      Console.WriteLine("Source2Words");
      List<BrainFuckWord> result = new List<BrainFuckWord>();
      //ソースから1文字ずつ
      foreach (char c in source)
      {
        if (!CharacterTable.ContainsKey(c.ToString())) continue;
        result.Add(fromString(c.ToString()));
      }
      return result.ToArray();
    }

    public override BrainFuckWord[] ByteCode2Words(byte[] code)
    {
      //最初の4バイトはヘッダ
      int wordCount= BitConverter.ToInt32(code, 0);
      List<BrainFuckWord> result = new List<BrainFuckWord>();
      Console.WriteLine("bytecode2Words");
      BitArray bitArray = new BitArray(code);

      
      for (int i = 0; i < wordCount; i++)
      {
        int bitIndex = 4 + (3 * i);
        int ward = 0;
        for (int j = 0; j < 3; j++)
        {
          if (bitArray[bitIndex + j])
          {
            int on = 1;
            on = on << j;
            ward = ward | on;
          }
        }
        result.Add(BrainFuckWord.From((TypeBrainFuckCommand)ward));
      }
      
      return result.ToArray();
    }
  }
}