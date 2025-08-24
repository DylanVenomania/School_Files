tuples_list = []
while True:
    input_info = input("Nhập lần lượt thông tin 'name, age, score' (nhập 'done' để kết thúc): ")
    if input_info.lower() == 'done':
        break
    name, age, score = input_info.split(',')
    tuples_list.append((name.strip(), int(age.strip()), int(score.strip() ) ) )

sorted_tuples = sorted(tuples_list)

for item in sorted_tuples:
    print(item)