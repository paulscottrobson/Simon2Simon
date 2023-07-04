using System;
using System.Collections.Generic;

namespace SimonEm
{
	public abstract class TMS1000
	{
		private int a;                                                                                  // TMS1000 Registers
		private int x;
		private int y;
		private int s;
		private int sl;
		private int pa;
		private int pb;
		private int pc;
		private int sr;
		private int cl;
		private int o;
		private int[] r = new int[11];
		private int temp8;                                                                              // Temporary variable for xma
		private int cycles;                                                                             // Number of CPU Cycles (6 per instruction)

		protected int[] rom = new int[1024];                                                            // 1k ROM
		protected int[] ram = new int[64];                                                              // 64 bytes RAM

		private static int[] nextPC = { 0x01, 0x03, 0x05, 0x07, 0x09, 0x0B, 0x0D, 0x0F, 0x11, 0x13, 0x15, 0x17, 0x19,
			0x1B, 0x1D, 0x1F, 0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32,
			0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3F, 0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C,
			0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E, 0x21, 0x23, 0x25, 0x27,
			0x29, 0x2B, 0x2D, 0x2F, 0x31, 0x33, 0x35, 0x37, 0x39, 0x3B, 0x3D, 0x3E };

		private static string[] mnemonics = { "comx", "a8aac", "ynea", "tam", "tamza", "a10aac", "a6aac", "dan", "tka", "knez", "tdo", "clo", "rstr", "setr", "ia", "retn", "ldp 0", "ldp 8", "ldp 4", "ldp 12", "ldp 2", "ldp 10", "ldp 6", "ldp 14", "ldp 1", "ldp 9", "ldp 5", "ldp 13", "ldp 3", "ldp 11", "ldp 7", "ldp 15", "tamiy", "tma", "tmy", "tya", "tay", "amaac", "mnez", "saman", "imac", "alem", "dman", "iyc", "dyn", "cpaiz", "xma", "cla", "sbit 0", "sbit 2", "sbit 1", "sbit 3", "rbit 0", "rbit 2", "rbit 1", "rbit 3", "tbit1 0", "tbit1 2", "tbit1 1", "tbit1 3", "ldx 0", "ldx 2", "ldx 1", "ldx 3", "tcy 0", "tcy 8", "tcy 4", "tcy 12", "tcy 2", "tcy 10", "tcy 6", "tcy 14", "tcy 1", "tcy 9", "tcy 5", "tcy 13", "tcy 3", "tcy 11", "tcy 7", "tcy 15", "ynec 0", "ynec 8", "ynec 4", "ynec 12", "ynec 2", "ynec 10", "ynec 6", "ynec 14", "ynec 1", "ynec 9", "ynec 5", "ynec 13", "ynec 3", "ynec 11", "ynec 7", "ynec 15", "tcmiy 0", "tcmiy 8", "tcmiy 4", "tcmiy 12", "tcmiy 2", "tcmiy 10", "tcmiy 6", "tcmiy 14", "tcmiy 1", "tcmiy 9", "tcmiy 5", "tcmiy 13", "tcmiy 3", "tcmiy 11", "tcmiy 7", "tcmiy 15", "alec 0", "alec 8", "alec 4", "alec 12", "alec 2", "alec 10", "alec 6", "alec 14", "alec 1", "alec 9", "alec 5", "alec 13", "alec 3", "alec 11", "alec 7", "alec 15", "br $00", "br $01", "br $02", "br $03", "br $04", "br $05", "br $06", "br $07", "br $08", "br $09", "br $0a", "br $0b", "br $0c", "br $0d", "br $0e", "br $0f", "br $10", "br $11", "br $12", "br $13", "br $14", "br $15", "br $16", "br $17", "br $18", "br $19", "br $1a", "br $1b", "br $1c", "br $1d", "br $1e", "br $1f", "br $20", "br $21", "br $22", "br $23", "br $24", "br $25", "br $26", "br $27", "br $28", "br $29", "br $2a", "br $2b", "br $2c", "br $2d", "br $2e", "br $2f", "br $30", "br $31", "br $32", "br $33", "br $34", "br $35", "br $36", "br $37", "br $38", "br $39", "br $3a", "br $3b", "br $3c", "br $3d", "br $3e", "br $3f", "call $00", "call $01", "call $02", "call $03", "call $04", "call $05", "call $06", "call $07", "call $08", "call $09", "call $0a", "call $0b", "call $0c", "call $0d", "call $0e", "call $0f", "call $10", "call $11", "call $12", "call $13", "call $14", "call $15", "call $16", "call $17", "call $18", "call $19", "call $1a", "call $1b", "call $1c", "call $1d", "call $1e", "call $1f", "call $20", "call $21", "call $22", "call $23", "call $24", "call $25", "call $26", "call $27", "call $28", "call $29", "call $2a", "call $2b", "call $2c", "call $2d", "call $2e", "call $2f", "call $30", "call $31", "call $32", "call $33", "call $34", "call $35", "call $36", "call $37", "call $38", "call $39", "call $3a", "call $3b", "call $3c", "call $3d", "call $3e", "call $3f" };

		protected abstract int InputLines(int[] r);                                                            // I/O Methods, abstract here.
		protected abstract void WriteR(int line,int status);
		protected abstract void WriteO(int value);

		/// <summary>
		/// Reset the Microcontroller
		/// </summary>
		public TMS1000()
		{
			reset();
		}

		/// <summary>
		/// Read Ram memory
		/// </summary>
		/// <param name="address">Nibble address 0-63</param>
		/// <returns>Nibble value</returns>
		public int getRAMMemory(int address)
		{
			return ram[address];
		}

		public int getRegisterStatus(int index)
		{
			return r[index];
		}

		/// <summary>
		/// Get ROM image as a list of instructions ready for the disassembly listing.
		/// </summary>
		/// <returns>List of strings</returns>
		public IList<string> getAssemblerCode()
		{
			IList<string> codeString = new List<string>(256);
			for (int page = 0;page < 16;page ++)
			{
				int pc = 0;
				if (page != 0)
				{
					codeString.Add("");
				}

				codeString.Add("Page " + page);
				for (int code = 0;code < 64;code++)
				{
					int opcode = rom[pc + page * 64];
					codeString.Add(string.Format("{0,3:X3} : {1,2:X2} : {2}", pc + page * 64,opcode,mnemonics[opcode]));
					pc = nextPC[pc];
				}
			}
			return codeString;
		}

		/// <summary>
		/// Read the current processor status.
		/// </summary>
		/// <returns>Dictionary containing values</returns>
		public IDictionary<string, int> getStatus()
		{
			IDictionary<string,int> info = new Dictionary<string,int>();
			info["a"] = a; info["x"] = x; info["y"] = y;
			info["s"] = s; info["sl"] = sl; info["cl"] = cl;
			info["pa"] = pa; info["pb"] = pb; info["pc"] = pc;info["sr"] = sr;
			info["cycles"] = cycles;
			info["o"] = o;
			info["pctr"] = pa * 64 + pc;
			info["xy"] = x * 16 + y;
			for (int i = 0;i <= 10;i++) info["r"+i.ToString()] = r[i];
			return info;
		}

		/// <summary>
		/// Reset the TMS1000. This information comes from section 2-19 on page 2-29.
		/// </summary>
		public void reset()
		{
			Random r = new Random();
			a = x = y = s = sl = pa = pb = pc = sr = cycles = cl = 0;                                   // Zero everything though state is actually undefined.
			pa = 0x0F;                                                                                  // Set PA & PB to 1111
			pb = 0x0F;
			cl = 0;                                                                                     // Clear call latch.
			WriteO(0);                                                                                  // Clears the O register
			for (int i = 0; i <= 10; i++) WriteR(i, 0);                                                 // Clear all the R latches.
			a = r.Next(16); x = r.Next(4); y = r.Next(16);                                              // Everything else random
			s = r.Next(2); sl = r.Next(2);
			sr = r.Next(64);
			for (int i = 0; i < 64; i++) ram[i] = r.Next(16);
		}

		/// <summary>
		/// Implementation of TMS1000 Branch instruction, as described in section 4-12 on page 4-44
		/// Status test already done.
		/// </summary>
		/// <param name="address">lower 6 bit of branch address</param>
		private void branch1000(int address)
		{
			if (cl == 0)                                                                                // If CL is zero.
			{
				pc = address;                                                                           // I(W) -> PC
				pa = pb;                                                                                // PB -> PA
			}
			else                                                                                        // If CL is set.
			{
				pc = address;                                                                           // I(W) -> PC only.
			}
		}

		/// <summary>
		/// Implementation of TMS1000 Call instruction, as described in section 4-12 on page 4-46
		/// Status test already done
		/// </summary>
		/// <param name="address">lower 6 bit of call address</param>
		private void call1000(int address)
		{
			int temp;
			if (cl == 0)                                                                                // if CL is zero.
			{
				sr = pc;                                                                                // PC -> SR (Note we post increment PC so SR technically wrong)
				temp = pa; pa = pb; pb = temp;                                                          // PB <-> PA
				pc = address;                                                                           // I(W) -> PC
				cl = 1;                                                                                 // 1->CL
			}
			else                                                                                        // If CL is set
			{
				pc = address;                                                                           // I(W)-> PC
				pb = pa;                                                                                // PA -> PB
			}
		}

		/// <summary>
		/// Implementation of TMS1000 Return instruction as described in section 4-12 on page 4-48
		/// </summary>
		private void return1000()
		{
			if (cl != 0)                                                                                // if CL is set.
			{
				pc = sr;                                                                                // SR -> PC
				pa = pb;                                                                                // PB -> PA
				cl = 0;                                                                                 // 0 -> CL
			}
			else                                                                                        // if CL is clear.
			{
				pa = pb;                                                                                // PB -> PA
			}
		}

		/// <summary>
		/// Execute a single instruction. The whole switch is automatically generated code.
		/// </summary>
		public virtual void Execute()
		{
			int opcode = rom[(pa << 6) + pc];                                                           // Read opcode to execute
			pc = nextPC[pc];                                                                            // Advance PC (it is a LFSR)
			cycles += 6;                                                                                // Bump cycle count.
			switch (opcode)                                                                             // Execute instruction.
			{

					case 0x00: /* 00 comx */
					x = x ^ 0x03;
					s = 1;
					break;

					case 0x01: /* 01 a8aac */
					s = ((a + 8) >= 0x10) ? 1 : 0;
					a = (a + 8) & 0x0F;
					break;

					case 0x02: /* 02 ynea */
					s = (y != a) ? 1 : 0;
					sl = s;
					break;

					case 0x03: /* 03 tam */
					ram[x * 16 + y] = a;
					s = 1;
					break;

					case 0x04: /* 04 tamza */
					ram[x * 16 + y] = a;
					a = 0;
					s = 1;
					break;

					case 0x05: /* 05 a10aac */
					s = ((a + 10) >= 0x10) ? 1 : 0;
					a = (a + 10) & 0x0F;
					break;

					case 0x06: /* 06 a6aac */
					s = ((a + 6) >= 0x10) ? 1 : 0;
					a = (a + 6) & 0x0F;
					break;

					case 0x07: /* 07 dan */
					s = (a == 0) ? 0 : 1;
					a = (a - 1) & 0x0F;
					break;

					case 0x08: /* 08 tka */
					a = InputLines(r);
					s = 1;
					break;

					case 0x09: /* 09 knez */
					s = (InputLines(r) != 0) ? 1 : 0;
					break;

					case 0x0a: /* 0a tdo */
					o = (sl << 4) | a;
					WriteO(o);
					s = 1;
					break;

					case 0x0b: /* 0b clo */
					o = 0;
					WriteO(0);
					s = 1;
					break;

					case 0x0c: /* 0c rstr */
					if (y <= 10)
					{
						r[y] = 0;
						WriteR(y, 0);
					};
					s = 1;
					break;

					case 0x0d: /* 0d setr */
					if (y <= 10)
					{
						r[y] = 1;
						WriteR(y, 1);
					};
					s = 1;
					break;

					case 0x0e: /* 0e ia */
					a = (a + 1) & 0x0F;
					s = 1;
					break;

					case 0x0f: /* 0f retn */
					return1000();
					s = 1;
					break;

					case 0x10: /* 10 ldp 0 */
					pb = 0;
					s = 1;
					break;

					case 0x11: /* 11 ldp 8 */
					pb = 8;
					s = 1;
					break;

					case 0x12: /* 12 ldp 4 */
					pb = 4;
					s = 1;
					break;

					case 0x13: /* 13 ldp 12 */
					pb = 12;
					s = 1;
					break;

					case 0x14: /* 14 ldp 2 */
					pb = 2;
					s = 1;
					break;

					case 0x15: /* 15 ldp 10 */
					pb = 10;
					s = 1;
					break;

					case 0x16: /* 16 ldp 6 */
					pb = 6;
					s = 1;
					break;

					case 0x17: /* 17 ldp 14 */
					pb = 14;
					s = 1;
					break;

					case 0x18: /* 18 ldp 1 */
					pb = 1;
					s = 1;
					break;

					case 0x19: /* 19 ldp 9 */
					pb = 9;
					s = 1;
					break;

					case 0x1a: /* 1a ldp 5 */
					pb = 5;
					s = 1;
					break;

					case 0x1b: /* 1b ldp 13 */
					pb = 13;
					s = 1;
					break;

					case 0x1c: /* 1c ldp 3 */
					pb = 3;
					s = 1;
					break;

					case 0x1d: /* 1d ldp 11 */
					pb = 11;
					s = 1;
					break;

					case 0x1e: /* 1e ldp 7 */
					pb = 7;
					s = 1;
					break;

					case 0x1f: /* 1f ldp 15 */
					pb = 15;
					s = 1;
					break;

					case 0x20: /* 20 tamiy */
					ram[x * 16 + y] = a;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x21: /* 21 tma */
					a = ram[x * 16 + y];
					s = 1;
					break;

					case 0x22: /* 22 tmy */
					y = ram[x * 16 + y];
					s = 1;
					break;

					case 0x23: /* 23 tya */
					a = y;
					s = 1;
					break;

					case 0x24: /* 24 tay */
					y = a;
					s = 1;
					break;

					case 0x25: /* 25 amaac */
					s = ((a + ram[x * 16 + y]) >= 0x10) ? 1 : 0;
					a = (a + ram[x * 16 + y]) & 0x0F;
					break;

					case 0x26: /* 26 mnez */
					s = (ram[x * 16 + y] != 0) ? 1 : 0;
					break;

					case 0x27: /* 27 saman */
					s = (a <= ram[x * 16 + y]) ? 1 : 0;
					a = (ram[x * 16 + y] - a) & 0x0F;
					break;

					case 0x28: /* 28 imac */
					s = (ram[x * 16 + y] == 15) ? 1 : 0;
					a = (ram[x * 16 + y] + 1) & 0x0F;
					break;

					case 0x29: /* 29 alem */
					s = (a <= ram[x * 16 + y]) ? 1 : 0;
					break;

					case 0x2a: /* 2a dman */
					s = (ram[x * 16 + y] == 0) ? 0 : 1;
					a = (ram[x * 16 + y] - 1) & 0x0F;
					break;

					case 0x2b: /* 2b iyc */
					s = (y == 15) ? 1 : 0;
					y = (y + 1) & 0x0F;
					break;

					case 0x2c: /* 2c dyn */
					s = (y == 0) ? 0 : 1;
					y = (y - 1) & 0x0F;
					break;

					case 0x2d: /* 2d cpaiz */
					s = (a == 0) ? 1 : 0;
					a = ((a ^ 0xF) + 1) & 0x0F;
					break;

					case 0x2e: /* 2e xma */
					temp8 = a;
					a = ram[x * 16 + y];
					ram[x * 16 + y] = temp8;
					s = 1;
					break;

					case 0x2f: /* 2f cla */
					a = 0;
					s = 1;
					break;

					case 0x30: /* 30 sbit 0 */
					ram[x * 16 + y] = ram[x * 16 + y] | (1 << 0);
					s = 1;
					break;

					case 0x31: /* 31 sbit 2 */
					ram[x * 16 + y] = ram[x * 16 + y] | (1 << 2);
					s = 1;
					break;

					case 0x32: /* 32 sbit 1 */
					ram[x * 16 + y] = ram[x * 16 + y] | (1 << 1);
					s = 1;
					break;

					case 0x33: /* 33 sbit 3 */
					ram[x * 16 + y] = ram[x * 16 + y] | (1 << 3);
					s = 1;
					break;

					case 0x34: /* 34 rbit 0 */
					ram[x * 16 + y] = ram[x * 16 + y] & ((1 << 0) ^ 0xF);
					s = 1;
					break;

					case 0x35: /* 35 rbit 2 */
					ram[x * 16 + y] = ram[x * 16 + y] & ((1 << 2) ^ 0xF);
					s = 1;
					break;

					case 0x36: /* 36 rbit 1 */
					ram[x * 16 + y] = ram[x * 16 + y] & ((1 << 1) ^ 0xF);
					s = 1;
					break;

					case 0x37: /* 37 rbit 3 */
					ram[x * 16 + y] = ram[x * 16 + y] & ((1 << 3) ^ 0xF);
					s = 1;
					break;

					case 0x38: /* 38 tbit1 0 */
					s = ((ram[x * 16 + y] & (1 << 0)) != 0) ? 1 : 0;
					break;

					case 0x39: /* 39 tbit1 2 */
					s = ((ram[x * 16 + y] & (1 << 2)) != 0) ? 1 : 0;
					break;

					case 0x3a: /* 3a tbit1 1 */
					s = ((ram[x * 16 + y] & (1 << 1)) != 0) ? 1 : 0;
					break;

					case 0x3b: /* 3b tbit1 3 */
					s = ((ram[x * 16 + y] & (1 << 3)) != 0) ? 1 : 0;
					break;

					case 0x3c: /* 3c ldx 0 */
					x = 0;
					s = 1;
					break;

					case 0x3d: /* 3d ldx 2 */
					x = 2;
					s = 1;
					break;

					case 0x3e: /* 3e ldx 1 */
					x = 1;
					s = 1;
					break;

					case 0x3f: /* 3f ldx 3 */
					x = 3;
					s = 1;
					break;

					case 0x40: /* 40 tcy 0 */
					y = 0;
					s = 1;
					break;

					case 0x41: /* 41 tcy 8 */
					y = 8;
					s = 1;
					break;

					case 0x42: /* 42 tcy 4 */
					y = 4;
					s = 1;
					break;

					case 0x43: /* 43 tcy 12 */
					y = 12;
					s = 1;
					break;

					case 0x44: /* 44 tcy 2 */
					y = 2;
					s = 1;
					break;

					case 0x45: /* 45 tcy 10 */
					y = 10;
					s = 1;
					break;

					case 0x46: /* 46 tcy 6 */
					y = 6;
					s = 1;
					break;

					case 0x47: /* 47 tcy 14 */
					y = 14;
					s = 1;
					break;

					case 0x48: /* 48 tcy 1 */
					y = 1;
					s = 1;
					break;

					case 0x49: /* 49 tcy 9 */
					y = 9;
					s = 1;
					break;

					case 0x4a: /* 4a tcy 5 */
					y = 5;
					s = 1;
					break;

					case 0x4b: /* 4b tcy 13 */
					y = 13;
					s = 1;
					break;

					case 0x4c: /* 4c tcy 3 */
					y = 3;
					s = 1;
					break;

					case 0x4d: /* 4d tcy 11 */
					y = 11;
					s = 1;
					break;

					case 0x4e: /* 4e tcy 7 */
					y = 7;
					s = 1;
					break;

					case 0x4f: /* 4f tcy 15 */
					y = 15;
					s = 1;
					break;

					case 0x50: /* 50 ynec 0 */
					s = (y != 0) ? 1 : 0;
					break;

					case 0x51: /* 51 ynec 8 */
					s = (y != 8) ? 1 : 0;
					break;

					case 0x52: /* 52 ynec 4 */
					s = (y != 4) ? 1 : 0;
					break;

					case 0x53: /* 53 ynec 12 */
					s = (y != 12) ? 1 : 0;
					break;

					case 0x54: /* 54 ynec 2 */
					s = (y != 2) ? 1 : 0;
					break;

					case 0x55: /* 55 ynec 10 */
					s = (y != 10) ? 1 : 0;
					break;

					case 0x56: /* 56 ynec 6 */
					s = (y != 6) ? 1 : 0;
					break;

					case 0x57: /* 57 ynec 14 */
					s = (y != 14) ? 1 : 0;
					break;

					case 0x58: /* 58 ynec 1 */
					s = (y != 1) ? 1 : 0;
					break;

					case 0x59: /* 59 ynec 9 */
					s = (y != 9) ? 1 : 0;
					break;

					case 0x5a: /* 5a ynec 5 */
					s = (y != 5) ? 1 : 0;
					break;

					case 0x5b: /* 5b ynec 13 */
					s = (y != 13) ? 1 : 0;
					break;

					case 0x5c: /* 5c ynec 3 */
					s = (y != 3) ? 1 : 0;
					break;

					case 0x5d: /* 5d ynec 11 */
					s = (y != 11) ? 1 : 0;
					break;

					case 0x5e: /* 5e ynec 7 */
					s = (y != 7) ? 1 : 0;
					break;

					case 0x5f: /* 5f ynec 15 */
					s = (y != 15) ? 1 : 0;
					break;

					case 0x60: /* 60 tcmiy 0 */
					ram[x * 16 + y] = 0;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x61: /* 61 tcmiy 8 */
					ram[x * 16 + y] = 8;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x62: /* 62 tcmiy 4 */
					ram[x * 16 + y] = 4;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x63: /* 63 tcmiy 12 */
					ram[x * 16 + y] = 12;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x64: /* 64 tcmiy 2 */
					ram[x * 16 + y] = 2;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x65: /* 65 tcmiy 10 */
					ram[x * 16 + y] = 10;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x66: /* 66 tcmiy 6 */
					ram[x * 16 + y] = 6;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x67: /* 67 tcmiy 14 */
					ram[x * 16 + y] = 14;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x68: /* 68 tcmiy 1 */
					ram[x * 16 + y] = 1;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x69: /* 69 tcmiy 9 */
					ram[x * 16 + y] = 9;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6a: /* 6a tcmiy 5 */
					ram[x * 16 + y] = 5;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6b: /* 6b tcmiy 13 */
					ram[x * 16 + y] = 13;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6c: /* 6c tcmiy 3 */
					ram[x * 16 + y] = 3;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6d: /* 6d tcmiy 11 */
					ram[x * 16 + y] = 11;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6e: /* 6e tcmiy 7 */
					ram[x * 16 + y] = 7;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x6f: /* 6f tcmiy 15 */
					ram[x * 16 + y] = 15;
					y = (y + 1) & 0x0F;
					s = 1;
					break;

					case 0x70: /* 70 alec 0 */
					s = (a <= 0) ? 1 : 0;
					break;

					case 0x71: /* 71 alec 8 */
					s = (a <= 8) ? 1 : 0;
					break;

					case 0x72: /* 72 alec 4 */
					s = (a <= 4) ? 1 : 0;
					break;

					case 0x73: /* 73 alec 12 */
					s = (a <= 12) ? 1 : 0;
					break;

					case 0x74: /* 74 alec 2 */
					s = (a <= 2) ? 1 : 0;
					break;

					case 0x75: /* 75 alec 10 */
					s = (a <= 10) ? 1 : 0;
					break;

					case 0x76: /* 76 alec 6 */
					s = (a <= 6) ? 1 : 0;
					break;

					case 0x77: /* 77 alec 14 */
					s = (a <= 14) ? 1 : 0;
					break;

					case 0x78: /* 78 alec 1 */
					s = (a <= 1) ? 1 : 0;
					break;

					case 0x79: /* 79 alec 9 */
					s = (a <= 9) ? 1 : 0;
					break;

					case 0x7a: /* 7a alec 5 */
					s = (a <= 5) ? 1 : 0;
					break;

					case 0x7b: /* 7b alec 13 */
					s = (a <= 13) ? 1 : 0;
					break;

					case 0x7c: /* 7c alec 3 */
					s = (a <= 3) ? 1 : 0;
					break;

					case 0x7d: /* 7d alec 11 */
					s = (a <= 11) ? 1 : 0;
					break;

					case 0x7e: /* 7e alec 7 */
					s = (a <= 7) ? 1 : 0;
					break;

					case 0x7f: /* 7f alec 15 */
					s = (a <= 15) ? 1 : 0;
					break;

					case 0x80: /* 80 br $00 */
					if (s != 0) branch1000(0x00);
					s = 1;
					break;

					case 0x81: /* 81 br $01 */
					if (s != 0) branch1000(0x01);
					s = 1;
					break;

					case 0x82: /* 82 br $02 */
					if (s != 0) branch1000(0x02);
					s = 1;
					break;

					case 0x83: /* 83 br $03 */
					if (s != 0) branch1000(0x03);
					s = 1;
					break;

					case 0x84: /* 84 br $04 */
					if (s != 0) branch1000(0x04);
					s = 1;
					break;

					case 0x85: /* 85 br $05 */
					if (s != 0) branch1000(0x05);
					s = 1;
					break;

					case 0x86: /* 86 br $06 */
					if (s != 0) branch1000(0x06);
					s = 1;
					break;

					case 0x87: /* 87 br $07 */
					if (s != 0) branch1000(0x07);
					s = 1;
					break;

					case 0x88: /* 88 br $08 */
					if (s != 0) branch1000(0x08);
					s = 1;
					break;

					case 0x89: /* 89 br $09 */
					if (s != 0) branch1000(0x09);
					s = 1;
					break;

					case 0x8a: /* 8a br $0a */
					if (s != 0) branch1000(0x0a);
					s = 1;
					break;

					case 0x8b: /* 8b br $0b */
					if (s != 0) branch1000(0x0b);
					s = 1;
					break;

					case 0x8c: /* 8c br $0c */
					if (s != 0) branch1000(0x0c);
					s = 1;
					break;

					case 0x8d: /* 8d br $0d */
					if (s != 0) branch1000(0x0d);
					s = 1;
					break;

					case 0x8e: /* 8e br $0e */
					if (s != 0) branch1000(0x0e);
					s = 1;
					break;

					case 0x8f: /* 8f br $0f */
					if (s != 0) branch1000(0x0f);
					s = 1;
					break;

					case 0x90: /* 90 br $10 */
					if (s != 0) branch1000(0x10);
					s = 1;
					break;

					case 0x91: /* 91 br $11 */
					if (s != 0) branch1000(0x11);
					s = 1;
					break;

					case 0x92: /* 92 br $12 */
					if (s != 0) branch1000(0x12);
					s = 1;
					break;

					case 0x93: /* 93 br $13 */
					if (s != 0) branch1000(0x13);
					s = 1;
					break;

					case 0x94: /* 94 br $14 */
					if (s != 0) branch1000(0x14);
					s = 1;
					break;

					case 0x95: /* 95 br $15 */
					if (s != 0) branch1000(0x15);
					s = 1;
					break;

					case 0x96: /* 96 br $16 */
					if (s != 0) branch1000(0x16);
					s = 1;
					break;

					case 0x97: /* 97 br $17 */
					if (s != 0) branch1000(0x17);
					s = 1;
					break;

					case 0x98: /* 98 br $18 */
					if (s != 0) branch1000(0x18);
					s = 1;
					break;

					case 0x99: /* 99 br $19 */
					if (s != 0) branch1000(0x19);
					s = 1;
					break;

					case 0x9a: /* 9a br $1a */
					if (s != 0) branch1000(0x1a);
					s = 1;
					break;

					case 0x9b: /* 9b br $1b */
					if (s != 0) branch1000(0x1b);
					s = 1;
					break;

					case 0x9c: /* 9c br $1c */
					if (s != 0) branch1000(0x1c);
					s = 1;
					break;

					case 0x9d: /* 9d br $1d */
					if (s != 0) branch1000(0x1d);
					s = 1;
					break;

					case 0x9e: /* 9e br $1e */
					if (s != 0) branch1000(0x1e);
					s = 1;
					break;

					case 0x9f: /* 9f br $1f */
					if (s != 0) branch1000(0x1f);
					s = 1;
					break;

					case 0xa0: /* a0 br $20 */
					if (s != 0) branch1000(0x20);
					s = 1;
					break;

					case 0xa1: /* a1 br $21 */
					if (s != 0) branch1000(0x21);
					s = 1;
					break;

					case 0xa2: /* a2 br $22 */
					if (s != 0) branch1000(0x22);
					s = 1;
					break;

					case 0xa3: /* a3 br $23 */
					if (s != 0) branch1000(0x23);
					s = 1;
					break;

					case 0xa4: /* a4 br $24 */
					if (s != 0) branch1000(0x24);
					s = 1;
					break;

					case 0xa5: /* a5 br $25 */
					if (s != 0) branch1000(0x25);
					s = 1;
					break;

					case 0xa6: /* a6 br $26 */
					if (s != 0) branch1000(0x26);
					s = 1;
					break;

					case 0xa7: /* a7 br $27 */
					if (s != 0) branch1000(0x27);
					s = 1;
					break;

					case 0xa8: /* a8 br $28 */
					if (s != 0) branch1000(0x28);
					s = 1;
					break;

					case 0xa9: /* a9 br $29 */
					if (s != 0) branch1000(0x29);
					s = 1;
					break;

					case 0xaa: /* aa br $2a */
					if (s != 0) branch1000(0x2a);
					s = 1;
					break;

					case 0xab: /* ab br $2b */
					if (s != 0) branch1000(0x2b);
					s = 1;
					break;

					case 0xac: /* ac br $2c */
					if (s != 0) branch1000(0x2c);
					s = 1;
					break;

					case 0xad: /* ad br $2d */
					if (s != 0) branch1000(0x2d);
					s = 1;
					break;

					case 0xae: /* ae br $2e */
					if (s != 0) branch1000(0x2e);
					s = 1;
					break;

					case 0xaf: /* af br $2f */
					if (s != 0) branch1000(0x2f);
					s = 1;
					break;

					case 0xb0: /* b0 br $30 */
					if (s != 0) branch1000(0x30);
					s = 1;
					break;

					case 0xb1: /* b1 br $31 */
					if (s != 0) branch1000(0x31);
					s = 1;
					break;

					case 0xb2: /* b2 br $32 */
					if (s != 0) branch1000(0x32);
					s = 1;
					break;

					case 0xb3: /* b3 br $33 */
					if (s != 0) branch1000(0x33);
					s = 1;
					break;

					case 0xb4: /* b4 br $34 */
					if (s != 0) branch1000(0x34);
					s = 1;
					break;

					case 0xb5: /* b5 br $35 */
					if (s != 0) branch1000(0x35);
					s = 1;
					break;

					case 0xb6: /* b6 br $36 */
					if (s != 0) branch1000(0x36);
					s = 1;
					break;

					case 0xb7: /* b7 br $37 */
					if (s != 0) branch1000(0x37);
					s = 1;
					break;

					case 0xb8: /* b8 br $38 */
					if (s != 0) branch1000(0x38);
					s = 1;
					break;

					case 0xb9: /* b9 br $39 */
					if (s != 0) branch1000(0x39);
					s = 1;
					break;

					case 0xba: /* ba br $3a */
					if (s != 0) branch1000(0x3a);
					s = 1;
					break;

					case 0xbb: /* bb br $3b */
					if (s != 0) branch1000(0x3b);
					s = 1;
					break;

					case 0xbc: /* bc br $3c */
					if (s != 0) branch1000(0x3c);
					s = 1;
					break;

					case 0xbd: /* bd br $3d */
					if (s != 0) branch1000(0x3d);
					s = 1;
					break;

					case 0xbe: /* be br $3e */
					if (s != 0) branch1000(0x3e);
					s = 1;
					break;

					case 0xbf: /* bf br $3f */
					if (s != 0) branch1000(0x3f);
					s = 1;
					break;

					case 0xc0: /* c0 call $00 */
					if (s != 0) call1000(0x00);
					s = 1;
					break;

					case 0xc1: /* c1 call $01 */
					if (s != 0) call1000(0x01);
					s = 1;
					break;

					case 0xc2: /* c2 call $02 */
					if (s != 0) call1000(0x02);
					s = 1;
					break;

					case 0xc3: /* c3 call $03 */
					if (s != 0) call1000(0x03);
					s = 1;
					break;

					case 0xc4: /* c4 call $04 */
					if (s != 0) call1000(0x04);
					s = 1;
					break;

					case 0xc5: /* c5 call $05 */
					if (s != 0) call1000(0x05);
					s = 1;
					break;

					case 0xc6: /* c6 call $06 */
					if (s != 0) call1000(0x06);
					s = 1;
					break;

					case 0xc7: /* c7 call $07 */
					if (s != 0) call1000(0x07);
					s = 1;
					break;

					case 0xc8: /* c8 call $08 */
					if (s != 0) call1000(0x08);
					s = 1;
					break;

					case 0xc9: /* c9 call $09 */
					if (s != 0) call1000(0x09);
					s = 1;
					break;

					case 0xca: /* ca call $0a */
					if (s != 0) call1000(0x0a);
					s = 1;
					break;

					case 0xcb: /* cb call $0b */
					if (s != 0) call1000(0x0b);
					s = 1;
					break;

					case 0xcc: /* cc call $0c */
					if (s != 0) call1000(0x0c);
					s = 1;
					break;

					case 0xcd: /* cd call $0d */
					if (s != 0) call1000(0x0d);
					s = 1;
					break;

					case 0xce: /* ce call $0e */
					if (s != 0) call1000(0x0e);
					s = 1;
					break;

					case 0xcf: /* cf call $0f */
					if (s != 0) call1000(0x0f);
					s = 1;
					break;

					case 0xd0: /* d0 call $10 */
					if (s != 0) call1000(0x10);
					s = 1;
					break;

					case 0xd1: /* d1 call $11 */
					if (s != 0) call1000(0x11);
					s = 1;
					break;

					case 0xd2: /* d2 call $12 */
					if (s != 0) call1000(0x12);
					s = 1;
					break;

					case 0xd3: /* d3 call $13 */
					if (s != 0) call1000(0x13);
					s = 1;
					break;

					case 0xd4: /* d4 call $14 */
					if (s != 0) call1000(0x14);
					s = 1;
					break;

					case 0xd5: /* d5 call $15 */
					if (s != 0) call1000(0x15);
					s = 1;
					break;

					case 0xd6: /* d6 call $16 */
					if (s != 0) call1000(0x16);
					s = 1;
					break;

					case 0xd7: /* d7 call $17 */
					if (s != 0) call1000(0x17);
					s = 1;
					break;

					case 0xd8: /* d8 call $18 */
					if (s != 0) call1000(0x18);
					s = 1;
					break;

					case 0xd9: /* d9 call $19 */
					if (s != 0) call1000(0x19);
					s = 1;
					break;

					case 0xda: /* da call $1a */
					if (s != 0) call1000(0x1a);
					s = 1;
					break;

					case 0xdb: /* db call $1b */
					if (s != 0) call1000(0x1b);
					s = 1;
					break;

					case 0xdc: /* dc call $1c */
					if (s != 0) call1000(0x1c);
					s = 1;
					break;

					case 0xdd: /* dd call $1d */
					if (s != 0) call1000(0x1d);
					s = 1;
					break;

					case 0xde: /* de call $1e */
					if (s != 0) call1000(0x1e);
					s = 1;
					break;

					case 0xdf: /* df call $1f */
					if (s != 0) call1000(0x1f);
					s = 1;
					break;

					case 0xe0: /* e0 call $20 */
					if (s != 0) call1000(0x20);
					s = 1;
					break;

					case 0xe1: /* e1 call $21 */
					if (s != 0) call1000(0x21);
					s = 1;
					break;

					case 0xe2: /* e2 call $22 */
					if (s != 0) call1000(0x22);
					s = 1;
					break;

					case 0xe3: /* e3 call $23 */
					if (s != 0) call1000(0x23);
					s = 1;
					break;

					case 0xe4: /* e4 call $24 */
					if (s != 0) call1000(0x24);
					s = 1;
					break;

					case 0xe5: /* e5 call $25 */
					if (s != 0) call1000(0x25);
					s = 1;
					break;

					case 0xe6: /* e6 call $26 */
					if (s != 0) call1000(0x26);
					s = 1;
					break;

					case 0xe7: /* e7 call $27 */
					if (s != 0) call1000(0x27);
					s = 1;
					break;

					case 0xe8: /* e8 call $28 */
					if (s != 0) call1000(0x28);
					s = 1;
					break;

					case 0xe9: /* e9 call $29 */
					if (s != 0) call1000(0x29);
					s = 1;
					break;

					case 0xea: /* ea call $2a */
					if (s != 0) call1000(0x2a);
					s = 1;
					break;

					case 0xeb: /* eb call $2b */
					if (s != 0) call1000(0x2b);
					s = 1;
					break;

					case 0xec: /* ec call $2c */
					if (s != 0) call1000(0x2c);
					s = 1;
					break;

					case 0xed: /* ed call $2d */
					if (s != 0) call1000(0x2d);
					s = 1;
					break;

					case 0xee: /* ee call $2e */
					if (s != 0) call1000(0x2e);
					s = 1;
					break;

					case 0xef: /* ef call $2f */
					if (s != 0) call1000(0x2f);
					s = 1;
					break;

					case 0xf0: /* f0 call $30 */
					if (s != 0) call1000(0x30);
					s = 1;
					break;

					case 0xf1: /* f1 call $31 */
					if (s != 0) call1000(0x31);
					s = 1;
					break;

					case 0xf2: /* f2 call $32 */
					if (s != 0) call1000(0x32);
					s = 1;
					break;

					case 0xf3: /* f3 call $33 */
					if (s != 0) call1000(0x33);
					s = 1;
					break;

					case 0xf4: /* f4 call $34 */
					if (s != 0) call1000(0x34);
					s = 1;
					break;

					case 0xf5: /* f5 call $35 */
					if (s != 0) call1000(0x35);
					s = 1;
					break;

					case 0xf6: /* f6 call $36 */
					if (s != 0) call1000(0x36);
					s = 1;
					break;

					case 0xf7: /* f7 call $37 */
					if (s != 0) call1000(0x37);
					s = 1;
					break;

					case 0xf8: /* f8 call $38 */
					if (s != 0) call1000(0x38);
					s = 1;
					break;

					case 0xf9: /* f9 call $39 */
					if (s != 0) call1000(0x39);
					s = 1;
					break;

					case 0xfa: /* fa call $3a */
					if (s != 0) call1000(0x3a);
					s = 1;
					break;

					case 0xfb: /* fb call $3b */
					if (s != 0) call1000(0x3b);
					s = 1;
					break;

					case 0xfc: /* fc call $3c */
					if (s != 0) call1000(0x3c);
					s = 1;
					break;

					case 0xfd: /* fd call $3d */
					if (s != 0) call1000(0x3d);
					s = 1;
					break;

					case 0xfe: /* fe call $3e */
					if (s != 0) call1000(0x3e);
					s = 1;
					break;

					case 0xff: /* ff call $3f */
					if (s != 0) call1000(0x3f);
					s = 1;
					break;

			}
		}
	}
}
