using System;
using System.Text;
using tiny_blockchain.VM.Core;

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

    public WORD this[int p] => words[p];

    public static implicit operator WORD[](ProgramCode<WORD> code)
    {
      return code.words;
    }

    public void DumpInfo(int needle, int width=5)
    {
      StringBuilder sb = new StringBuilder();
      int begin = (0 < (needle - width)) ? needle - width : 0;
      int end = words.Length < needle + width ? words.Length : needle + width;
      sb.Append($"[{begin}-({needle})-{end}]");
      for (int i = begin; i < end; i++)
      {
        if (i == needle)
        {
          sb.Append($"({this[i].ToASMCode()})");
        }
        else
        {
          sb.Append(this[i].ToASMCode());  
        }
        
      }
      Console.WriteLine(sb.ToString());
      
    }
  }
}