#Tôn Hoàng Cầm 23110186
import  string
N = str(input("Nhập vào một số trong khoảng 10 000 đến 99 999 : "))
while( int(N) < 10000 or int(N) > 99999):
    N = str(input("Chưa hợp lệ, xin vui lòng nhập lại : "))

chan =0
le = 0
for i in range(len(N)):
    if(int(N[i]) % 2 == 0):
        chan += 1
    else:
        le += 1
print("Co ", chan, " chu so chan !")
print("Co ", le, " chu so le !")
