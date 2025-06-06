input_string = input("Nhập một chuỗi ký tự: ")
letter_count = 0
digit_count = 0

for char in input_string:
    if char.isalpha():  
        letter_count += 1
    elif char.isdigit():  
        digit_count += 1
print(f"Số chữ cái trong chuỗi: {letter_count}")
print(f"Số chữ số trong chuỗi: {digit_count}")