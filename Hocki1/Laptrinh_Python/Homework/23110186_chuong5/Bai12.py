import math as m

def cosin_taylor(x, gioihan = 1e-10 ):
    current_value = 1.0
    cos_value = current_value  
    index = 1 
    while True:
        current_value *= (-1) * (x ** 2) / ( 2 * index * (2 * index - 1) )  
        if abs(current_value) < gioihan:  
            break
        cos_value += current_value  
        index += 1  
    return cos_value

def main():
    x = float(input("Nhập giá trị x ( radian ) để tính cos theo Taylor: "))
    x = x % ( 2 * m.pi)
    
    print(f"cos({x}) theo chuỗi Taylor là: {cosin_taylor(x)}" )
    

if __name__ == "__main__":
    main()