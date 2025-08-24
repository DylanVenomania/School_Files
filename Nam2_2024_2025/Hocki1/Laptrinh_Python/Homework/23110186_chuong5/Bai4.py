import math

def ktra_nguyento(num):
    if num <= 1 :
        return False
    else:
        if(num == 2):
            return True
        else:
            for i in range(2, int(math.sqrt(num)) ):
                if(num % i == 0):
                    return False
            return True
    
def nextPrime(num):
    nguyento = 2
    while nguyento <= num or ( nguyento > num and not(ktra_nguyento(nguyento)) ):
        nguyento += 1
    return nguyento

def main():
    while True:
        try:
            number = int(input("Nhập vào một số nguyên để tìm số nguyên tố đầu tiên lớn hơn số này : "))

            print(f"Số nguyên tố đầu tiên và lớn hơn {number} là {nextPrime(number)}")
        except ValueError:
            print("Vui lòng nhập lại giá trị số nguyên !")

if __name__ == "__main__":
    main()