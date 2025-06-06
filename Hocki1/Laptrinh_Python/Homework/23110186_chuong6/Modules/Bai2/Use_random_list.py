from random_list import generate_random_list

def main():
    n = int(input("Nhập số lượng phần tử :"))
    min_value = int(input("Nhập giá trị nhỏ nhất: "))
    max_value = int(input("Nhập giá trị lớn nhất: "))
    
    random_numbers = generate_random_list(n, min_value, max_value)
    print("Dãy số ngẫu nhiên là:", random_numbers)

if __name__ == "__main__":
    main()