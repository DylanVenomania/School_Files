import numpy as np

def transpose(mat):
    return np.transpose(mat)

def input_matran(so_hang, so_cot):
    matran = []
    print("Nhập liên tục các phần tử của hàng (mỗi phần tử cách nhau một khoảng trắng)")
    for i in range( so_hang ):
        while True:
            hang = list(  map(float, input(f"Nhập hàng thứ {i + 1} : ").split()    ) )
            if len( hang ) == so_cot :
                matran.append( hang )
                break
            else:
                print("Số lượng phần tử trong hàng không đúng ! Vui lòng nhập lại")

    return np.array( matran )


def main():
    so_hang = int(input("Nhập số lượng số hàng : "))
    so_cot = int(input("Nhập số lượng cột : "))

    matran = input_matran( so_hang, so_cot)
    print(f"Ma trận ban đầu :\n {matran}")

    matran = transpose(matran)
    print(f"Ma trận chuyển vị là :\n {matran}")
    return 0


if __name__=="__main__":
    main()