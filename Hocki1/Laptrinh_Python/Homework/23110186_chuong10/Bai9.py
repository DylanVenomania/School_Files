import pandas as pd
import matplotlib.pyplot as plt


file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv"
data = pd.read_csv(file_path)

months = data['month_number']
bathingsoap_sales = data['bathingsoap']
facewash_sales = data['facewash']

fig, (ax1, ax2) = plt.subplots(2, 1, figsize=(8, 6))

ax1.plot(months, bathingsoap_sales, color='black', marker='o')
ax1.set_title('Sales data of a Bathingsoap')
ax1.set_yticks([7500, 10000, 12500])
ax1.set_xticks([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])


ax2.plot(months, facewash_sales, color='red', marker='o')
ax2.set_title('Sales data of a facewash')
ax2.set_xlabel('Month Number')
ax2.set_ylabel('Sales units in number')
ax2.set_xticks([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12])
ax2.set_yticks([1500, 2000])

plt.subplots_adjust(hspace=0.3)

plt.show()