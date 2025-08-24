#Tôn Hoàng Cầm 23110186
so = int(input("Nhập vào một số nguyên dương : "))
while(so < 0):
    so = int(input("Vui lòng nhập lại : "))

so = str(so)
dem = 0
for i in range(len(so)):
    if(so[i] == '7'):
        dem += 1
print("Có", dem, "số 7 !")