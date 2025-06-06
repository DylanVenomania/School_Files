import numpy as np

a = float(input("Nhập giá trị a : "))
b = float(input("Nhập giá trị b : "))

random_floats = a + (b - a) * np.random.rand(10)

print(f"Mảng 10 số thực trong khoảng ( {a}, {b} ) : \n{random_floats} ")