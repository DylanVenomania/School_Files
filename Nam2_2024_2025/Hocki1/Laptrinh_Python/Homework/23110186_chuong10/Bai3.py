import pandas as pd
import matplotlib.pyplot as plt

df = pd.read_csv("D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv")

plt.plot(df['month_number'], df['facecream'], label='Face Cream', marker='o', linewidth=3)

plt.plot(df['month_number'], df['facewash'], label='Face Wash', marker='o', linewidth=3)

plt.plot(df['month_number'], df['toothpaste'], label='Toothpaste', marker='o', linewidth=3)

plt.plot(df['month_number'], df['bathingsoap'], label='Bathing Soap', marker='o', linewidth=3)

plt.plot(df['month_number'], df['shampoo'], label='Shampoo', marker='o', linewidth=3)

plt.plot(df['month_number'], df['moisturizer'], label='Moisturizer', marker='o', linewidth=3)

plt.title('Sales data')
plt.xlabel("Month number")
plt.ylabel("Sales units in number")

plt.xticks([1,2,3,4,5,6,7,8,9,10,11,12])
plt.yticks([1000,2000,4000,6000,8000,10000,12000,15000,18000])

plt.legend(loc='upper left')

plt.show()