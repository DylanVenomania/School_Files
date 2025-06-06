import sys
import math
n = int(input("Nhập số lượng phần tử trong list : "))
while(n < 0):
    n = int(input("Không hợp lệ, vui lòng nhập lại : "))
if( n == 0):
    print("List rỗng !")
    sys.exit()

def songuyento(num):
    i = 2
    if(num > 1):
        if(num == 2 ):
            return True
        while(i <= math.sqrt(num)):
            if(num % i == 0):
                return False
            i+=1
        else:
            return True
    else:
        return False

lst = []
lst_nguyento = []
print("Nhập các giá trị nguyên cho list : ")
for i in range(n):
    temp = int(input())
    lst.append(temp)
    if(songuyento(temp)):
        lst_nguyento.append(temp)
print("List các số nguyên tố : ", lst_nguyento)
