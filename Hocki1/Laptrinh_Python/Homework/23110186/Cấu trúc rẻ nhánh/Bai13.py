# Tôn Hoàng Cầm 23110186 
arr = []
print("Nhập vào 3 số nguyên : ")
for i in range(3):
    arr = arr + [int(input())]
for i in range(3):
    if(arr[i] > 0):
        min = arr[i]
        break
for i in range(3):
    if(arr[i] > 0 and arr[i] < min):
        min = arr[i]
print(min)   