# Tôn Hoàng Cầm 23110186 
arr = []
for i in range(5):
    arr = arr+ [float(input())]
am = 0
duong = 0
khong = 0
for i in range(5):
    if(arr[i] > 0):
        duong += 1
    elif(arr[i] < 0):
        am += 1
    else:
        khong += 1
print("Số lượng số dương : ", duong)
print("Số lượng số âm : ", am)
print("Số lượng số không : ", khong)