#Tôn Hoàng Cầm 23110186
arr = []
so = float(input("Nhập vào lần lượt các số : "))
while( so !=0 ):
    arr = arr + [so]
    so = float(input())

max = arr[0]
for i in range(1, len(arr)):
    if(arr[i] > max):
        max = arr[i]
print("Số lớn nhất trong dãy số đã nhập là : ", max)