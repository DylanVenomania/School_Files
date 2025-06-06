phicoso = 4
def tien(quangduong):
    global phicoso
    giatien = float( phicoso + 0.25*( ( quangduong*1000) //140) )
    return giatien

quangduong = int(input("Nhap vao quang duong (km) di taxi : "))
print("So tien phai tra sau khi di taxi quang duong ",quangduong,"km la:",tien(quangduong), "usd" )
