#Tôn Hoàng Cầm 23110186
n = int(input("Nhập một số nguyên dương n : "))
while(n <= 0):
    n = int(input("Vui lòng nhập lại "))
sum1, sum2, sum3, sum4 = 0, 0, 0, 0

i =1
temp = 0
while(i <= n):
    sum1 = sum1 + 1/(temp + i)
    temp = temp + i
    i += 1
print("Tổng thứ 1 = ", sum1)

i =1
while(i <= n):
    sum2 = sum2 + 1/(i*(i + 1))
    i +=1
print("Tổng thứ 2 = ", sum2)

i =1
while(i <= n):
    sum3 = sum3 + i/(i + 1)
    i +=1
print("Tổng thứ 3 = ", sum3)

i =0
while(i <= n):
    sum4 = sum4 + (2*i + 1)/(2*i + 2)
    i +=1
print("Tổng thứ 4 = ", sum4)