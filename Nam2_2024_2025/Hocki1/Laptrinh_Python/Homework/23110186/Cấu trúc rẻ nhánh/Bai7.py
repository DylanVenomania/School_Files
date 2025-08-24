# Tôn Hoàng Cầm 23110186 
import math
year = int(input("Nhập vào năm : "))
day = (year + math.floor( (year -1)/4) - math.floor( (year - 1)/100) + math.floor( (year -1)/400)) % 7
danhsachdays = ["Chủ nhật", "Thứ 2", "thứu 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"]
print("Ngày 1 tháng 1 năm ", year, "là : ", danhsachdays[day])