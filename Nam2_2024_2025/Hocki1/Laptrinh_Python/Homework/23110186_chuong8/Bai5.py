import numpy as np

while True:
    print("Nhập khoảng giá trị mà phần tử mảng nằm trong : ")
    a = float(input("Nhập vào giá trị start: "))
    b=  float(input("Nhập vào giá trị end : ") )
    if b > a :
        break
    else:
        print("Giá trị end cần lớn hơn giá trị start !")


arr = np.linspace(a, b, 20)
print(f"20 số thực nằm giữa {a} và {b} là :\n {arr}")