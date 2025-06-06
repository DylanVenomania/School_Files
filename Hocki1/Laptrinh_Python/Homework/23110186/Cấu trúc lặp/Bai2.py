#Tôn Hoàng Cầm 23110186
import math
so = int( input("Nhập vào một số nguyên : ") )
def xetchinhphuong(so):
    if( math.sqrt(so) == int(math.sqrt(so))):
        return True
    return False
so_lonhon = so + 1
so_nhohon = so - 1

if(xetchinhphuong(so)):
    print("Số ", so, " là số chính phương !")
else:
    print("Số ", so, " không là số chính phương!")
    while( not(xetchinhphuong(so_lonhon)) ):
        so_lonhon += 1
    while( not(xetchinhphuong(so_nhohon)) ):
        so_nhohon -= 1
    if(so_lonhon - so > so - so_nhohon):
        print("Số chính phương gần với ", so ," nhất là: ", so_lonhon)
    else:
        print("Số chính phương gần với ", so ," nhất là: ", so_nhohon)
