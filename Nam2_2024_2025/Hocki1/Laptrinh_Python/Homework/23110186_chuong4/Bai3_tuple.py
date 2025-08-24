lst = input("Nhập các phần tử của list, phân tách bằng dấu phẩy: ")
lst = [int(num.strip()) for num in lst.split(',')]

tup = input("Nhập các phần tử của tuple, phân tách bằng dấu phẩy: ")
tup = tuple(int(num.strip()) for num in tup.split(','))

outlst = lst + list(tup)
outtup = tuple(lst + list(tup))

print("outputList =", outlst)  
print("outputTuple =", outtup)