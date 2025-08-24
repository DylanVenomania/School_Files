import numpy as np

def input_matran( so_hang, so_cot ):
    matran = []
    print("Nhập các phần tử của một hàng (cách nhau bởi 1 khoảng trắng) : ")
    for thutu in range(so_hang):
        while True:
            hang = list (map ( float, input(f"Nhập hàng thứ { thutu + 1 } : ").split() ) )
            if len(hang ) == so_cot : 
                matran.append( hang )
                break
            else:
                    print("Số lượng phần tử của hàng chưa phù hợp ! Vui lòng nhập lại!")

    return np.array(matran)

def replace_col(matran, col_index):
    if col_index < 0 or col_index >= matran.shape[1]:
        raise IndexError("Chỉ số cột không hợp lệ!")
    
    matran[:, col_index] = 1

    return matran

def main():
    hang = int(input("Nhập số lượng hàng ma trận : "))
    cot = int(input("Nhập số lượng cột ma trận : "))
    matran = input_matran(hang, cot)

    cot_index = int(input("Nhập vào chỉ số cột muốn thay đổi thành cột với toàn số 1 :"))
    matran = replace_col(matran, cot_index -1 )
    print(f"Ma trận sau khi thay đổi cột {cot_index } thành cột toàn giá trị 1 : \n {matran}")
    return 0

if __name__=="__main__":
     main()