import os

def get_filename_with_extension(file_path):
    return os.path.basename(file_path)

def get_filename_without_extension(file_path):
    return os.path.splitext(os.path.basename(file_path))[0]

def main():
    file_path = input("Nhập đường dẫn tệp: ")

    filename_with_extension = get_filename_with_extension(file_path)
    print("Tên tệp cùng với phần mở rộng:", filename_with_extension)
    
    filename_without_extension = get_filename_without_extension(file_path)
    print("Tên tệp không có phần mở rộng:", filename_without_extension)

if __name__ == "__main__":
    main()