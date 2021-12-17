using System;
using System.IO;
using System.Runtime.InteropServices;
using tiny_blockchain.VM;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain
{
  /// <summary>
  /// ファイルから実行
  /// </summary>
  public class Runner
  {
    private Option opt;

    public Runner(Option opt)
    {
      this.opt = opt;
    }


    public bool Run()
    {
      Console.WriteLine("Runner-Run");
      switch (opt.Machine)
      {
        case "brainfuck": return BrainFuckMachine();
        case "brainfuck+": return BrainFuckPlusMachine();
        default: return false;
      }
      
    }

    private bool BrainFuckPlusMachine()
    {
      var machine = new BrainFuckPlusMachine(new MachineMeta()
      {
        memorySize = opt.memorySize
      });

      FileInfo inputFile = new FileInfo(opt.inputFile);
      using (var reader = machine.GetReader(inputFile.OpenRead()))
      {
        var words = reader.ReadWords();
        machine.Run(words);
      }

      return true;
    }

    /// <summary>
    /// BrainFuckMachineを起動する
    /// </summary>
    /// <returns></returns>
    private bool BrainFuckMachine()
    {
      var machine = new BrainFuckMachine(new MachineMeta()
      {
        memorySize = opt.memorySize
      });
      FileInfo inputFile = new FileInfo(opt.inputFile);
      using (var reader = machine.GetReader(inputFile.OpenRead()))
      {
        var words= reader.ReadWords();
        machine.Run(words);
      }
      
      return true;
    }
  }
}