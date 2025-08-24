# Tôn Hoàng Cầm 23110186 
import math
print("Nhập vào lần lượt các giá trị a, b, c tương ứng phương trình bậc 2 sau : ax^2 + bx + c = 0 " )
a = float(input("Nhập a : "))
b= float(input("Nhập b : "))
c= float(input("Nhập c : "))
delta = b**2 - 4*a*c
if(delta >= 0):
    if(delta > 0):
        root1 = (-b + math.sqrt(delta))/a
        root2 = (-b - math.sqrt(delta))/a
        print("Phương trình co 2 nghiệm riêng biệt : ", root1, " và " , root2)
    elif(delta == 0):
        root = -b/(2*a)
        print("Phương trình có nghiệm kép : ", root)
else:
    print("Phương trình vô nghiệm ")
