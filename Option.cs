using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace tiny_blockchain
{
  public class Option
  {
    public string Machine = "brainfuck";
    public bool isCompile = false;
    public bool isFile = false;
    public bool isScript = false;
    public bool isDebug = false; 
    public int memorySize = 1024;
    public string outputFile = $"out";
    public string inputFile = $"input";
    public string outputFilePath => $"{outputFile}.{Machine}.tvmc";
  }

  public class OptionParser
  {
    Dictionary<string, int> singleArg = new Dictionary<string, int>();
    Dictionary<string, int> doubleArg = new Dictionary<string, int>();
    private string[] originalArgs;

    
    public OptionParser(string[] args)
    {
      this.originalArgs = args;
      #region 引数パース

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

      #endregion
    }

    public void Add(string sArg, string dArg, Action<string> act)
    {
      if (!Contain(sArg, dArg)) return;
      int index = Index(sArg, dArg);
      string nextArg = index < originalArgs.Length ? originalArgs[index+1] : null;
      act(nextArg);
    }

    public bool Contain(string sArg, string dArg)
    {
      return (singleArg.ContainsKey(sArg) || doubleArg.ContainsKey(dArg));
    }
    
    public int Index(string sArg, string dArg)
    {
      return singleArg.ContainsKey(sArg) ? singleArg[sArg] : doubleArg[dArg];
    }

    /// <summary>
    /// 使用できるマシン
    /// </summary>
    /// <param name="machine"></param>
    private static void CheckMachine(string machine)
    {
      string[] valids = new string[]
      {
        "brainfuck","brainfuck+"
      };
      if (!valids.Contains(machine))
      {
        throw new Exception($"invalid Machine:{machine}");
      }
    }

    public static Option Parse(string[] args)
    {
      OptionParser parser = new OptionParser(args);
      Option result = new Option();
      
      parser.Add("f","file", next =>
      {
        result.isFile = true;
        if (next==null)
        {
          throw new Exception("Must File Select");
        }
        result.inputFile = next;
        FileInfo file = new FileInfo(result.inputFile);
        if (!file.Exists)
        {
          throw new Exception($"{file.FullName} File Not Exists");
        }
      });

      parser.Add("c","compile", next =>
      {
        result.isCompile = true;
      });
      
      parser.Add("m","machine", machine =>
      {
        CheckMachine(machine);
        result.Machine = machine;
      });
      parser.Add("d","debug", m =>
      {
        result.isDebug = true;
      });
      parser.Add("s", "script", m =>
      {
        result.isScript = true;
      });
      
      
      return result;
    }

  }
}