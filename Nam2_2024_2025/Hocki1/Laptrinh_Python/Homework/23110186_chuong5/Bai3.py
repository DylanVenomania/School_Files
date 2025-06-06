import math

def ktra_nguyento(num):
    if num <= 1:
        return False
    else:
        if num == 2 :
            return True
        else:
            for i in range(2, int( math.sqrt(num)) ):
                if num % i == 0:
                    return False
            return True

def main():
    while True:
        try: 
            number = int(input("Nhập vào một số nguyên : "))

            if( ktra_nguyento(number)):
                print(f"{number} là số nguyên tố !")
            else:
                print(f"{number} không là số nguyên tố !")
        except ValueError:
            print("Vui lòng nhập lại giá trị số nguyên: ")

if __name__ ==  "__main__":
    main()