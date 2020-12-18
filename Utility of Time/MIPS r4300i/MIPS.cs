
namespace UoT {
  public class MIPS {
    public enum R4300 {
      RType = 0,
      OP_REGIMM = 1,
      j = 2,
      jal = 3,
      beq = 4,
      bne = 5,
      blez = 6,
      bgtz = 7,
      addi = 8,
      addiu = 9,
      slti = 10,
      sltiu = 11,
      andi = 12,
      ori = 13,
      xori = 14,
      lui = 15,
      OP_COPRO0 = 16,
      OP_COPRO1 = 17,
      OP_BEQL = 20,
      OP_BNEL = 21,
      OP_BLEZL = 22,
      OP_BGTZL = 23,
      OP_DADDI = 24,
      OP_DADDIU = 25,
      OP_LDL = 26,
      OP_LDR = 27,
      OP_PATCH = 28,
      OP_SRHACK_UNOPT = 29,
      OP_SRHACK_OPT = 30,
      OP_SRHACK_NOOPT = 31,
      lb = 32,
      lh = 33,
      OP_LWL = 34,
      lw = 35,
      lbu = 36,
      lhu = 37,
      OP_LWR = 38,
      OP_LWU = 39,
      sb = 40,
      sh = 41,
      OP_SWL = 42,
      sw = 43,
      OP_SDL = 44,
      OP_SDR = 45,
      OP_SWR = 46,
      OP_CACHE = 47,
      OP_LL = 48,
      lwc1 = 49,
      OP_UNK7 = 50,
      OP_UNK8 = 51,
      OP_LLD = 52,
      OP_LDC1 = 53,
      OP_LDC2 = 54,
      OP_LD = 55,
      OP_SC = 56,
      swc1 = 57,
      OP_DBG_BKPT = 58,
      OP_UNK10 = 59,
      OP_SCD = 60,
      OP_SDC1 = 61,
      OP_SDC2 = 62,
      OP_SD = 63
    }

    public struct MainRegisters {
      public int r0;
      public int at;
      public int v0;
      public int v1;
      public int a0;
      public int a1;
      public int a2;
      public int a3;
      public int t0;
      public int t1;
      public int t2;
      public int t3;
      public int t4;
      public int t5;
      public int t6;
      public int t7;
      public int s0;
      public int s1;
      public int s2;
      public int s3;
      public int s4;
      public int s5;
      public int s6;
      public int s7;
      public int t8;
      public int t9;
      public int k0;
      public int k1;
      public int gp;
      public int sp;
      public int s8;
      public int ra;
    }

    public void Parse(byte[] code) {
      byte instruction = 0;
      byte rs = 0;
      byte rt = 0;
      byte rd = 0;
      byte sa = 0;
      byte fs = 0;
      byte ft = 0;
      byte fd = 0;
      byte @base = 0;
      ushort imm = 0;
      ushort offset = 0;
      uint target = 0U;
      int pc = 0;
      var Regs = new MainRegisters();
      for (int i = 0, loopTo = code.Length - 1; i <= loopTo; i += 8) {
        instruction = code[i];
        switch (instruction) {
          case (byte)R4300.j: {
              break;
            }

          case (byte)R4300.jal: {
              break;
            }

          case (byte)R4300.addiu: {
              break;
            }

          case (byte)R4300.lui: {
              break;
            }
        }

        pc += 8;
      }
    }
  }
}