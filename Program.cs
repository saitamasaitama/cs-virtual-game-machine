using System;
using tiny_blockchain.VM;
using tiny_blockchain.VM.BrainFuck;

namespace tiny_blockchain
{
  class Program
  {
    static void Main(string[] args)
    {

      BrainFuckMachine machine = new BrainFuckMachine(new MachineMeta()
      {
        memorySize = 1024
      });
      
      machine.RunWard(BrainFuckWord.From(TypeBrainFuckCommand.POINTER_INC));
      machine.MemoryDump();
      
      
    }
  }
}