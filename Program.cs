using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
      public bool isFile = false;
      public int memorySize = 1024;
      public string outputFile = $"out";
      public string inputFile = $"input";

      public string outputFilePath => $"{outputFile}.{Machine}.tvmc";
    }

    static Option ArgParse(string[] args)
    {
      var result = new Option();
      Dictionary<string, int> singleArg = new Dictionary<string, int>();
      Dictionary<string, int> doubleArg = new Dictionary<string, int>();

      args.Select((arg, index) => (arg, index))
        .ToList()
        .ForEach(item =>
        {
          var doubleMatch = Regex.Match(item.arg, "^--([a-zA-Z0-9]+)$");
          foreach (Capture capture in doubleMatch.Groups[1].Captures)
          {
            doubleArg.Add(capture.Value, item.index);
          }

          var singleMatch = Regex.Match(item.arg, "^-([a-zA-Z0-9]+)$");
          foreach (string capture in singleMatch.Groups[1].Captures)
          {
            doubleArg.Add(capture, item.index);
            Console.WriteLine($"HIT=M{capture}");
          }
        });


      //オプション解析部分

      if (singleArg.ContainsKey("c") || doubleArg.ContainsKey("compile"))
      {
        result.isCompile = true;
      }

      if (singleArg.ContainsKey("f") || doubleArg.ContainsKey("file"))
      {
        result.isFile = true;
        int index = singleArg.ContainsKey("f") ? singleArg["f"] : doubleArg["file"];
        if (args.Length < index + 1)
        {
          throw new Exception("Must File Select");
        }

        result.inputFile = args[index + 1];

        FileInfo file = new FileInfo(result.inputFile);
        if (!file.Exists)
        {
          throw new Exception($"{file.FullName} File Not Exists");
        }
      }


      return result;
    }


    static void Main(string[] args)
    {
      Option option = ArgParse(args);

      var compiler = new BrainFuckCompiler();

      if (option.isCompile)
      {
        Console.WriteLine("Compile Mode");
        string source = Console.In.ReadToEnd();
        byte[] bytes = compiler.Source2Bytes(source);
        
        BrainFuckWord[] words = compiler.ByteCode2Words(bytes);
        var decompile = compiler.DeCompileFromWords(words);
        Console.WriteLine($"SOURCE={source}");
        //デバッグ用　ここから
        StringBuilder sb = new StringBuilder();
        foreach (BrainFuckWord word in words)
        {
          sb.Append(word);
        }
        
        //デバッグ用　ここまで
        Console.WriteLine($"COMPILE={sb}");
        Console.WriteLine($"DECOMP={decompile}");

        
        FileInfo outFile = new FileInfo(option.outputFilePath);
        using (BinaryWriter writer = new BinaryWriter(outFile.OpenWrite()))
        {
          writer.Write(bytes);
        }

        Console.WriteLine($"Write Code To:{option.outputFilePath} Done.({bytes.Length})");
      }
      else if (option.isFile)
      {
        Console.WriteLine("Binary File Execution Mode");
        Console.WriteLine($"FILE={option.inputFile}");
        BrainFuckMachine machine = new BrainFuckMachine(new MachineMeta()
        {
          memorySize = option.memorySize
        });
        FileInfo inputFile = new FileInfo(option.inputFile);

        using (BinaryReader reader = new BinaryReader(inputFile.OpenRead()))
        {
          byte[] bytes = reader.ReadBytes((int) reader.BaseStream.Length);
          var words = compiler.ByteCode2Words(bytes);
          //デバッグ用
          var decompile= compiler.DeCompileFromWords(words);
//          Console.WriteLine($"ORIGINAL={decompile}");
          machine.Run(words);
        }
      }
      else
      {
        //逐次実行はおすすめしない
        Console.WriteLine("Run Mode From Stream");
        BrainFuckMachine machine = new BrainFuckMachine(new MachineMeta()
        {
          memorySize = option.memorySize
        });
        //FileInfo inFile = new FileInfo();
        List<byte> buff = new List<byte>();
        using (BinaryReader reader = new BinaryReader(Console.OpenStandardInput()))
        {
          Console.WriteLine("ReadyRed");
          while (reader.BaseStream.CanRead)
          {
            Console.Write(".");

            byte b = reader.ReadByte();
            Console.Write(reader.ReadBytes(1).Length);
            //Console.Write(reader.ReadByte());
          }
        }

        Word[] words = compiler.ByteCode2Words(buff.ToArray());

        Console.WriteLine("WORDS=");

        foreach (var word in words)
        {
          Console.Write(word);
        }

        //machine.RunWord(BrainFuckWord.From(TypeBrainFuckCommand.POINTER_INC));
        machine.MemoryDump();
      }
    }
  }
}