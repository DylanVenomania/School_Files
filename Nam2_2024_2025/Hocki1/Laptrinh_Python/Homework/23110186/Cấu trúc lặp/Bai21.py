#Tôn Hoàng Cầm 23110186
import math
N = int(input("Nhập vào một số nguyên dương : "))

def nguyento(so):
    if(so == 2):
        return True
    for i in range( 2, so):
        if(so % i == 0):
            return False
    return True

arr = []
soluong = 0
giatri = 2
while( soluong < N):
    if(nguyento(giatri)):
        arr = arr + [giatri]
        soluong += 1
    giatri += 1

print("List gồm",N,"số nguyên tố đầu tiên :", arr)