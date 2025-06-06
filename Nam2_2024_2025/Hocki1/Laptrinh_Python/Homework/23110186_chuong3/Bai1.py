import sys
n = int(input("Nhập vào số lượng phần tử cho một list : "))
while(n < 0):
    n = int(input("Không hợp lệ, vui lòng nhập lại : "))
if(n == 0):
    print("List rỗng !")
    sys.exit()

lst = []
print("Nhập các giá trị cho list : ")
sum = 0
for i in range(n):
    tempt = float(input())
    lst.append(tempt)
    sum += tempt
print("Tổng các phần tử trong list = ", sum)