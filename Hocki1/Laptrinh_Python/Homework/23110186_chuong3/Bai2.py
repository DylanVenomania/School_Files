import sys
n = int(input("Nhập vào số lượng phần tử cho một list : "))
while(n < 0):
    n = int(input("Số lượng không hợp lệ, xin nhập lại : "))
if(n == 0):
    print("List rỗng !")
    sys.exit()

lst = []
sum = 0
print("Nhập các giá trị cho list : ")
for i in range(n):
    temp = float(input())
    lst.append(temp)
    sum += temp
sum = sum/n
print("Trung bình cộng của tổng các phần tử trong danh sách là : ", sum)