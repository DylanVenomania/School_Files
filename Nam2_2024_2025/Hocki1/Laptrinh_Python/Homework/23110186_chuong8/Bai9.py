import numpy as np

def broadcast( vec, n):
    chuyenthanhcot = vec.reshape(-1, 1)

    matran_cot = np.tile( chuyenthanhcot, ( 1, n))

    return matran_cot

def main():
    vector = np.array([])
    soluongcot = int(input("Nhập vào số lượng cột của ma trận : "))
    soluong = int(input("Nhập vào số lượng phần tử trong 1 vector : "))
    
    print("Nhập giá trị cho vector : ")
    for i in range( soluong ):
        value = float( input())
        vector = np.append(vector, value)
    
    print(f"Ma trận nhận được sau khi broacast vector :\n {broadcast(vector, soluongcot)}")
    return 0

if __name__=="__main__":
    main()