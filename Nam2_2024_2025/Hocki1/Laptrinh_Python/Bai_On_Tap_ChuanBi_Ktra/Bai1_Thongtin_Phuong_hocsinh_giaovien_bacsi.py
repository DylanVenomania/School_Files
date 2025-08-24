class person:
    def __init__(self):
        self.name = ""
        self.yob = 0

    def describe( self):
        return f"Tên : {self.name}, sinh năm {self.yob}"
    
    def inputPerson(self):
        self.name = input("Nhập tên : ")
        self.yob = int(input("Nhập năm sinh : "))


    
class student(person):
    def __init__(self):
        super().__init__()
        self.grade = ""
    
    def describe(self):
        return f"Học sinh :\n{super().describe()} \nLớp : {self.grade}"
    
    def inputPerson(self):
        super().inputPerson()
        self.grade = input("Nhập tên lớp : ")
    
class teacher(person):
    def __init__(self):
        super().__init__()
        self.subject = ""
    
    def describe(self):
        return f"Giáo viên : \n{super().describe()} \nDạy môn : {self.subject}"
    
    def inputPerson(self):
        super().inputPerson()
        self.subject = input("Nhập tên môn dạy: ")
    
class doctor( person ):
    def __init__(self):
        super().__init__()
        self.specialist = ""

    def describe(self):
        return f"Bác sĩ : \n{super().describe()} \nChuyên khoa : {self.specialist}"
    
    def inputPerson(self):
        super().inputPerson()
        self.specialist = input("Nhập tên chuyên khoa: ")
    

class ward:
    def __init__(self, name):
        self.name = name
        self.people_lst = []
    
    def addPerson(self, person ):
        self.people_lst.append( person )

    def describe( self ):
        print(f"Phường : {self.name}" )
        for person in self.people_lst:
            print()
            print(person.describe())

    def countDoctor(self):
        return sum(1 for person in self.people_lst if isinstance(person, doctor))
    
    def sortAge(self):
        self.people_lst.sort( key = lambda person : person.yob)

    def aveTeacheryob(self):
        teacher_lst = [person for person in self.people_lst if isinstance(person, teacher)]
        if not teacher_lst :
            return "Không có giáo viên !"
        else:
            return sum( person.yob for person in self.people_lst if isinstance(person, teacher)) / len(teacher_lst)
    

def main():
    phuong1 = ward("Phường 1")
    while True:
        choice = int(input("Loại đối tượng muốn khởi tạo :0. Exit, 1. Học sinh, 2.Giáo viên, 3.Bác sĩ : "))
        person = object
        if choice == 1: person = student()     
        if choice == 2: person = teacher()
        if choice == 3: person = doctor()
        if choice == 0: break
        person.inputPerson()

        phuong1.addPerson( person )

    phuong1.describe()

    print(f"\nSố lượng bác sĩ {phuong1.countDoctor()}")

    phuong1.sortAge()

    print(f"\nDanh sách người trong phường sau khi sắp xếp theo tuổi : " )
    phuong1.describe()
    
    print(f"\nNăm sinh trung bình của giáo viên  : {phuong1.aveTeacheryob()}")

if __name__=="__main__":
    main()


