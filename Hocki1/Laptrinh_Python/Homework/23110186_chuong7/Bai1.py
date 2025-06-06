import math
class circle:
    def __init__(self, radius):
        self.radius = radius
    
    def input(self):
        self.radius = float(input("Nhập giá trị bán kính cho hình tròn :"))
        if self.radius < 0:
            return False
        else:
            return True

    def perimeter(self):
        return 2*self.radius * math.pi
    
    def area(self):
        return pow(self.radius, 2) * math.pi
    
    def printInfo(self):
        print(f"Bán kính hình tròn là : {self.radius}")
        print(f"Chu vi hình tròn là : {self.perimeter()}")
        print(f"Diện tích hình tròn là : {self.area()}")

def main():
    hinhtron = circle(0)
    
    while True:
        if not( hinhtron.input()) :
            print("Lỗi giá trị bán kính, vui lòng nhập lại")
            hinhtron.input()
        else:
            hinhtron.printInfo()
            break

if __name__ == "__main__":
    main()
    