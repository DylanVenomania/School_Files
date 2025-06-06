#Tôn Hoàng Cầm 23110186
def calculate_parity_bit(binary):
    if len(binary) != 8:
        print("Chuỗi nhị phân phải có đúng 8 bit.")
        return None
    
    if not all(bit in '01' for bit in binary):
        print("Chuỗi nhị phân chỉ được chứa các ký tự '0' và '1'.")
        return None
    
    dem = binary.count('1')
    parity_bit = '0' if dem % 2 == 0 else '1'
    return parity_bit

while True:
    binary = input("Nhập chuỗi nhị phân 8 bit (hoặc khoảng trắng để thoát): ").strip()
    if binary == '':
        break

    parity_bit = calculate_parity_bit(binary)
    if parity_bit is not None:
        print(f"Bit parity chẵn là: {parity_bit}")