n = int(input("Nhập số nguyên n: "))
result = {i: i ** 2 for i in range(1, n + 1)}
print("Dictionary chứa (i, i^2) từ 1 đến", n, "là:", result)