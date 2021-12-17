using System;
using System.Collections;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;

namespace tiny_blockchain.VM
{
  public struct MachineMeta
  {
    public int memorySize;
  }

  /// <summary>
  /// CPU,メモリ,外部出力等も備わった仮想マシン
  /// </summary>
  [Serializable]
  public abstract class Machine<WORD>
    where WORD : Word
  {
    private MachineMeta meta;

    //BIOS相当が必要
    public Processor<WORD> mainProcessor;
    public Memory mainMemory;
    
    public Machine(MachineMeta meta)
    {
      mainMemory = new Memory(meta.memorySize);
      mainProcessor = InitProsessor();
    }

    protected abstract Processor<WORD> InitProsessor();

    public void Run(WORD[] words)
    {
      var program = ProgramCode<WORD>.From(words);
      mainProcessor.RunProgram(program);
    }

    //必要かどうかは微妙
    public abstract Compiler<WORD> GetCompiler();
    public abstract WordReader<WORD> GetReader(Stream stream);
  

    public void MemoryDump()
    {
      Console.WriteLine(BitConverter.ToString(this.mainMemory));
    }
    
  }


  public enum TypeEndian
  {
    BIG_ENDIAN,
    LITTLE_ENDIAN
  }

  public class WardMeta
  {
    public int wordLengthBits;
    public TypeEndian Endian;
  }


  public interface WARD_INTERFACE
  {
  }
}