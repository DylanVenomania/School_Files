import numpy as np

a = float(input("Nhập giá trị a : "))
b = float(input("Nhập giá trị b : "))

linspace_array = np.linspace(a, b, 20)

print(f"Mảng chứa 20 số thực cách đều trong khoảng ( {a}, {b} ) : \n{linspace_array} ")