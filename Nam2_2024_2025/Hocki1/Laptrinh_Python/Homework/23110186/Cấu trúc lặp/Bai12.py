#Tôn Hoàng Cầm 23110186
arr = []
so = 1
print("Nhập vào số nguyên : ")
while(so != 0):
    arr = arr + [so]
    so = int(input())

dem = 0
for i in range(len(arr)):
    if(arr[i] < 0):
        dem += 1
print("Có", dem, "số âm trong dãy !")
