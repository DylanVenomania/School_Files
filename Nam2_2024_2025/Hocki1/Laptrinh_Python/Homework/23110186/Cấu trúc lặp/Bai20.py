#Tôn Hoàng Cầm 23110186
import random
n = int(input("Nhập số lượng phần tử trong list : "))
B = float(input("Nhập số thực B để chèn vào list : "))
arr = [round( random.uniform(1.0 , 1000.0) ,2) for _ in range(n)]
print(arr)

for i in range(n):
    for j in range(i+1, n):
         if(arr[j] < arr[i]):
            temp = arr[j]
            arr[j] = arr[i]
            arr[i] = temp
print(arr)

pos = 0
for i in range(n):
    if(arr[i] < B):
        pos += 1

arr.insert(pos, B)
print("List sau khi chèn : \n",arr)
