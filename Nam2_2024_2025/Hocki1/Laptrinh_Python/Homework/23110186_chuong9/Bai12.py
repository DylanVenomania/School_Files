import numpy as np

def replace_cot(matran, cot_ind):

    if cot_ind < 0 or cot_ind >= matran.shape[1]:
        raise ValueError("Chỉ mục cột không hợp lệ")

    matran[:, cot_ind] = 1
    return matran




def nhap():
 
    print("Nhập ma trận:")
    while True:
        try:
            rows = int(input("Số hàng: "))
            cols = int(input("Số cột: "))
            if rows <= 0 or cols <= 0:
                raise ValueError("Số hàng và cột phải lớn hơn 0!")

            print("Nhập các phần tử của ma trận (từng hàng, cách nhau bởi khoảng trắng):")
            mat = []
            for i in range(rows):
                row = input(f"Hàng {i + 1}: ").strip().split()
                if len(row) != cols:
                    raise ValueError(f"Số phần tử trên hàng {i+1} phải là {cols}.")
                mat.append([int(x) for x in row])

            return np.array(mat)
        except ValueError as e:
            print(f"Lỗi nhập, vui lòng nhập lại! {e}")


matran = nhap()

while True:
    try:
        cot_ind = int(input("Nhập chỉ mục cột cần thay đổi (bắt đầu từ 0): "))
        if cot_ind < 0 or cot_ind >= matran.shape[1]:
            raise ValueError("Chỉ mục cột không hợp lệ! Vui lòng nhập chỉ mục trong khoảng hợp lệ.")
        break
    except ValueError as e:
        print(f"Lỗi nhập: {e}. Vui lòng nhập lại!")


matran_sau_thay_doi = replace_cot(matran, cot_ind)


print("\nMa trận sau khi thay đổi:")
print(matran_sau_thay_doi)