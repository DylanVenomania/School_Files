from math_operations.quadratic_solver import solve_quadratic
from math_operations.sort_ascending import sort_ascending
from math_operations.sort_descending import sort_descending

def main():
    
    print("Tìm nghiệm của phương trình bậc 2:")
    a = float(input("Nhập a: "))
    b = float(input("Nhập b: "))
    c = float(input("Nhập c: "))
    roots = solve_quadratic(a, b, c)
    print("Nghiệm của phương trình:", roots)

    
    arr = list(map(int, input("Nhập một dãy số nguyên cách nhau bởi dấu cách: ").split()))
    
    ascending = sort_ascending(arr)
    descending = sort_descending(arr)
    
    print("Mảng sắp xếp tăng dần:", ascending)
    print("Mảng sắp xếp giảm dần:", descending)

if __name__ == "__main__":
    main()