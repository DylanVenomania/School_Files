def filter_speed(lst, min):
    lst_speed = []
    lst_index = []
    for i in range(len(lst)):
        if( lst[i] < min ):
            lst_speed.append(lst[i])
            lst_index.append(i+1)
    return lst_speed, lst_index


def main():
    lst = input("Nhập vào các số nguyên là tốc độ quay của động cơ, mỗi giá trị cách nhau bởi khoảng trắng : ").split()
    lst = [int(value) for value in lst]
    min = int(input("Nhập vào giá trị min để lọc các tốc độ nhỏ hơn min : "))
    
    lst_speed, lst_index = filter_speed(lst, min)

    print(f"Các giá trị tốc độ quay động cơ nhỏ hơn {min} là {lst_speed}")
    print(f"Chỉ số các tốc độ quay đó trong danh sách cũ là {lst_index}")

if __name__ == "__main__":
    main()