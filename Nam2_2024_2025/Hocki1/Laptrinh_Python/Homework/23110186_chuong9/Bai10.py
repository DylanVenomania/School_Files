import numpy as np
def transpose(matran):
    if len(matran.shape) != 2:
        raise ValueError("Cần nhập ma trận 2D !")

    transposed_matran = matran.T
    return transposed_matran

def nhap():
    print("Nhập kích thước ma trânn : ")
    while True:
        try:
            hang = int(input("Số hàng : "))
            cot = int(input("Số cột : "))

            if hang <= 0 or cot <= 0:
                raise ValueError("Số hàng, số cột phải lớn hơn 0!")
            
            print(f"Nhập các phần từ của ma trận (từng hàng, cách nhau bởi khoảng trắng) :")
            matran = []
            for i in range(hang):
                hang_i = input(f"Hàng {i+1} : ").strip().split()
                if len(hang_i) != cot:
                    raise ValueError(f"Số phần tử trên hàng {i+1} phải là {cot}")
                matran.append( [int(x) for x in hang_i])


            return np.array(matran)
        except ValueError:
            print(f"Lỗi nhập, vui lòng nhập lại !")
        
matran = nhap()

print(f"\nMa trận ban đầu : \n{matran}")

transposed_matran = transpose(matran)

print(f"\nMa trận chuyển vị : \n{transposed_matran}")