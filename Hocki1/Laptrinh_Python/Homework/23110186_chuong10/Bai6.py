import pandas as pd
import matplotlib.pyplot as plt


bangdulieu = pd.read_csv("D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv")

months = bangdulieu['month_number']
bathingsoap_sales = bangdulieu['bathingsoap']


plt.figure(figsize=(10, 6))
plt.bar(months, bathingsoap_sales, color='green', label='Bathing Soap')


plt.title('Bathingsoap Sales data')
plt.xlabel('Month Number')
plt.ylabel('Number of units Sold')

plt.xticks([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
plt.yticks([1000, 2000, 4000, 6000, 8000, 10000, 12000, 15000, 18000])

plt.legend(loc ='upper left')

plt.show()

plt.savefig('doanh_so_xa_phong_tam.png')
