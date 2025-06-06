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
    tempt = int(input())
    lst.append(tempt)

lst_uoc = []
lst_boi = []
k = int(input("Nhập số nguyên k để tìm ước và bội của k trong list : "))
for i in range(n):
    if(k % lst[i] == 0):
        lst_uoc.append(lst[i])
    if(lst[i] % k == 0):
        lst_boi.append(lst[i])
if not lst_uoc :
    print("Không có ước của số", k, "trong list !")
else:
    print("Ước của số", k, "trong list là:", lst_uoc)
if not lst_boi :
    print("Không có bội của số", k, "trong list !")
else:
    print("Bội của số", k, "trong list là:", lst_boi)
