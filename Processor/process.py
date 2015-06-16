#
#	Processor
#
def process(s,op):
	r2 = [0,2,1,3]
	r4 = [ 0x00, 0x08, 0x04, 0x0C, 0x02, 0x0A, 0x06, 0x0E, 0x01, 0x09, 0x05, 0x0D, 0x03, 0x0B, 0x07, 0x0F ]
	s = s.replace("$2",str(r2[op % 4]))
	s = s.replace("$4",str(r4[op % 16]))
	s = s.replace("$6","0x{0:02x}".format(op % 64))
	s = s.replace("$MEM","ram[x*16+y]")
	return s

def formatCode(s):
	s = ["    "+c.strip()+";" for c in s.split(";")]
	s = [c for c in s if c != ""]
	return "\n".join(s)

import re

code = open("tms1000.def").readlines()											# read file.
code = [c if c.find("//") < 0 else c[:c.find("//")] for c in code] 				# remove comments.
code = [c.strip().replace("\t"," ") for c in code]								# remove leading trailing spaces and tabs
code = [c for c in code if c != ""]												# remove blank lines

mnemonics = [ None ] * 256														# Contains mnemonics
genCode = [ None ] * 256														# Contains generated code

for line in code:
	m = re.match("^([0-9A-F\-]+)\s+\"([0-9a-zA-Z\s\$]+)\"\s+(.*)$",line)		# split into components
	assert m is not None 														# check we matched.
	opRange = m.group(1)														# get opcode opRange or value
	if len(opRange) == 2:														# expand one value to a opRange.
		opRange = opRange + "-" + opRange
	opcode = int(opRange[:2],16)												# First opcode
	lastOpcode = int(opRange[-2:],16)											# Last opcode

	while opcode <= lastOpcode:													# Work through all opcodes.
		assert mnemonics[opcode] is None
		mnemonics[opcode] = process(m.group(2),opcode).replace(" 0x"," $")
		genCode[opcode] = process(m.group(3),opcode)+";"
		if genCode[opcode].find("s = ") < 0:
			genCode[opcode] = genCode[opcode] + " s = 1;"
		opcode = opcode + 1

open("mnemonics.txt","w").write(",".join(['"'+m+'"' for m in mnemonics]))		# output mnemonics list

handle = open("interpreter.txt","w")
for n in range(0,256):
	assert mnemonics[n] is not None
	handle.write("\ncase 0x{0:02x}: /* {0:02x} {1} */\n".format(n,mnemonics[n]))
	handle.write(formatCode(genCode[n]+"break")+"\n")