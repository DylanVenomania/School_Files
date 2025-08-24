import numpy as np

sales_data = np.random.randint( 10, 100, size = (2, 7))
print(f"Số lượng hàng hoá bán ra trong tuần : dòng 1 : sáng, dòng 2 : chiều \n{sales_data}")


daily_total = np.sum( sales_data, axis = 0 ) 
max_sales_day = np.argmax( daily_total )
print(f"\nNgày bán được nhiều nhất tuần ( theo tổng số hàng của 2 buổi ) là ngày thứ {max_sales_day + 1}")


max_sales = np.max(sales_data)
max_sales_index = np.unravel_index( np.argmax(sales_data), sales_data.shape) #lấy index buổi bán nhiều nhất theo mảng 1D 
                                                                            #sau đó ánh xạ sang 2d thông qua sales_data.shape
                                                                            #sẽ được 2 chỉ mục tương ứng với buổi và ngày
buoi, ngay = max_sales_index 

print(f"\nThời điểm bán được nhiều nhất : \nBuổi {'sáng' if buoi == 0 else 'chiều'}, ngày {ngay + 1}, bán {max_sales} hàng")


more_sang = 0
more_chieu = 0

for day in range(sales_data.shape[1]):
    if sales_data[0, day] >  sales_data[1, day]:
        more_sang +=1 
    elif sales_data[0, day] < sales_data[1, day]:
        more_chieu +=1
    
if more_sang > more_chieu :
    ketqua = "Buổi sáng bán được nhiều hơn !"
elif more_sang < more_chieu :
    ketqua = "Buổi chiều bán được nhiều hơn !"
else:
    ketqua = "Cả 2 buổi như nhau !"

print(f"\n{ketqua}")