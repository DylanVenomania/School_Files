def timtrungvi(lst):
    lst = sorted(lst)
    return lst[1]

while True:
    try:
        x = float(input("Nhập giá trị thứ nhất: "))
        y = float(input("Nhập giá trị thứ hai: "))
        z = float(input("Nhập giá trị thứ ba: "))
        lst = [x,y,z]
        trungvi = timtrungvi(lst)

        print(f"Trung vị của 3 giá trị {x}, {y}, {z} là: {trungvi}")
    except ValueError:
        print("Vui lòng nhập lại giá trị")
