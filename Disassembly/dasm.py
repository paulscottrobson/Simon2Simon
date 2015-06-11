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
	mnemonics[0x40+i] = "tcy   ${0:x}".format(bitReverse[i])
	mnemonics[0x50+i] = "ynec  ${0:x}".format(bitReverse[i])
	mnemonics[0x60+i] = "tcmiy ${0:x}".format(bitReverse[i])
	mnemonics[0x70+i] = "alec  ${0:x}".format(bitReverse[i])
#
#	Instructions with 2 bit commands
#
for i in range(0,4):
	param = i if i == 0 or i == 3 else 3 - i
	mnemonics[0x30+i] = "sbit  ${0:x}".format(param)
	mnemonics[0x34+i] = "rbit  ${0:x}".format(param)
	mnemonics[0x38+i] = "tbit1 ${0:x}".format(param)
	mnemonics[0x3C+i] = "ldx   ${0:x}".format(param)
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

for page in range(0,16):
	pc = page * 64
	for inst in range(0,64):
		x = "{0:03x} {1:02x} {2}".format(pc,simon[pc],mnemonics[simon[pc]])
		print(x)
		pc = page * 64 + tmsNextPC[pc % 64]
print(len(tmsNextPC))