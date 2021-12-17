using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace tiny_blockchain.VM
{
  public class Register
  {
    public enum RegisterType
    {
      
    }
    
    private byte[] bytes;

    public Register(int bits)
    {
      this.bytes = new byte[((bits % 8 == 0) ? bits / 8 : bits / 8 + 1)];
    }

    public static implicit operator int(Register register)
    {
      return BitConverter.ToInt32(register.bytes);
    }

    public int Count
    {
      get
      {
        return this;
      }
      set
      {
        this.bytes = BitConverter.GetBytes(value);
      }
    }

    public static Register operator ++(Register r)
    {
      r.Count++;
      return r;
    }

    public static implicit operator byte[](Register register)
    {
      return register.bytes;
    }
  }
  
}