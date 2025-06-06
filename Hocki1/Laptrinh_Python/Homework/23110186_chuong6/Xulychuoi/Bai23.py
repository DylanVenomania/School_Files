def ktra_email(email):
    if email.count('@') != 1:
        return False
    
    local_part, domain_part = email.split('@')

    if not local_part or not domain_part:
        return False

    if '.' not in domain_part or domain_part.endswith('.'):
        return False
    
    return True

def main():
    email = input("Nhập địa chỉ thư điện tử ( email ): ")

    if ktra_email(email):
        print(f"{email} là địa chỉ email hợp lệ!")
    else:
        print(f"{email} không hợp lệ. Vui lòng nhập lại !")

if __name__ == "__main__":
    main()