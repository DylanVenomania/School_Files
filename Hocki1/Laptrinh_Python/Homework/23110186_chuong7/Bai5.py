from abc import ABC, abstractmethod
import math

class shape(ABC):
    def perimeter(self):
        pass

    def area(self):
        pass

class circle( shape ):
    def __init__(self, R = None):
        self.R = R
    
    def input(self):
        while True:
            self.R = float( input("Nhập bán kính hình tròn : ") )
            if self.R <= 0:
                print("Giá trị bán kính không hợp lệ! Vui lòng nhập lại!")
                print()
                continue
            else:
                break

    def perimeter(self):
        return 2 * math.pi * self.R
    
    def area(self):
        return math.pi * pow(self.R, 2)
    


class rectangle( shape ):
    def __init__(self, dai = 0, rong = 0):
        self.dai = dai
        self.rong = rong
    
    def input(self):
        while True:
            self.dai = float(input("Nhập chiều dài : "))
        
            if  self.dai <= 0:
                print("Chiều dài không thoả! Vui lòng nhập lại")
                print()
                continue
            else:
                break
        
        while True:
            self.rong = float(input("Nhập chiều rộng : "))
        
            if self.rong <= 0:
                print("Chiều rộng không thoả! Vui lòng nhập lại")
                print()
                continue
            else:
                break

    def perimeter(self):
        return 2* (self.dai + self.rong)
    
    def area(self):
        return self.dai * self.rong
    



class triangle( shape ):
    def __init__(self, a = None, b = None, c = None):
        self.a = a
        self.b = b
        self.c = c
    
    def input(self):
        while True:
            self.a = float(input("Nhập vào độ dài cạnh a : "))
            self.b = float(input("Nhập vào độ dài cạnh b : "))
            self.c = float(input("Nhập vào độ dài cạnh c : "))

            if not( self.isTriangle() ) :
                print("Tam giác không hợp lệ, vui lòng nhập lại :")
                print()
                continue
            else:
                break

    def isTriangle(self):
        if self.a <= 0 or  self.b <= 0 or self.c <= 0 :
            return False
        elif self.a + self.b > self.c and self.a + self.c > self.b and self.b + self.c > self.a :
            return True
        else:
            return False

    def perimeter(self):
        return self.a + self.b + self.c 
    
    def area(self):
        heron = self.perimeter() /2
        return math.sqrt( heron * ( heron - self.a)* ( heron - self.b)* ( heron - self.c) )
    



def main():
    hinhtron = circle()
    print("Nhập thông tin hình tròn: ")
    hinhtron.input()
    print(f"Chu vi của hình tròn : {hinhtron.perimeter()}")
    print(f"Diện tích của hình tròn : {hinhtron.area()}")

    chunhat = rectangle()
    print("\nNhập thông tin hình chữ nhật: ")
    chunhat.input()
    print(f"Chu vi của hình chữ nhật : {chunhat.perimeter()}")
    print(f"Diện tích của hình chữ nhật  : {chunhat.area()}")

    tamgiac = triangle()
    print("\nNhập thông tin tam giác: ")
    tamgiac.input()
    print(f"Chu vi của tam giác : {tamgiac.perimeter()}")
    print(f"Diện tích của tam giác : {tamgiac.area()}")

if __name__=="__main__":
    main()