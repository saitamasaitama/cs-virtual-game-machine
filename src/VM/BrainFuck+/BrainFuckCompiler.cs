using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using tiny_blockchain.VM.Core;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckPlusCompiler:Compiler<BrainFuckPlusWord>
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

    public override BrainFuckPlusWord[] ByteCode2Words(byte[] code)
    {
      //最初の4バイトはヘッダ
      int wordCount= BitConverter.ToInt32(code, 0);
      List<BrainFuckPlusWord> result = new List<BrainFuckPlusWord>();
      BitArray bitArray = new BitArray(code);
      int wordSize = 3;
      int offsetSize = 4*8;
      for (int i = 0; i < wordCount; i++)
      {
        int bitIndex = offsetSize + (wordSize * i);
        int word = 0;
        //端数を調べる
        for (int j = 0; j < wordSize; j++)
        {
          if (bitArray[bitIndex + j])
          {
            int on = 1;
            on = on << (wordSize-1-j);
            word = word | on;
          }
        }
        result.Add(BrainFuckPlusWord.From((TypeBrainFuckCommand)word));
      }
      
      return result.ToArray();
    }
  }
}