import cv2
import os 

def convert_gray (input_path, output_path):
    count =  0
    for filename in os.listdir( input_path):
        #1. Tạo đường dẫn của tên file mới sau khi chuyển màu
        file_input_path = os.path.join( input_path, filename)
        file_output_path = os.path.join( output_path, 'Gray_'+ filename)

        #2. Đọc ảnh
        image = cv2.imread(file_input_path)
        if image is None :
            print(f"Lỗi : Không thể mở ảnh {filename}!")
            continue

        #3. Chuyển màu
        image_gray = cv2.cvtColor( image, cv2.COLOR_BGR2GRAY )

        #4. Lưu ảnh
        cv2.imwrite( file_output_path, image_gray)
        print(f"Chuyển đổi thành công {filename} --> {'Gray_' + filename}")
        count += 1

    if count == 0 :
        print(f"Không có file ảnh trong đường dẫn {input_path}")
    else :
        print(f"Đã chuyển {count} ảnh sang ảnh xám và lưu trong {output_path}")



def convert_gray_overwrite (input_path, output_path):
    count = 0
    for filename in os.listdir( input_path):
        #1. Tạo đường dẫn cho file ảnh mới sau khi chuyển màu
        file_input_path = os.path.join( input_path, filename)
        file_output_path = os.path.join(input_path, filename)

        #2. Đọc ảnh
        image = cv2.imread( file_input_path)
        if image is None:
            print(f"Lỗi : Không thể mở ảnh {filename}!")
            continue

        #3. Chuyển màu
        image_gray = cv2.cvtColor( image, cv2.COLOR_BGR2GRAY)

        #4. Lưu ảnh
        cv2.imwrite( file_output_path, image_gray)
        print(f"Chuyển đổi thành công {filename} thành ảnh xám")
        count += 1

    if count == 0 :
        print(f"Không có file ảnh trong đường dẫn {input_path}")
    else :
        print(f"Đã chuyển {count} ảnh sang ảnh xám và lưu trong {output_path}")


def main():
    input_path = "E:/DigitalImageProcessingPics"
    output_path = input_path
    output_path2 = "E:/DigitalImageProcessingGrayPics"

    if not os.path.exists(input_path):
        os.makedirs(input_path)
        print(f"Đã tạo thư mục đầu vào: {input_path}")

    choose = 0

    while (choose != None) :
        print(f"Hãy chọn loại chuyển ảnh sang xám mà bạn muốn : \n1.Chuyển ảnh sang xám không ghi đè\n2.Chuyển ảnh sang xám ghi đè\n3.Thoát")
        choose = int( input("Hãy nhập số : ") )
        if choose == 1 :  
            if not os.path.exists(output_path2):
                os.makedirs(output_path2)
                print(f"Đã tạo thư mục đầu ra: {output_path2}")
            convert_gray(input_path, output_path2)
            print("\n////////")
        elif choose == 2: 
            convert_gray_overwrite (input_path, output_path)
            print("\n////////")
        elif choose == 3:
            break
        else :
            print(f"Lựa chọn không tồn tại, xin hãy chọn lại !")
            print("\n////////")



if __name__ == "__main__":
    main()