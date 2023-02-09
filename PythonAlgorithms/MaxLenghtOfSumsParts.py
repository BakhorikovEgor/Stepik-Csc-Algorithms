n = int(input())
k = 0

tmp = 0
parts = []
for i in range(1, n):
    k += 1
    tmp += i
    parts.append(i)
    if n == tmp:
        break
    if tmp+i+1 > n:
        parts[i-1]+=n-tmp
        break

if n == 1:
    print(1)
    print(1)
else:
    print(k)
    for i in parts:
        print(i,end = " ")
