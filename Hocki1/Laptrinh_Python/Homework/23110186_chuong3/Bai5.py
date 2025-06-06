import sys
n = int(input("Nhập số lượng phần tử trong list : "))
while(n < 0):
    n = int(input("Không hợp lệ, vui lòng nhập lại : "))
if( n == 0):
    print("List rỗng !")
    sys.exit()

lst = []
lst_chan = []
lst_le = []
print("Nhập các giá trị nguyên cho list : ")
for i in range(n):
    temp = int(input())
    lst.append(temp)
    if(temp % 2 == 0):
        lst_chan.append(temp)
    else:
        lst_le.append(temp)
print("List chan : ", lst_chan)
print("List le : ", lst_le)

