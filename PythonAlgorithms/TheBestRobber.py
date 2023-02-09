n, v = map(int, input().split())
earned = 0.0
l = list()
for i in range(n):
    a, b = map(int, input().split())
    l.append((a, b))
l.sort(key = lambda x: x[0] / x[1], reverse=True)

while v != 0 and len(l)!=0:
    print(len(l))
    valueM = l[0][1]
    costM = l[0][0]
    if v >= valueM:
        earned += costM
        v -= valueM
    else:
        earned += (v / valueM) * costM
        v = 0
    l.pop(0)
print(earned)





