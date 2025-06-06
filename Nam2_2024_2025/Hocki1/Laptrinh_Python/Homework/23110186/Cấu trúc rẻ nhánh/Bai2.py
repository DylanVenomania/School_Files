# Tôn Hoàng Cầm 23110186 
n = float(input())
def xacnhan(n):
    if(n == 0.0 or n== 0.4 or n >= 0.6):
        return True
    return False

while( not(xacnhan(n))): 
        print("Vui lòng nhập lại :")
        n = float(input())
        
giatrithuong = 2400*n
if (n == 0.0):
    print("Unacceptable", giatrithuong)
elif (n == 0.4):
    print("Acceptable", giatrithuong)
elif (n >=0.6):
    print("Meritorious", giatrithuong)


