import pandas as pd

file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong12/u.user"

data = pd.read_csv(file_path, sep='|', header=None, names=['user_id', 'age', 'gender', 'occupation', 'zip_code'])

data = data[1:]

data['age'] = data['age'].astype(int)

data.head()

age_trungbinh_nghe = data.groupby('occupation')['age'].mean()

phantram_nghe = ( data['occupation'].value_counts(normalize=True) * 100 ).sort_values(ascending=False)

min_max_age = data.groupby('occupation')['age'].agg(['min', 'max'])

age_trungbinh_tohop = data.groupby(['occupation', 'gender'])['age'].mean()

phantram_gioitinh = ( data.groupby(['occupation', 'gender']).size() .unstack(fill_value=0) .apply(lambda x: (x / x.sum()) * 100, axis=1))

print("\nTỷ lệ phần trăm giới tính theo nghề nghiệp:")
print(phantram_gioitinh)

# Tùy chọn: Lưu các kết quả ra tệp CSV
age_trungbinh_nghe.to_csv("average_age_by_occupation.csv", index=True)
phantram_nghe.to_csv("occupation_percentage.csv", index=True)
min_max_age.to_csv("min_max_age_by_occupation.csv", index=True)
age_trungbinh_tohop.to_csv("average_age_by_occupation_gender.csv", index=True)
phantram_gioitinh.to_csv("gender_percentage_by_occupation.csv", index=True)