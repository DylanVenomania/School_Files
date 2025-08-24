#Tôn Hoàng Cầm 23110186
arr = []
so = 1
print("Nhập vào các số : ")
while( so != 0):
    arr = arr + [so]
    so = float(input())

tong = 0
for i in range(len(arr)):
    if(arr[i] > 0 and arr[i] == int(arr[i])):
        tong = tong + arr[i]
print("Tổng các số nguyên dương : ", int(tong))