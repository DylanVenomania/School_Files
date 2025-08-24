import numpy as np

while True:
    print("Nhập khoảng giá trị mà phần tử mảng nằm trong : ")
    a = float(input("Nhập vào giá trị start: "))
    b=  float(input("Nhập vào giá trị end : ") )
    if b > a :
        break
    else:
        print("Giá trị end cần lớn hơn giá trị start !")

arr = a + (b - a) * np.random.rand(10)

print(f"Mảng 10 phần tử trong khoảng {a} và {b} là :\n {arr}")
