import math as m
def find_roots(a, b, c):
    lst_roots = []
    delta = b**2 - 4*a*c
    if delta > 0 :
        root1 = (-b + m.sqrt(delta)) / (2*a)
        lst_roots.append(root1)

        root2 = (-b - m.sqrt(delta)) / (2*a)
        lst_roots.append(root2)

    elif delta == 0 :
        root = -b / (2*a)
        lst_roots.append(root)

    return lst_roots


def main():
    print("Nhập lần lượt các giá trị a, b, c cho hàm bậc 2 : ax2 + bx + c =  0")
    a = float(input("Nhập a :"))
    b = float(input("Nhập b :"))
    c = float(input("Nhập c :"))

    lst_roots =  find_roots(a,b,c)
    if len(lst_roots) == 0:
        print("Phương trình vô nghiệm !")
    elif len(lst_roots) == 1 :
        print(f"Phương trình có nghiệm kép là : {lst_roots}")
    else :
        print(f"Phương trình có 2 nghiệm riêng biệt là : {lst_roots}")

if __name__ == "__main__":
    main()