import sys
n = int(input("Nhập số lượng phần tử trong list : "))
while(n < 0):
    n = int(input("Không hợp lệ, vui lòng nhập lại : "))
if( n == 0):
    print("List rỗng !")
    sys.exit()

lst = []
print("Nhập các giá trị cho list : ")
for i in range(n):
    tempt = float(input())
    lst.append(tempt)

k = int(input("Tìm giá trị âm thứ k, nhập vào k bạn muốn: "))
while(k <= 0):
    j = int(input("Không hợp lệ, vui lòng nhập lại : "))

def negative(so):
    return so < 0

thutu = 0
for i in range(n):
    if(negative(lst[i])):
       thutu += 1
       if(thutu == k):
           print("Số âm thứ",k,"là: ", lst[i])
           break
else:
    print("Không tìm thấy số âm thứ", k, "trong list: ")