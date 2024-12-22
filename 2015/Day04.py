import hashlib
number = 0
key = ""
while key.startswith("000000") is False:
    if key.startswith("00000"): print(number)
    number += 1
    key = hashlib.md5(("" + str(number)).encode('utf-8')).hexdigest()
print(number)