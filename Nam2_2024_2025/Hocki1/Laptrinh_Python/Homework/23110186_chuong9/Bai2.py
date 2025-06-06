import numpy as np


start = int(input("Nhập giới hạn dưới : "))
end = int(input("Nhập giới hạn trên : "))
kichthuoc = int(input("Nhập số lượng phần tử muốn random: "))
random_array = np.random.randint(start, end, size = kichthuoc)

nguyen_duong = random_array[ random_array > 0]

print(f"Mảng ngẫu nhiên ban đầu : \n{random_array} ")

print(f"Mảng chứa các số nguyên dương từ mảng ban đầu : \n{nguyen_duong}")

