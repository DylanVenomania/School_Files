#Tôn Hoàng Cầm 23110186
import string
so = str(input("Nhập vào 1 số nguyên dương : "))
while( int(so) <= 0 ):
    so = str(input("Vui lòng nhập lại : "))
tong = 0
for i in range(len(so)):
    tong = tong + int(so[i])
print(tong)