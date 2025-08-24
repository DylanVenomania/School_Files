
import pandas as pd
import matplotlib.pyplot as plt


df = pd.read_csv("D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong10/company_sales_data.csv")
profitlist = df['total_profit'].tolist()
monthlist = df['month_number'].tolist()

total_profit = df.groupby('month_number')['total_profit'].sum()

profitlist = total_profit.tolist()
monthlist = total_profit.index.tolist()


plt.figure(figsize=(10, 6))
plt.plot(monthlist, profitlist, 
         linestyle='--', color='red', 
         marker='o', markerfacecolor='black', 
         linewidth=3,
         label='Profit data of last year')



plt.xlabel("Month Number")

plt.title("Company Sales data of last year")
plt.xticks([1,2,3,4,5,6,7,8,9,10,11,12])
plt.yticks([100000,200000,300000,400000,500000])


plt.legend(loc='lower right')

plt.show()