# Hàm Title : 
# Tác dụng : dùng để chuyển đổi chuỗi thành dạng mỗi từ trong chuỗi sẽ bắt đầu bằng một chữ cái viết hoa, các ký tự còn lại sẽ được viết thường.

text = "xIn chÀo MọI NGƯời !"
title_text = text.title()
print(title_text)


# Hàm Translate
# Tác dụng : để thay thế các ký tự trong chuỗi dựa trên một bảng ánh xạ. 
# Bảng này được tạo ra bởi hàm maketrans(), cho phép chuyển đổi từng ký tự của chuỗi ban đầu thành ký tự tương ứng trong bảng ánh xạ.

table = str.maketrans("abcde", "12345")

text = "Hello, nice to meet you !"
translated_text = text.translate(table)
print(translated_text)