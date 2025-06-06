import string
def deci_bina(deci_value):
    if deci_value == 0:
        return "0"
    
    bina_value = ""

    while deci_value > 0:
        ghi_nho = deci_value % 2
        bina_value = str(ghi_nho) + bina_value
        deci_value //= 2
    
    return bina_value



def deci_hexa(deci_value):
    if deci_value == 0:
        return "0"
    
    hex_value = ""
    hex_digits = "0123456789ABCDEF"
    
    while deci_value > 0:
        ghi_nho = deci_value % 16
        hex_value = hex_digits[ghi_nho] + hex_value
        deci_value //= 16
    
    return hex_value



def bina_deci(binary_value):
    if not binary_value:
        return 0
    return int(binary_value[-1]) + 2 * bina_deci(binary_value[:-1])




def hexa_deci(hexadecimal_value):
    hex_digits = "0123456789ABCDEF"
    
    if not hexadecimal_value:
        return 0
    return hex_digits.index(hexadecimal_value[-1]) + 16 * hexa_deci(hexadecimal_value[:-1])


def main():
    flag = True
    while flag:
        print("1. Hệ thập phân (10) -> Hệ nhị phân (2)")
        print("2. Hệ nhị phân (2) -> Hệ thập phân (10)")
        print("3. Hệ thập phân (10) -> Hệ thập lục (16)")
        print("4. Hệ thập lục (16) -> Hệ thập phân (10)")

        choice = input("Nhập lựa chọn của bạn: ")
        if choice == '1':
            flag = False
            decimal_value = input("Nhập giá trị thập phân: ")
            try:
                decimal_value = int(decimal_value)
                binary_value = deci_bina(decimal_value)
                print(f"Giá trị nhị phân là: {binary_value}")
            except ValueError:
                print("Giá trị không hợp lệ.")


        elif choice == '2':
            flag = False
            binary_value = input("Nhập giá trị nhị phân: ")
            try:
                decimal_value = bina_deci(binary_value)
                print(f"Gía trị thập phân là: {decimal_value}")
            except ValueError:
                print("Giá trị không hợp lệ.")


        elif choice == '3':
            flag = False
            decimal_value = input("Nhập giá trị thập phân: ")
            try:
                decimal_value = int(decimal_value)
                hexadecimal_value = deci_hexa(decimal_value)
                print(f"Giá trị thập lục là: {hexadecimal_value}")
            except ValueError:
                print("Giá trị không hợp lệ.")
        

        elif choice == '4':
            flag = False
            hexadecimal_value = input("Nhập giá trị thập lục: ")
            try:
                decimal_value = hexa_deci(hexadecimal_value)
                print(f"Giá trị thập phân là: {decimal_value}")
            except ValueError:
                print("Giá trị không hợp lệ.")
        
        else:
            print("Lựa chọn không hợp lệ !")


if __name__ == "__main__":
    main()