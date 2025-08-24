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


for i in range(n-1):
    for j in range(i+1, n):
        if(lst[i] < 0):
            if(lst[j] < 0 and lst[j] > lst[i] ):
                  lst[i], lst[j] = lst[j] , lst[i]
print(lst)


