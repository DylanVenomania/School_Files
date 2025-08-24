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

num = float(input("Nhập vào giá trị muốn xoá trong list : "))
temp = []
for i in range(n):
    if(lst[i] != num):
        temp.append(lst[i])
if(len(temp) == len(lst)):
    print("Không có phần tử", num, "trong list!")
else:
    print("List sau khi xoá phần tử", num, ": ", temp)