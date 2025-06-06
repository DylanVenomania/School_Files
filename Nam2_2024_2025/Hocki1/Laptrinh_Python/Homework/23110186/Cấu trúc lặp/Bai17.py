#Tôn Hoàng Cầm 23110186
n = int(input("Nhập một số nguyên dương n : "))
while(n <= 0):
    n = int(input("Vui lòng nhập lại n : "))

sum1, sum2 = 0, 0
for i in range(1,n+1):
    sum1 = sum1 + 1/( i*(i + 1) )
for i in range(n+1):
    sum2 = sum2 + (2*i + 1)/ (2*i + 2)

print("Tổng 1 là = ", sum1)
print("Tổng 2 là = ", sum2)
