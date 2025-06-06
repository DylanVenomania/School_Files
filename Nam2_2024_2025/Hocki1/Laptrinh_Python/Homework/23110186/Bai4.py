bienso_real = int(input())
bienso = bienso_real
while (bienso > 99999 or bienso < 10000):
    bienso = int(input('Vui lòng nhập lại : '))

tong = 0
while(bienso != 0):
    tong = tong + bienso % 10
    bienso = bienso // 10
if( tong >= 10):
    nut = tong % 10
else:
    nut = tong
print( nut)
