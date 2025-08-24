class Student:
    def __init__(self, id, name):
        self.id = id
        self.name = name

    def __str__(self):
        return f"{self.id} - {self.name}"

class quanlysinhvien:
    def __init__(self):
        self.students = []

    def add_student(self):
        id = input("Nhập mã sinh viên: ")
        name = input("Nhập tên sinh viên: ")
        student = Student(id, name)
        self.students.append(student)
        print(f"Đã thêm sinh viên: {student}")

    def remove(self):
        id = input("Nhập mã sinh viên cần xóa: ")
        for student in self.students:
            if student.id == id:
                self.students.remove(student)
                print(f"Đã xóa sinh viên: {student}")
                return
        print("Không tìm thấy sinh viên với mã đã nhập.")

    def edit(self):
        id = input("Nhập mã sinh viên cần sửa: ")
        for student in self.students:
            if student.id == id:
                new_name = input("Nhập tên mới: ")
                student.name = new_name
                print(f"Đã sửa sinh viên: {student}")
                return
        print("Không tìm thấy sinh viên với mã đã nhập.")

    def view(self):
        if not self.students:
            print("Danh sách sinh viên rỗng.")
            return
        print("Danh sách sinh viên:")
        for student in self.students:
            print(student)


def main():
    manager = quanlysinhvien()

    while True:
        print("\nChọn chức năng:")
        print("1: Thêm sinh viên")
        print("2: Xóa sinh viên")
        print("3: Sửa sinh viên")
        print("4: Xem danh sách sinh viên")
        print("0: Thoát")
        
        choice = input("Nhập lựa chọn của bạn: ")
        
        if choice == '1':
            manager.add_student()
        elif choice == '2':
            manager.remove()
        elif choice == '3':
            manager.edit()
        elif choice == '4':
            manager.view()
        elif choice == '0':
            print("Thoát chương trình.")
            break
        else:
            print("Lựa chọn không hợp lệ. Vui lòng thử lại.")


if __name__ == "__main__":
    main()