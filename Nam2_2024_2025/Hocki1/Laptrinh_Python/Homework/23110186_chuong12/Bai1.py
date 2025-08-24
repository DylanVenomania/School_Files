import pandas as pd
import matplotlib.pyplot as plt

# a. Đọc dữ liệu từ tập tin
file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong12/Churn_Modelling.csv"
data = pd.read_csv(file_path, index_col = "RowNumber")

print(f"Danh sách các header : \n{data.head()}" )

# b.Thống kê mô tả
print("\nThống kê mô tả dữ liệu : ")
print(data.describe())

# c. Trung bình credit score theo geography
trungbinh_credit = data.groupby( 'Geography')['CreditScore'].mean() 
print(f"\nTrung bình credit score theo geography : {trungbinh_credit}")


# d. Phân thành 5 tuổi, mỗi nhóm chiếm 20% 
data['AgeGroup'] = pd.qcut( data['Age'],5, labels = ['Group 1', 'Group 2', 'Group 3', 'Group 4', 'Group 5'] )

# e. Vẽ biểu đồ barchart thống kê số lượng khách hàng theo nhóm các tuổi
age_group_count = data['AgeGroup'].value_counts()
plt.figure( figsize = (10, 6))
age_group_count.sort_index().plot( kind = 'bar' )

plt.title("Số lượng khách hàng theo nhóm tuổi")
plt.xlabel("Nhóm độ tuổi")
plt.ylabel("Số lượng khách hàng")

plt.grid(axis = 'y', linestyle = '--', alpha = 0.7)
plt.tight_layout()
plt.show()