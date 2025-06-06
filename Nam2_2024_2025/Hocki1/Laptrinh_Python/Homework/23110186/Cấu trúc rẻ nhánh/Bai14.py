# Tôn Hoàng Cầm 23110186 
arr = []
print("Nhập vào 3 số nguyên : ")
for i in range(3):
    arr = arr + [int(input())]
def sochan(so):
    if (so % 2 == 0):
        return True
    return False
def xetchan():
    for i in range(3):
        if( sochan(arr[i])):
            return True
    return False

if( not(xetchan())):
    print("Không có số nguyên chẵn nào !")
else:
    for i in range(3):
        if( sochan(arr[i]) ):
            max = arr[i]
            break
    for i in range(3):
        if( sochan(arr[i]) and arr[i] > max):
            max = arr[i]
print("Số chẵn nguyên lớn nhất trong 3 số là : ", max)