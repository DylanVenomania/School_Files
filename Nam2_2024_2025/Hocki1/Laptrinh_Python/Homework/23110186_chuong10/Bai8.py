import pandas as pd
import matplotlib.pyplot as plt

file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv"

data = pd.read_csv(file_path)

data.head()

sales_columns = ['facecream', 'facewash', 'toothpaste', 'bathingsoap', 'shampoo', 'moisturizer']
total_sales = data[sales_columns].sum()

sales_phantram = (total_sales/ total_sales.sum() )*100

plt.figure(figsize = (8, 8))
plt.pie(sales_phantram, labels = sales_columns,autopct='%1.1f%%', startangle=140 )

plt.title('Tổng dữ liệu bán hàng từng sản phẩm')
plt.show()