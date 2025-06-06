import math
class point2d:
    def __init__(self):
        self.x = None
        self.y = None
        self.colour = "Không màu"


    def input(self):
        self.x = input("Nhập toạ độ x: ")
        if not self.x :
            self.x = None
        else:
            self.x = float(self.x)

        self.y = input("Nhập toạ độ y: ")
        if not self.y :
            self.y = None
        else:
            self.y = float(self.y)

        self.colour = input("Nhập màu cho điểm : ")
        print()


    def isPoint2d(self):
        if self.x == None or self.y == None or not self.colour : 
            return False
        return True
    

    def display(self):
        print(f"Toạ độ (x,y) của điểm : ({self.x} , {self.y})")
        print(f"Màu của điểm : {self.colour}")
        print()


    def TinhTien(self, dx, dy):
        if dy == None :
            self.x += dx
        else:
            self.x += dx
            self.y += dy
    

    def KhoangCach(self, other):
        if other.x == None or other.y == None :
            return math.sqrt( pow(self.x, 2) + pow(self.y, 2) )
        else:
            return math.sqrt( pow(self.x - other.x, 2) + pow(self.y - other.y, 2) )
    
def menu():
    toado = point2d()
    print("Nhập toạ độ cho điểm : ")
    toado.input()
    while not toado.isPoint2d:
        toado.input()

    toado.display()
    
    while True:
        tinhtien_Ox = input("Nhập khoảng cách muốn tịnh tiến theo trục Ox : ")
        if not(tinhtien_Ox):
            print("Cần nhập giá trị tịnh tiến theo Ox, vui lòng nhập lại!")
            continue 
        else:
            tinhtien_Ox = float(tinhtien_Ox)

        tinhtien_Oy = input("Nhập khoảng cách muốn tịnh tiến theo trục Oy (không nhập để chỉ tịnh tiến theo Ox): ")
        if not(tinhtien_Oy):
            tinhtien_Oy = None 
        else:
            tinhtien_Oy = float( tinhtien_Oy )
        toado.TinhTien(tinhtien_Ox, tinhtien_Oy )

        print(f"Toạ độ điểm sau khi tịnh tiến : ")
        toado.display()
        break
    
    other = point2d()
    print(f"Nhập toạ độ cho điểm thứ 2 để tính khoảng cách từ điểm ({toado.x} , {toado.y}) đến : ")
    print(f"Không nhập để tính khoảng cách từ gốc toạ độ đến điểm ({toado.x} , {toado.y}) : ")
    other.input()
        
    if not other.isPoint2d():
        print(f"Khoảng cách từ gốc toạ độ đến ({toado.x} , {toado.y}) là {toado.KhoangCach(other)}")
    else:
        print(f"Khoảng cách từ điểm ({other.x} , {other.y}) đến ({toado.x} , {toado.y}) là {toado.KhoangCach(other)}")

def main():
    menu()
    
if __name__ == "__main__":
    main()

