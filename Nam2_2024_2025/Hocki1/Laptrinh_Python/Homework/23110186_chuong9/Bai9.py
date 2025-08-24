import numpy as np

def broadcast(vector, n):

    if len(vector.shape) !=1 :
        raise ValueError("Vector cần là một vector 1D")
    
    ketqua = np.tile(vector.reshape(-1, 1) , n)
    return ketqua

def nhap():
    while True:
        try:
            print("Nhập vector(cách nhau bởi khoảng trắng ):")
            vector_input = input().strip()
            vector = np.array( [int(x) for x in vector_input.split() ])

            print("Nhập số cột cần broadcast: ")
            n = int(input().strip() )

            if n<= 0:
                raise ValueError("Số cột phải là một số nguyên dương !")
            
            return vector, n
        except ValueError:
            print(f"Lỗi nhập, vui lòng nhập lại !")


vector, n = nhap()

ketqua_broadcast = broadcast(vector, n)

print(f"\nKết quả broadcast : \n{ketqua_broadcast}")