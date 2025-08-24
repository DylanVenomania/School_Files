import numpy as np

while True:
    n = int(input("Nhập vào một số nguyên dương N: "))
    if n <= 0:
        print("Số lượng không nhỏ hơn hoặc bằng 0!")
        continue
    else:
        break

arr = np.arange(1, n+1, 1)
print(f"Mảng ban đầu : {arr}")

arr = np.arange(1, n+1, 2)
print(f"Mảng gồm các số nguyên lẻ từ mảng ban đầu{arr}")