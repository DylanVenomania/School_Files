#Tôn Hoàng Cầm 23110186
x = float(input("Nhập một số x bất kì không âm để tính căn bậc 2 : "))
guess = x/2
while( abs( guess**2 - x) > (1e-12)  ):
    guess = ( guess + (x/guess) ) /2

print("Kết quả căn bậc 2 của",x,":", guess)