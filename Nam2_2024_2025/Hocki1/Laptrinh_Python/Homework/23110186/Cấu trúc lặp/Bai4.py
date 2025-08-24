#Tôn Hoàng Cầm 23110186
lythuyet = float(input("Nhập vào điểm lý thuyết : "))
while(lythuyet > 10 or lythuyet < 0):
    lythuyet = float(input("Vui lòng nhập lại : "))
    
thuchanh = float(input("Nhập vào điểm thực hành : "))
while(thuchanh > 10 or thuchanh < 0):
    thuchanh = float(input("Vui lòng nhập lại : "))

diemtb = (lythuyet + thuchanh)/2
print("Điểm trung bình là : ", diemtb)