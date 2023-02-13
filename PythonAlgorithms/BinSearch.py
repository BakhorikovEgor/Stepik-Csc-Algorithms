
def BinarySearch(seq,left,right, key):
    middle = (right+left)//2

    if right-left == 1 and seq[middle] != key:
        return "-1"

    if seq[middle] == key:
        return str(middle+1)
    elif seq[middle] > key:
        return BinarySearch(seq,left,middle,key)
    else:
        return BinarySearch(seq,middle,right,key)


mainSeq = [int(i) for i in input().split()[1:]]
checkSeq = [int(i) for i in input().split()[1:]]
output = ""

for element in checkSeq:
    output += BinarySearch(mainSeq,0,len(mainSeq),element) + " "

print(output[:-1])


