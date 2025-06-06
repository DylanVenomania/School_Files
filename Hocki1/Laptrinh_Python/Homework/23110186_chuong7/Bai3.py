import math

class toanhoc:
    def __init__(self):
        self.nso = []

    def input(self, *nso):
        self.nso.extend(nso)

    def sum(self):
        tong = 0.0
        for i in self.nso:
            tong+= i
        return tong
    
    def avgsum(self):
        tong = self.sum()
        trungbinh = tong/len(self.nso)
        return trungbinh

    def findmax(self):
        max = self.nso[0]
        for i in self.nso:
            if(i > max ):
                max = i
        return max
    
    def findmin(self):
        min = self.nso[0]
        for i in self.nso:
            if(i < min ):
                min = i
        return min
    
    def display(self):
        print("Danh sách các số :", self.nso)
        print("Tổng :", self.sum())
        print("Trung bình tổng :", self.avgsum())
        print("Số lớn nhất :", self.findmax())
        print("Số nhỏ nhất :", self.findmin())

def main():
    num = toanhoc()
    so_nhap = input("Nhập vào danh sách các số ( cach nhau boi khoang trang ): ")
    so_nhap = list( map(float, so_nhap.split() ) )
    num.input(*so_nhap)

    num.display()

if __name__ == "__main__":
    main()