using System.Collections;

namespace tiny_blockchain.VM
{
  public class RISCV
  {

    
    public enum COMMAND_FORMAT_TYPE
    {
      
      R,
      I,
      S,
      B,
      U,
      J
    }

    public enum TYPE_RV32I
    {
      LUI,
      AUIPC,
      ADDI,
      slti,
      sltiu,
      xori,
      ori,
      andi,
      slli,
      srli,
      
      srai,
      add,
      sub,
      sll,
      slt,
      sltu,
      xor,
      srl,
      sra,
      or,
      
      and,
      fence,
      fence_i,
      csrrw,
      csrrs,
      csrrc,
      csrrwi,
      csrrsi,
      csrrci,
      ecall,
      
      ebreak,
      uret,
      sret,
      mret,
      wfi,
      sfence_vma,
      lb,
      lh,
      lw,
      lbu,
      
      lhu,
      sb,
      sh,
      sw,
      jal,
      jalr,
      beq,
      bne,
      blt,
      bge,
      
      bltu,
      bgeu

      
    }
    
    public interface RISCV_R
    {
      BitArray Funct7 { get; }
      BitArray rs2 { get; }
      
    }
    
    
    public class Command
    {
      
    }
    
    public struct Ward32
    {
      private byte[] bytes;
      
      public static explicit operator byte[](Ward32 w)
      {
        return w.bytes;
      }

      public int Read(int index, int size)
      {
        BitArray bitArray = new BitArray(this.bytes);

        int result = 0;
        for (int i = 0; i < size; i++)
        {
          if (bitArray[index + i])
          {
            result += 1;
          }
          result=result << 1;
        }
        return result;
      }
    }

    public class CommandParser
    {
      public Command Parse(Ward32 ward)
      {
        return new Command();
      } 
      
    }
    
  }
}