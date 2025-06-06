#Tôn Hoàng Cầm 23110186
import random
n = int(input("Nhập vào số lượng phần tử mảng : "))
arr = [random.randint(1, 1000) for i in range(n) ]
for i in range(n):
    print(arr[i], end = "   ")
def chia_5(so):
    if(so % 5 == 0):
       return True
    return False
def xacnhan():
    for i in range(n):
        if(chia_5(arr[i])):
            return True
    return False

for i in range(n):
    if( chia_5(arr[i])):
       max = arr[i]

if( not(xacnhan()) ):
    print("\nDãy số không có số chia hết cho 5 : ")
else:
    for i in range(n):
        if( chia_5(arr[i]) and arr[i] > max):
            max = arr[i]
print("\nSố chia hết cho 5 mà lớn nhất là : ", max)
