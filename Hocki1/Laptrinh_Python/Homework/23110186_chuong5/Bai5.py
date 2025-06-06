import string
def security(password):
    chuThuong = [chac for chac in password if chac.islower()]
    chuHoa = [chac for chac in password if chac.isupper()]
    so = [chac for chac in password if chac.isdigit()]

    if( len(password) >= 8 and len(chuThuong) != 0 and len(chuHoa) != 0 and len(so)!=0):
        return True
    return False

def main():
    
    password = input("Nhập vào mật khẩu : ")
    if(security(password)):
        print(f"Mật khẩu của bạn : {password} là có tính bảo mật cao !")
    else:
        print(f"Mật khẩu của bạn : {password} là có tính bảo mật không cao !")

if __name__ == "__main__":
    main()