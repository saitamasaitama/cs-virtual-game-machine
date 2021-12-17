using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tiny_blockchain.VM.BrainFuck
{
  public class BrainFuckWordReader:WordReader<BrainFuckWord>
  {
    public BrainFuckWordReader(Stream input) : base(input)
    {
    }

    public BrainFuckWordReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public BrainFuckWordReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
    {
    }

    public override WardMeta GetMeta()
    {
      return new WardMeta()
      {
        
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override BrainFuckWord[] ReadWords()
    {
      byte[] code = this.ReadBytes((int)this.BaseStream.Length);
      int wordCount = BitConverter.ToInt32(code, 0);
      List<BrainFuckWord> result = new List<BrainFuckWord>();
      
      BitArray bitArray = new BitArray(code);
      int wordSize = 3;
      int offsetSize = 4 * 8;
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
            on = on << (wordSize - 1 - j);
            word = word | on;
          }
        }
        result.Add(BrainFuckWord.From((TypeBrainFuckCommand) word));
      }
      return result.ToArray();
    }
  }
}