week_temper = []
avg  = 0
print("Nhập vào nhiệt độ các ngày trong tuần : ")
for i in range(7):
    temper = float(input("        Nhiệt độ :"))
    week_temper.append(temper)
    avg += temper
avg = avg/7
count = 0
for i in range(7):
    if(week_temper[i] > avg):
        count += 1
print("Nhiệt độ trung bình cả tuần là:", avg)
print("Có", count, "ngày có nhiệt độ cao hơn nhiệt độ trung bình cả tuần!")
