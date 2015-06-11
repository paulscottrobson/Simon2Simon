#
#	Bit Reverse for 4 bit operands.
#
bitReverse =  [ 0,8,4,12,2,10,6,14,1,9,5,13,3,11,7,15 ]
#
#	Array of Mnemonics. We do not analyse LDP ($3X) BR ($80-$BF) and CALL ($C0-$FF)
#
mnemonics = [""] * 128
#
#	Instructions with 4 bit operands.
#
for i in range(0,16):
	mnemonics[0x10+i] = "ldp   {0}".format(bitReverse[i])
	mnemonics[0x40+i] = "tcy   {0}".format(bitReverse[i])
	mnemonics[0x50+i] = "ynec  {0}".format(bitReverse[i])
	mnemonics[0x60+i] = "tcmiy {0}".format(bitReverse[i])
	mnemonics[0x70+i] = "alec  {0}".format(bitReverse[i])
#
#	Instructions with 2 bit commands
#
for i in range(0,4):
	param = i if i == 0 or i == 3 else 3 - i
	mnemonics[0x30+i] = "sbit  {0}".format(param)
	mnemonics[0x34+i] = "rbit  {0}".format(param)
	mnemonics[0x38+i] = "tbit1 {0}".format(param)
	mnemonics[0x3C+i] = "ldx   {0}".format(param)
#
#	Stand alone instructions.
#
list1 = "comx,a8aac,ynea,tam,tamza,a10aac,a8aac,dan,tka,knez,tdo,clo,rstr,setr,ia,retn".split(",")
list2 = "tamiy,tma,tmy,tya,tay,amaac,mnez,saman,imac,alem,dman,iyc,dyn,cpaiz,xma,cla".split(",")
for i in range(0,16):
	mnemonics[0x00+i] = list1[i]
	mnemonics[0x20+i] = list2[i]
#
#	For any given value of PC, this points to the next PC value.
#
tmsNextPC = [ 0x01, 0x03, 0x05, 0x07, 0x09, 0x0B, 0x0D, 0x0F, 0x11, 0x13, 0x15, 0x17, 0x19, 0x1B, 0x1D, 0x1F, 0x20, 0x22, 0x24, 0x26, 0x28, 0x2A, 0x2C, 0x2E, 0x30, 0x32, 0x34, 0x36, 0x38, 0x3A, 0x3C, 0x3F, 0x00, 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10, 0x12, 0x14, 0x16, 0x18, 0x1A, 0x1C, 0x1E, 0x21, 0x23, 0x25, 0x27, 0x29, 0x2B, 0x2D, 0x2F, 0x31, 0x33, 0x35, 0x37, 0x39, 0x3B, 0x3D, 0x3E ]
#
#	Read in the Simon Binary.
#
simon = []
simonFile = open("simon.bin","rb")
for i in range(0,1024):
	simon.append(ord(simonFile.read(1)))
#
#	Disassembly.
#
disasm = []
isLabel = [False] * 1024
isLabel[0x3C0] = True

for page in range(0,16):
	pageAddress = page * 64
	programCounter = 0
	processCount = 64
	while processCount > 0:
		opcode = simon[pageAddress+programCounter]
		line = [pageAddress + programCounter,"${0:03x}: ${1:02x}".format(pageAddress+programCounter,opcode),"" ] 

		if opcode >= 0x10 and opcode < 0x20:
			nextAddress = tmsNextPC[programCounter]
			nextInstr = simon[pageAddress+nextAddress]
			line[1] = "{0} ${1:02x}".format(line[1],nextInstr)
			longPage = bitReverse[opcode % 16] * 64
			line[2] = "x{0} L{1:03x}".format("br  " if nextInstr < 0xC0 else "call",longPage+nextInstr % 64)
			isLabel[longPage+nextInstr%64] = True
			disasm.append(line)
			programCounter = tmsNextPC[programCounter]
			programCounter = tmsNextPC[programCounter]
			processCount = processCount - 2
		elif opcode >= 0x80:
			line[2] = "{0}  L{1:03x}".format("br  " if opcode < 0xC0 else "call",pageAddress+opcode % 64)
			isLabel[pageAddress+opcode % 64] = True
			disasm.append(line)
			programCounter = tmsNextPC[programCounter]
			processCount = processCount - 1
		else:
			line[2] = mnemonics[opcode]
			disasm.append(line)
			programCounter = tmsNextPC[programCounter]
			processCount = processCount - 1

for l in disasm:
	if l[0] % 64 == 0:
		print("; *******************************************************")
		print(";                       Page {0}".format(int(l[0]/64)))
		print("; *******************************************************")
	if isLabel[l[0]]:
		print(".L{0:03x}".format(l[0]))
	print("\t{0:16} ; {1:16} // ".format(l[2],l[1]))