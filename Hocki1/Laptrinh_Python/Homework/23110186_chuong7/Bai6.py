class Subject:
    def __init__(self, code, name, period):
        self.code = code
        self.name = name
        self.period = period
    
    def display(self) :
        print(f" - Mã môn: {self.code}, tên môn: {self.name}, số tiết: {self.period}")
        print()



class Student:
    def __init__(self, id, name, birth):
        self.id = id
        self.name = name
        self.birth = birth
        self.subject_lst = []
    
    def add_subject(self, subject):
        self.subject_lst.append( subject )

    def display(self):
        print(f"Số CMN hoặc căn cước hoặc mã số khai sinh : {self.id}")
        print(f"Họ tên: {self.name}")
        print(f"Năm sinh: {self.birth}")
        print(f"Danh sách môn học: ")
        for monhoc in self.subject_lst:
            monhoc.display()
        print()



class quanly_student:
    def __init__(self):
        self.student_lst = []
    
    def add_student(self, student):
        self.student_lst.append(student)
    
    def input_student(self):
        while True:
            id = input("Nhập CMN hoặc căn cước hoặc mã số khai sinh : ")
            name = input("Nhập tên học viên: ")
            birth = int(input("Nhập năm sinh học viên : "))

            hocvien = Student ( id, name, birth )
            
            while True:
                code = input("Nhập mã môn học : ")
                subject_name = input("Nhập tên môn học : ")
                period = int(input("Nhập số tiết của môn học : "))

                monhoc = Subject(code, subject_name, period)

                hocvien.add_subject( monhoc )

                print("Có nhập thêm môn học không ? ")
                print("1. Có ")
                print("2. Không")
                while True:
                    choice = int(input("Lựa chọn : "))
                    if choice > 2 or choice <= 0 :
                        print("Lựa chọn không hợp lệ, vui lòng nhập lại!")
                        continue
                    else:
                        break
                if choice == 2:
                    break

            self.add_student(hocvien)

            print("Có nhập thêm học viên không ? ")
            print("1. Có ")
            print("2. Không")
            while True:
                choice = int(input("Lựa chọn : "))
                if choice > 2 or choice <= 0 :
                    print("Lựa chọn không hợp lệ, vui lòng nhập lại!")
                    continue
                else:
                    break
            if choice == 2:
                    break
        
        self.save_file()
    
    def display_lst(self):
        print("\nThông tin học viên đã đăng ký:")
        for hocvien in self.student_lst:
            hocvien.display()


    def student_2subjects(self):
        print("\nThông tin học viên đăng ký ít nhất hai môn học:")
        for hocvien in self.student_lst:
            if len( hocvien.subject_lst ) >= 2:
                hocvien.display()
    
    def subject_max_student(self):
        print("\nThông tin môn học học viên đăng ký nhiều nhất: ")
        monhoc_soluonghocvien = {}
        
        for hocvien in self.student_lst:
            for monhoc in hocvien.subject_lst:
                if monhoc.name in monhoc_soluonghocvien:
                    monhoc_soluonghocvien[ monhoc.name ] += 1
                else:
                    monhoc_soluonghocvien[ monhoc.name ] = 1
        
        monhoc_max_nguoidangki = max( monhoc_soluonghocvien, key = monhoc_soluonghocvien.get)
        print(f"Môn học được nhiều học viên đăng ký nhất là: {monhoc_max_nguoidangki} ({monhoc_soluonghocvien[ monhoc_max_nguoidangki]} sinh viên)")

    def soluong_hocvien_1subject(self):
        monhoc_soluonghocvien = {}
        
        for hocvien in self.student_lst:
            for monhoc in hocvien.subject_lst:
                if monhoc.name in monhoc_soluonghocvien:
                    monhoc_soluonghocvien[ monhoc.name ] += 1
                else:
                    monhoc_soluonghocvien[ monhoc.name ] = 1

        print("\nSố lượng học viên trên mỗi môn học:")
        for monhoc, soluong in monhoc_soluonghocvien.items():
            print(f"{monhoc}: {soluong} học viên")

    def save_file(self):
        import os
        print("File được lưu tại:", os.path.abspath("dssv.txt"))
        with open("D:/Năm 2 ( 2024 - 2025 )/Bài tập python/23110186_chuong7/dssv.txt", "w", encoding='utf-8') as f:
            for hocvien in self.student_lst:
                f.write(f"{hocvien.id} :  {hocvien.name} : {hocvien.birth}\n")
                f.write("; ".join([f" {monhoc.code} :: {monhoc.name} :: {monhoc.period} " 
                                        for monhoc in hocvien.subject_lst]) + "\n")
            f.close()
        print("Dữ liệu đã được lưu vào file dssv.txt")

def main():

    
    management = quanly_student()  
    management.input_student()  

    management.display_lst()  

    management.student_2subjects()  

    management.subject_max_student()  

    management.soluong_hocvien_1subject() 
    

if __name__ == "__main__":
    main()
            
