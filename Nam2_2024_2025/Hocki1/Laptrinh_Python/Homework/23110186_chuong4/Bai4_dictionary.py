n = int(input("Nhập số lượng phần tử n: "))
a = input(f"Nhập {n} phần tử của danh sách a, phân cách bởi dấu phẩy: ").split(',')
b = input(f"Nhập {n} phần tử của danh sách b, phân cách bởi dấu phẩy: ").split(',')

mydict = {a[i]: b[i] for i in range(n)}

print("Dictionary là:", mydict)