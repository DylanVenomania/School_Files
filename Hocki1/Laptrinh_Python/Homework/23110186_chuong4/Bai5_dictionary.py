mydict = {}
n = int(input("Nhập số lượng học sinh: "))
for i in range(n):
    name = input(f"Nhập tên học sinh thứ {i+1}: ")
    score = float(input(f"Nhập điểm của học sinh {name} (trong khoảng 0-10): "))
    if 0 <= score <= 10:
        mydict[name] = score
    else:
        print("Điểm không hợp lệ! Vui lòng nhập lại.")

score_count = {i: 0 for i in range(11)} 
for score in mydict.values():
    rounded_score = round(score)  
    score_count[rounded_score] += 1
print("\nThống kê số lượng học sinh đạt các mốc điểm:")
for score, count in score_count.items():
    print(f"Điểm {score}: {count} học sinh")