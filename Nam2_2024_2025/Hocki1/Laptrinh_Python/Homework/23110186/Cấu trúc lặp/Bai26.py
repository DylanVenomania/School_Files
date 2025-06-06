#Tôn Hoàng Cầm 23110186
def thapphan_nhiphan(thapphan):
    if thapphan == 0:
        return '0'
    
    result = ''
    q = thapphan

    while q > 0:
        r = q % 2  
        result = str(r) + result  
        q = q // 2  
    return result

try:
    thapphan = int(input("Nhập số nguyên thập phân: "))
    if thapphan < 0:
        print("Số nguyên phải là số dương.")
    else:
        nhiphan = thapphan_nhiphan(thapphan)
        print(f"Số nhị phân tương ứng là: {nhiphan}")
except ValueError:
    print("Vui lòng nhập một số nguyên hợp lệ.")