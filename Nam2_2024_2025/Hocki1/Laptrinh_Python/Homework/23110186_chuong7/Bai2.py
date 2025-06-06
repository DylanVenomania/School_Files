import math
class triangle:
    def __init__(self, a = None, b  = None, c = None):
        self.a = a
        self.b = b
        self.c = c
        self.colour = "Không màu"

        
    def input(self):
        while True:
            self.a = float(input("Nhập vào độ dài cạnh a : "))
            self.b = float(input("Nhập vào độ dài cạnh b : "))
            self.c = float(input("Nhập vào độ dài cạnh c : "))
            self.colour = input("Nhập màu sắc : ")

            if not( self.isTriangle() ) :
                print("Tam giác không hợp lệ, vui lòng nhập lại :")
                continue
            else:
                break
    
            
    def isTriangle(self):
        if self.a <= 0 or self.b <= 0 or self.c <= 0 :
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

    def display(self):
        print(f"Độ dài lần lượt các cạnh của tam giác là : {self.a}, {self.b}, {self.c}")
        print(f"Màu sắc : ", self.colour)
        print(f"Chu vi tam giác : ", self.perimeter())
        print(f"Diện tích tam giác : ", self.area())
        print(f"Loại tam giác: {self.type()}")

    def type(self):
        if self.a == self.b == self.c :
            return "Tam giác đều !"
        elif self.a == self.b or self.b == self.c or self.a == self.c :
            if self.isRightTriangle():
                return "Tam giác vuông cân!"
            return "Tam giác cân!"
        elif self.isRightTriangle():
            return "Tam giác vuông!"
        else:
            return "Tam giác thường!"

    def isRightTriangle(self):
        side = sorted( [ self.a, self.b, self.c ])
        return pow(self.a, 2) + pow(self.b, 2) == pow(self.c, 2)
    
def main():
    tamgiac = triangle()
    tamgiac.input()
    tamgiac.display()
    


if __name__ == "__main__":
    main()