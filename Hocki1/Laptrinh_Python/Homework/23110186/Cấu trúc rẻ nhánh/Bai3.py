# Tôn Hoàng Cầm 23110186 
year = int(input("Nhập vào năm muốn xét có là năm nhuận hay không : "))
if(year > 0 and ( year % 400 == 0 or (year % 4 == 0 and year % 100 !=0 )) ):
    print("Nam ", year, " la nam nhuan !")
else:
    print("Nam ", year, " khong la nam nhuan !")