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

k = float(input("Nhập giá trị phần tử muốn xoá trong list: "))
while k in lst:
    lst.remove(k)
if(len(lst) != n):
    print(k, " có trong list !")
else:
    print(k, " không có trong list!")
    
print("List sau khi xoá", k, ": ", lst)