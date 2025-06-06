#Tôn Hoàng Cầm 23110186
day = int(input("Nhập vào thứ trong tuần bằng số : \n1 = Chủ nhật \n2 = Thứ 2 \n3 = Thứ 3 \n4 = Thứ 4 \n5 = Thứ 5 \n6 = Thứ 6 \n7 = Thứ 7\n"))
while(day < 1 or day > 7):
    day = int(input("Vui lòng nhập lại : "))
date = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
for i in range(1, 7):
    if(day == i):
        print(date[i-1])