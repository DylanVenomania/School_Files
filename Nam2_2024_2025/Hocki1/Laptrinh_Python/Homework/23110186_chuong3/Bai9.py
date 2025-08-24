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
lst.sort()
print("List sau khi sắp xếp tăng dần : ", lst)