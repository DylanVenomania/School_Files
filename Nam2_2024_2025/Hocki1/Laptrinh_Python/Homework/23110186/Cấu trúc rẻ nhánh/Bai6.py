# Tôn Hoàng Cầm 23110186 
arr = []
for i in range(5):
    arr = arr + [float(input())]
max = arr[0]
min = arr[0]
for i in range(5):
    if(arr[i] > max):
        max = arr[i]
    elif(arr[i] < min):
        min = arr[i]
print("MAX = ", max)
print("MIN = ", min)