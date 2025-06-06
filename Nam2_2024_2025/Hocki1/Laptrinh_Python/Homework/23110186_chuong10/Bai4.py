import pandas as pd
import numpy as np
import matplotlib.pyplot as plt

file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv"
data = pd.read_csv(file_path)

bán_kem_đánh_răng = data['toothpaste'].values
số_tháng = np.arange(1, len(bán_kem_đánh_răng) + 1)

plt.figure(figsize=(8, 6))
plt.scatter(số_tháng, bán_kem_đánh_răng, color='blue', marker='o', label='Tooth paste sales data')
plt.grid(linestyle='--', linewidth=1)
plt.title('Tooth paste sales data')
plt.xlabel('Month number')
plt.ylabel('Number of units sold')
plt.xticks(số_tháng)


plt.legend()


plt.show()
