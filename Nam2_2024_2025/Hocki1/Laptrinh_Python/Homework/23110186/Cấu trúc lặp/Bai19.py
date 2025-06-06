#Tôn Hoàng Cầm 23110186
import random
n = int(input("Nhập số lượng phần tử trong list : "))
A = float(input("Nhập số thực A để loại bỏ các phần tử lớn hơn A : "))
arr = [round( random.uniform(1.0 , 1000.0) ,2) for _ in range(n)]
print(arr)
i = 0
while (i < len(arr)):
    if(arr[i] > A):
        del arr[i]
    else:
        i += 1
print(arr)