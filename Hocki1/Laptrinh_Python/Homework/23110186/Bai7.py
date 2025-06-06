a = float(input())
b = float(input())
c = float(input())
delta = b**2 - 4*a*c
if(delta < 0):
    print('Nhập lại 3 số a, b, c: ')
else:
    ketqua = ( -b + delta**(1/2) ) / (2*a)
    print(ketqua)