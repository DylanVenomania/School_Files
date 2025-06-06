import pandas as pd
def creat(file_path,new):
    """
    Chức năng:
    Thêm một dòng mới vào file CSV

    Tham số:
    file_path(str): Đường dẫn file CSV cần xử lý
    new(list): Danh sách các giá trị của mỗi tường dữ liệu:
            [Date, Country/Region, Confirmed, Deaths, Recovered, Active, New_cases, New_deaths, New_recovered, WHO_Region].
    """
    #Đọc dữ liệu file csv vào DataFrame
    df=pd.read_csv(file_path)
    #Tạo dòng mới
    new_row=pd.Series(new,index=df.columns)
    #Thêm dòng mới vào DataFrame
    df.loc[len(df)]=new_row
    #Lưu lại DataFrame vào file csv
    df.to_csv(file_path,index=False)
    print("Dòng mới đã được thêm vào.")
