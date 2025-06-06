from abc import ABC, abstractmethod
from datetime import datetime  

class giaodich(ABC):
    def __init__(self, id_giaodich, date, cost, soluong):
        self.id_giaodich = id_giaodich
        self.date = datetime.strptime(date, "%d/%m/%Y")
        self.cost = cost
        self.soluong = soluong

    def thanhtien(self):
        pass
    
    def output(self):
        return ( f"ID: {self.id_giaodich}, Ngày: {self.date.strftime('%d/%m/%Y')}, "
                f"Đơn giá: {self.cost}, Số lượng: {self.soluong}, Thành tiền: {self.thanhtien()}" )
    
    
class giaodichvang( giaodich ):
    def __init__(self, id_giaodich, date, cost, soluong, loai_vang):
        super().__init__(id_giaodich, date, cost, soluong)
        self.loai_vang = loai_vang
    
    def thanhtien(self):
        return self.soluong * self.cost
    
    def output(self):
        return super().output() + f", Loại vàng: {self.loai_vang}"
    

class giaodichtiente( giaodich ):
    def __init__(self, id_giaodich, date, cost, soluong, loai_tiente, loai_giaodich):
        super().__init__(id_giaodich, date, cost, soluong)
        self.loai_tiente = loai_tiente
        self.loai_giaodich = loai_giaodich

    def thanhtien(self):
        if self.loai_giaodich == "mua":
            return self.soluong * self.cost
        elif self.loai_giaodich == "bán":
            return (self.soluong * self.cost) * 1.05
        return 0

    def output(self):
        return super().output() + f", Loại tiền tệ: {self.loai_tiente}, Loại giao dịch: {self.loai_giaodich}"
    


class quanlygiaodich:
    def __init__(self):
        self.dsgiaodich = []

    def nhapds(self):
        while True:
            loai_giaodich = input("Nhập loại giao dịch (vàng / tiền tệ): ").lower()
            id_giaodich = input("Nhập mã giao dịch: ")
            date = input("Nhập ngày giao dịch (dd/mm/yyyy): ")
            cost = float(input("Nhập đơn giá: "))
            soluong = float(input("Nhập số lượng: "))

            if loai_giaodich == "vàng":
                loai_vang = input("Nhập loại vàng (18k/24k/9999): ")
                giao_dich = giaodichvang( id_giaodich, date, cost, soluong, loai_vang )
            elif loai_giaodich == "tiền tệ":
                loai_tiente = input("Nhập loại tiền tệ (USD/EUR/AUD): ")
                loai_giaodich_tiente = input("Nhập loại giao dịch (mua / bán): ")
                giao_dich = giaodichtiente( id_giaodich, date, cost, soluong, loai_tiente, loai_giaodich_tiente )
            else:
                print("Loại giao dịch không hợp lệ.")
                continue

            self.dsgiaodich.append( giao_dich )
            print("Có muốn thêm giao dịch khác không? (có / không): ")
            if input().lower() != "có":
                break

    def outputgiaodich(self):
        for gd in self.dsgiaodich:
            print( gd.output() )
    
    def tong_soluong(self):
        tong_vang = sum( gd.soluong for gd in self.dsgiaodich if isinstance(gd, giaodichvang))
        tong_tiente = sum(gd.soluong for gd in self.dsgiaodich if isinstance(gd, giaodichtiente))

        print(f"Tổng số lượng giao dịch vàng: {tong_vang}")
        print(f"Tổng số lượng giao dịch tiền tệ: {tong_tiente}")

    
    def tong_thanhtien(self):
        tong_vang = sum( gd.thanhtien() for gd in self.dsgiaodich if isinstance(gd, giaodichvang) )
        tong_tiente = sum( gd.thanhtien() for gd in self.dsgiaodich if isinstance(gd, giaodichtiente) )

        print(f"Tổng thành tiền giao dịch vàng: {tong_vang}")
        print(f"Tổng thành tiền giao dịch tiền tệ: {tong_tiente}")



def main():
    ql_gd = quanlygiaodich()
    ql_gd.nhapds()
    ql_gd.outputgiaodich()
    ql_gd.tong_soluong()
    ql_gd.tong_thanhtien()

if __name__ == "__main__":
    main()
