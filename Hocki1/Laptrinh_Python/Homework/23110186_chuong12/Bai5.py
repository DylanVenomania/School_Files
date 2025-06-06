import pandas as pd
import os

file_path = "d:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong12/wind.data"

if not os.path.exists(file_path):
    print("Tệp không tồn tại. Vui lòng kiểm tra lại đường dẫn.")
    exit()


data = pd.read_csv(file_path, sep=r'\s+')

try:
    data['Yr'] = data['Yr'] + 1900 
    invalid_rows = data[(data['Mo'] < 1) | (data['Mo'] > 12) | (data['Dy'] < 1) | (data['Dy'] > 31)]
    if not invalid_rows.empty:
        print("\nCác hàng không hợp lệ (sẽ bị loại bỏ):")
        print(invalid_rows)
        data = data.drop(invalid_rows.index)

    data['Yr_Mo_Dy'] = pd.to_datetime(data[['Yr', 'Mo', 'Dy']], errors='coerce')
    data = data.dropna(subset=['Yr_Mo_Dy'])  
    data.set_index('Yr_Mo_Dy', inplace=True)  
except Exception as e:
    print("\nKhông thể tạo cột ngày tháng 'Yr_Mo_Dy':", e)
    print("Tiếp tục với dữ liệu ban đầu mà không sử dụng ngày tháng.")

value_counts = data.iloc[:, 3:].count()
missing_counts = data.iloc[:, 3:].isnull().sum()

mean_wind_speed = data.iloc[:, 3:].mean().mean()

loc_stats = data.iloc[:, 3:].agg(['min', 'max', 'mean', 'std'])


print("\nSố lượng giá trị hiện có ở mỗi cột (RPT → MAL):")
print(value_counts)
print("\nSố lượng giá trị còn thiếu ở mỗi cột (RPT → MAL):")
print(missing_counts)
print("\nTốc độ giá trung bình toàn bộ dữ liệu:")
print(mean_wind_speed)
print("\nThống kê tốc độ gió (loc_stats):")
print(loc_stats)