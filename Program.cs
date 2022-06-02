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

    /// <summary>
    /// マシン
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Option option = OptionParser.Parse(args);

      var compiler = new BrainFuckCompiler();
      
      Console.WriteLine($"MACHINE={option.Machine}");

      if (option.isCompile)
      {
        Console.WriteLine("Compile Mode");
        string source = Console.In.ReadToEnd();
        byte[] bytes = compiler.Source2Bytes(source);
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
        var runner = new Runner(option);
        runner.Run();
      }
      else if (option.isScript)
      {
        Console.WriteLine("script Execution Mode");
        
      }
      else
      {
        //スクリプトから実行
        Console.WriteLine("Run Mode From Stream");
      }
    }
  }
}