def process(s):
	n = s.find(";")
	if n > 0:
		left = s[:n]+(" " * 64)
		s = left[:32]+s[n:]
	return s

f = open("revenge.txt")
code = f.readlines()
f.close()
code = [process(c.rstrip()) for c in code]
print("\n".join(code))