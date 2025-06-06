import string
def security(password):
    if len(password) < 8:
        return False
    
    chu_cai_flag = False
    chu_so_flag = False
    dacbiet_flag = False

    for char in password:
        if char.isalpha():  
            chu_cai_flag = True
        elif char.isdigit():  
            chu_so_flag = True
        else : 
            dacbiet_flag = True

    if chu_cai_flag and chu_so_flag and dacbiet_flag:
        return True
    else:
        return False

def main():
    
    password = input("Nhập vào mật khẩu : ")
    if(security(password)):
        print(f"Mật khẩu của bạn : {password} là mật khẩu mạnh !")
    else:
        print(f"Mật khẩu của bạn : {password} là mật khẩu không mạnh!")

if __name__ == "__main__":
    main()