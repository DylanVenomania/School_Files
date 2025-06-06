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

def tich( matran1, matran2):
    try:
        if matran1.shape == matran2.shape:
            tichHadamard = matran1 * matran2
            return f"Tích Hadamard : \n{tichHadamard}"
    except ValueError:
        return "Không có tích Hadamard !"
    
    try: 
        tich = np.dot( matran1, matran2 )
        return f"Tích của 2 ma trận là : \n{tich}"
    except ValueError:
        return "Không có tích !"
    
def main():
    hang_matran1 = int(input("Nhập số lượng hàng ma trận 1 : "))
    cot_matran1 = int(input("Nhập số lượng cột ma trận 1 : "))
    matran1 = input_matran( hang_matran1, cot_matran1)

    hang_matran2 = int(input("Nhập số lượng hàng ma trận 2 : "))
    cot_matran2 = int(input("Nhập số lượng cột ma trận 2 : "))
    matran2 = input_matran( hang_matran2, cot_matran2)

    print( tich(matran1, matran2) )
    return 0

if __name__=="__main__":
    main()
    