using System;
using tiny_blockchain.VM;

namespace tiny_blockchain
{
  class Program
  {
    static void Main(string[] args)
    {

      RiscVMachine riscVMachine = new RiscVMachine(new MachineMeta()
      {
        memorySize = 1024
      });
      
      Console.WriteLine("Hello World!");
    }
  }
}