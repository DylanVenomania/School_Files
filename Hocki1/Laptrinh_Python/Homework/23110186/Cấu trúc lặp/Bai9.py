#Tôn Hoàng Cầm 23110186
def xet(so):
    if(so == 0):
        print("Không hợp lệ !")
        return 0
    
tu = int(input("Nhập tử: "))
xet(tu)
mau = int(input("Nhập mẫu : "))
xet(mau)

while(tu != 0 and mau != 0):
    print( (tu/mau))
    tu = int(input("Nhập tử : "))
    xet(tu)
    xet(mau)


