using System;
using System.Collections;
using System.IO;
using System.Reflection.Metadata;
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
  public abstract class Machine
  {
    private MachineMeta meta;
    //BIOS相当が必要

    //
    public Processor mainProcessor;
    public Memory mainMemory;
    
    
    public Machine(MachineMeta meta)
    {
      mainMemory = new Memory(meta.memorySize);
      mainProcessor = InitProsessor();
    }
    
    protected abstract Processor InitProsessor();

    public void Load(Stream input)
    {
      var reader = new WardReader(input);
      using (reader)
      {
        reader.ReadWard();

      }
      Console.WriteLine("Program ReadEnd");
    }
  }

  
  


  public enum TypeEndian
  {
    BIG_ENDIAN,
    LITTLE_ENDIAN
  }

  public class WardMeta
  {
    public int bitLength;
    public TypeEndian Endian;

  }



  public interface WARD_INTERFACE
  {

  }







}