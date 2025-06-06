# Tôn Hoàng Cầm 23110186 
arr = []
print("Nhập vào 3 số nguyên : ")
for i in range(3):
    arr = arr + [int(input())]

min = arr[0]
for i in range(3):
    if(arr[i] < min):
        min = arr[i]

max = min
for i in range(3):
    if(arr[i] > max):
        hang2 = max
        max = arr[i]
print("Số lớn thứ nhì trong 3 số là : ", hang2)