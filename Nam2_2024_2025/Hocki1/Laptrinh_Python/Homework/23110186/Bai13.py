import math
danhsach_x = [math.pi , math.pi/2, math.pi*(4/3)]
def kiemtra(x):
    return (math.sin(x))**2 + (math.cos(x))**2 == 1
for x in danhsach_x:
    print('Sin^2(', x ,') + Cos^2(', x ,') = ', kiemtra(x))