k,l = map(int,input().split())
d = dict()


for i in range(k):
    inp = input().split(":")
    letter = inp[0]
    value = inp[1][1:]
    d[value] = letter

s = input()
answer = ''
temp = ''

for symb in s:
    temp+=symb
    if temp in d.keys():
        answer+=d[temp]
        temp = ''

print(answer)



