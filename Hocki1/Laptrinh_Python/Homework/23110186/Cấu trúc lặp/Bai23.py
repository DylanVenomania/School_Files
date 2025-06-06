#Tôn Hoàng Cầm 23110186
import string
binary = (input("Nhập vào một số nhị phân muốn chuyển sang hệ thập phân :"))
length = len(binary)

def xet_hople(arr, chieudai):
    for i in range(chieudai - 1, -1, -1):
        if(arr[i] != '0' and arr[i] != '1'):
            return False
    return True
    
while( not( xet_hople(binary, length) )):
    print("Số nhị phân không hợp lệ !")
    binary = (input("Vui lòng nhập lại: "))
    length = len(binary)

         
def chuyenhe(binary):
    thapphan = 0
    power = 0
    for i in range(length - 1, -1, -1):
        if(binary[i] == '1'):
            thapphan += 2**power
        power += 1
    return thapphan

print( "Số thập phân của", binary, " là :", chuyenhe(binary) )
