class Diachi:
    def __init__(self):
        self.so_nha = 0
        self.ten_duong = ""
        self.ten_quan = ""
        self.thanh_pho = ""
    
    def nhap(self):
        self.so_nha = input("Nhập số nhà : ")
        self.ten_duong = input("Nhập tên đường : ")
        self.ten_quan = input("Nhập tên quận : ")
        self.thanh_pho = input("Nhập tên thành phố : ")

    def __str__(self):
        return f"Số nhà: {self.so_nha}, Đường: {self.ten_duong}, Quận: {self.ten_quan}, Thành phố: {self.thanh_pho}"

class nhanvien :
    def __init__(self):
        self.hoten = ""
        self.datetime = ""
        self.diachi = Diachi()
    
    def nhap(self):
        self.hoten = input("Nhập họ tên : " )
        self.datetime = input("Nhập lần lượt ngày tháng năm sinh : ")
        self.diachi.nhap()
        
    def inthongtin(self):
        return (f"Họ tên: {self.hoten}, Ngày sinh: {self.datetime}, Địa chỉ: {self.diachi}")
    
class nhanviensanxuat( nhanvien ):
    def __init__(self):
        super().__init__()
        self.luongcoban = 0.0
        self.sosanpham = 0

    def nhap(self):
        super().nhap()
        self.luongcoban = float( input("Nhập lương cơ bản : "))
        self.sosanpham = int( input("Nhập số sản phẩm đã làm : "))

    def tinhluong(self):
        return self.luongcoban + self.sosanpham*5000

    def inthongtin(self):
        return (f"Nhân viên sản xuất :\n{super().inthongtin()},\nLương : {self.tinhluong()}\nSố sản phẩm : {self.sosanpham}")
    
class nhanvienvanphong( nhanvien ):
    def __init__(self):
        super().__init__()
        self.songaylamviec = 0

    def nhap(self):
        super().nhap()
        self.songaylamviec = int( input("Nhập số ngày làm việc : "))

    def tinhluong(self):
        return self.songaylamviec*100_000

    def inthongtin(self):
        return (f"Nhân viên văn phòng :\n{super().inthongtin()},\nLương : {self.tinhluong()}\nSố ngày làm việc : {self.songaylamviec}")

def main():
    nhanvienvanphong_lst = []
    nhanviensanxuat_lst = []
    while True:
        choice = int(input("Menu : 0.Exit, 1. Nhân viên văn phòng, 2. Nhân viên sản xuất ") ) 
        nhavien = object
        if choice == 1 : 
            nhanvien1 = nhanvienvanphong()
            nhanvien1.nhap()
            nhanvienvanphong_lst.append(nhanvien1)

    
        if choice == 2 : 
            nhanvien1 = nhanviensanxuat()
            nhanvien1.nhap()
            nhanviensanxuat_lst.append(nhanvien1)

        if choice == 0:
            break
    
    print()
    if len(nhanviensanxuat_lst) != 0 :
        print("Danh sách nhân viên sản xuất : \n")
        for nhanvien_a in nhanviensanxuat_lst :
            print( nhanvien_a.inthongtin() )
            print()

    if len(nhanvienvanphong_lst) != 0 :
        print("Danh sách nhân viên văn phòng : \n")
        for nhanvien_a in nhanvienvanphong_lst :
            print( nhanvien_a.inthongtin() )    
            print() 


if __name__ =="__main__":
    main()