n = int(input("Nhập vào 1 số tự nhiên n : "))
lst_tu_nhien = []
for i in range(n+1):
    lst_tu_nhien.append(i)
    
lst_binhphuong = [x**2 for x in range(n)]
print("List các số tự nhiên từ 0 đến",n,"là:",lst_tu_nhien)
print("List các bình phương của các số nhỏ hơn",n,"là:",lst_binhphuong)