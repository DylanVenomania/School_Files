#Tôn Hoàng Cầm 23110186
import sys
import string
button = "c"
while(button == "c"):
    N = int(input("Nhập một số nguyên dương N : "))
    while(N <= 0):
        N = int(input("Vui lòng nhập lại: "))

    arr = []
    print("Nhập vào các giá trị cho mảng: ")
    for i in range(N):
        arr = arr + [int(input())]

    def odd_num(so):
        if(so % 2 !=0 ):
            return True
        return False

    def odd_exist():
        for i in range(N):
            if( odd_num(arr[i])):
                return True
        return False

    if( not(odd_exist()) ):
        print("Dãy không có số lẻ !")
        sys.exit()
            
    for i in range(N):
        if( odd_num(arr[i]) ):
            max = arr[i]
    
    for i in range(N):
        if(arr[i] >  max and odd_num(arr[i])):
            max = arr[i]
    print("Số nguyên lẻ lớn nhất trong mảng : ", max)
    button = str(input("Bạn có muốn tiếp tục ? \n          Nhấn phím kí tự c để tiếp tục\n          Nhấn phím kí tự bất kì để kết thúc\n"))
