import sys
n = int(input("Nhập số lượng phần tử trong list : "))
while(n < 0):
    n = int(input("Không hợp lệ, vui lòng nhập lại : "))
if( n == 0):
    print("List rỗng !")
    sys.exit()

lst= []
print("Nhập các giá trị cho list : ")
for i in range(n):
    tempt = float(input())
    lst.append(tempt)

if(lst[0] > lst[1]):
    min, max = lst[1], lst[0]
else:
    min, max = lst[0], lst[1]

for i in range(2,n-1):
    if lst[i] > max:
        if(lst[i] > lst[i+1] ):
            max = lst[i]
        else:
            max = lst[i+1]
    if lst[i] < min:
        if(lst[i] < lst[i+1] ):
            min = lst[i]
        else:
            min = lst[i+1]

print("Max của list là :",max)
print("Min của list là :",min)