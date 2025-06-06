import sys
n = int(input("Nhập vào số lượng phần tử cho một list : "))
while(n < 0):
    n = int(input("Số lượng không hợp lệ, xin nhập lại : "))
if(n == 0):
    print("List rỗng !")
    sys.exit()

lst = []
print("Nhập các giá trị cho list : ")
for i in range(n):
    temp = float(input())
    lst.append(temp)

for i in range(n):
    if(lst[i] < 0):
        print("vị trí phần tử âm đầu tiên là : " , i+1 )
        break
else:
    print("Không có phần tử âm trong list!")
