import numpy as np

start = int(input("Nhập giới hạn dưới : "))
end = int(input("Nhập giới hạn trên : "))
kichthuoc = int(input("Nhập số lượng phần tử muốn random: "))
random_array = np.random.randint(start, end, size = kichthuoc)

max_index = np.argmax( random_array)

print(f"Mảng ngẫu nhiên ban đầu : \n{random_array} ")

print(f"Chỉ số của số lớn nhất trong dãy là : {max_index} tương ứng với số {random_array[max_index]}")