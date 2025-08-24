#Tôn Hoàng Cầm 23110186
thang = int(input("Nhập vào tháng : "))
while(thang < 1 or thang > 12):
    thang = int(input("Vui lòng nhập lại : "))

if(thang >=1 and thang <= 3):
    print("Tháng ",thang," nằm trong mùa Xuân !")
elif(thang >=4 and thang <= 6):
    print("Tháng",thang," nằm trong mùa Hè !")
elif(thang >=7 and thang <= 9):
    print("Tháng",thang," nằm trong mùa Thu !")
elif(thang >=10 and thang <= 12):
    print("Tháng",thang," nằm trong mùa Đông !")
    