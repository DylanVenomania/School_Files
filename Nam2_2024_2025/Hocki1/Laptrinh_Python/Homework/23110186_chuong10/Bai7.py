import pandas as pd
import matplotlib.pyplot as plt

file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv"

data = pd.read_csv(file_path)

data.head()

profit_data = data[ ['month_number', 'total_profit'] ]

plt.figure( figsize = (10, 6) )
plt.bar(profit_data[ 'month_number'], profit_data['total_profit'], tick_label = profit_data['month_number'])

plt.title('Tổng lợi nhuận mỗi tháng')
plt.xlabel('Số tháng')
plt.ylabel('Tổng lợi nhuận')

plt.grid( axis = 'y', linestyle = '--', alpha = 0.7)
plt.show()