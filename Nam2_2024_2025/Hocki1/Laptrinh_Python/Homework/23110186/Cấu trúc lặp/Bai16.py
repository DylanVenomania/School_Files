#Tôn Hoàng Cầm 23110186
N = int(input("Nhập một số nguyên N : "))
i = 2
print("1", end = " ")
while(i <= N ):
    if(N % i == 0):
        print(i, end = " ")
    i += 1