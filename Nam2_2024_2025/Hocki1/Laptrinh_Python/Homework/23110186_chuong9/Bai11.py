import numpy as np

def product(matran1, matran2):

    results = {}

    if matran1.shape[1] == matran2.shape[0]:
        results["matrix_product"] = np.dot(matran1, matran2)
    else:
        results["matrix_product"] = None 


    if matran1.shape == matran2.shape:
        results["hadamard_product"] = matran1 * matran2 
    else:
        results["hadamard_product"] = None 

    return results

def nhap(name):

    print(f"Nhập ma trận {name}:")
    while True:
        try:
            hang = int(input(f"Số hàng {name}: "))
            cot = int(input(f"Số cột {name}: "))
            if hang <= 0 or cot <= 0:
                raise ValueError("Số hàng và cột phải lớn hơn 0!")

            print(f"Nhập các phần từ của ma trận (từng hàng, cách nhau bởi khoảng trắng) :")
            mat = []
            for i in range(hang):
                hang_i = input(f"hàng {i + 1}: ").strip().split()
                if len(hang_i) != cot:
                    raise ValueError(f"Số phần tử trên hàng {i+1} phải là {cot}.")
                mat.append([int(x) for x in hang_i])

            return np.array(mat)
        except ValueError:
            print(f"Lỗi nhập, vui lòng nhập lại !")


matran1 = nhap("A")
matran2 = nhap("B")


results = product(matran1, matran2)

if results["matrix_product"] is not None:
    print("\nTích ma trận (A x B):")
    print(results["matrix_product"])
else:
    print("\nKhông có tích ma trận")

if results["hadamard_product"] is not None:
    print("\nTích Hadamard (A .* B):")
    print(results["hadamard_product"])
else:
    print("\nKhông có tích Hadamard")
