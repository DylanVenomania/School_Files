import numpy as np

while True:
    n = int(input("Nhập vào số lượng của dãy : "))
    if n <= 0:
        print("Số lượng không nhỏ hơn hoặc bằng 0!")
        continue
    else:
        break
    
print('Nhập vào giới hạn giá trị nguyên của phần tử trong dãy : ')
while(True) :
    start = int(input("Đầu:"))
    end = int(input("Cuối:"))
    if end > start : 
        break
    else:
        print("Giá trị cuối phải lớn hơn giá trị đầu ! ")

arr = np.random.randint( start, end, size = n) 
print(f"Dãy số ban đầu : {arr} ")

arr =  arr[arr > 0]
print (f"Dãy số sau khi lọc lấy phần tử nguyên dương : {arr}")