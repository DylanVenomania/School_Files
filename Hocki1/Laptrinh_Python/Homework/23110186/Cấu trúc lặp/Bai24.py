#Tôn Hoàng Cầm 23110186
import math
def khoangcach(x1, y1, x2, y2):
    return math.sqrt( (x2 - x1) ** 2 + (y2 - y1) ** 2)

def tinh_chuvi(toado):
    chuvi = 0
    n = len(toado)
    for i in range(n):
        x1, y1 = toado[i]
        x2, y2 = toado[(i + 1) % n]  
        chuvi += khoangcach(x1, y1, x2, y2)
    return chuvi

toado = []
print("Nhập các tọa độ điểm (x y). Nhập khoảng trắng cho x để kết thúc.")

while True:
    x_input = input("Nhập tọa độ x: ")
    if x_input.strip() == '':
        break  
    
    try:
        x = float(x_input)
        y = float(input("Nhập tọa độ y: "))
        toado.append((x, y))
    except ValueError:
        print("Vui lòng nhập số hợp lệ cho tọa độ x và y.")

if len(toado) >= 3:
    chuvi = tinh_chuvi(toado)
    print("\nDanh sách các tọa độ điểm đã nhập:")
    for point in toado:
        print(f"Tọa độ: {point}")
    
    print(f"\nChu vi của đa giác là: {chuvi:.2f}")
else:
    print("Cần ít nhất 3 điểm để tính chu vi của đa giác.")