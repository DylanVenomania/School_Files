# Tôn Hoàng Cầm 23110186 
print("Nhập lần lượt 2 số nguyên dương:")
a, b = int(input()), int(input())
while(a <= 0):
    a = int(input("Nhập lại a : "))
while(b <= 0):
    b = int(input("Nhập lại b : "))    

if(a % 2 == 0 or b % 2 == 0):
    if (a % 2 == 0 and b % 2 == 0):
        print("a va b la 2 so chan")
    else:
        print("chi co mot so chan")
if(a % 2 != 0 and b % 2 != 0):
    print("a, b la hai so le")