using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using tiny_blockchain.VM;
using tiny_blockchain.VM.BrainFuck;
using tiny_blockchain.VM.Core;

namespace tiny_blockchain
{
  class Program
  {
    public class Option
    {
      //public string Language="brainfuck";
      public string Machine = "brainfuck";
      public bool isCompile = false;
      public int memorySize = 1024;
      public string outputFile = $"out";
      public string inputFile = $"input";

      public string outputFilePath => $"{outputFile}.{Machine}";

    }
    
    static Option ArgParse(string[] args)
    {
      var result = new Option();
      Dictionary<string, int> singleArg = new Dictionary<string, int>();
      Dictionary<string, int> doubleArg = new Dictionary<string, int>();
      
      args.Select((arg, index)=> (arg,index))
        .ToList()
        .ForEach(item =>
        {
          var doubleMatch = Regex.Match(item.arg, "^--([a-zA-Z0-9]+)$");
          foreach (Capture capture in doubleMatch.Groups[1].Captures)
          {
            doubleArg.Add(capture.Value,item.index);
          }

          var singleMatch = Regex.Match(item.arg, "^-([a-zA-Z0-9]+)$");
          foreach (string capture in singleMatch.Groups[1].Captures)
          {
            doubleArg.Add(capture, item.index);
            Console.WriteLine($"HIT=M{capture}");
          }
          
          
        });
      
      
      //オプション解析部分

      if (singleArg.ContainsKey("c")||doubleArg.ContainsKey("compile"))
      {
        //コンパイル
        Console.WriteLine("SELECT COMPILE");
        result.isCompile = true;

      }
      

      return result;
    }
    
    
    
    static void Main(string[] args)
    {
      Option option = ArgParse(args);

      BrainFuckMachine machine = new BrainFuckMachine(new MachineMeta()
      {
        memorySize = option.memorySize
      });

      if (option.isCompile)
      {
        Console.WriteLine("Compile Mode");
        Compiler<BrainFuckWord> compiler = new BrainFuckCompiler();

        byte[] bytes= compiler.Source2Bytes(Console.In.ReadToEnd());
        
        Console.Out.Write(bytes.ToHexString());
      }
      machine.RunWard(BrainFuckWord.From(TypeBrainFuckCommand.POINTER_INC));
      machine.MemoryDump();
      
      
    }
  }
}