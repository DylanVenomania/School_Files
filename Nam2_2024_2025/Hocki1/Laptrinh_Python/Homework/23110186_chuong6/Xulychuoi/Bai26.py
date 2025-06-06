import string
import random

def random_password(size):
    if size < 8:
        print("Độ dài mật khẩu phải ít nhất 8 ký tự !")
        return None
    
    lower = string.ascii_lowercase 
    upper = string.ascii_uppercase  
    digit = string.digits  
    dacbiet = string.punctuation 

    password = [
        random.choice(lower),
        random.choice(upper),
        random.choice(digit),
        random.choice(dacbiet)
    ]

    all_kytu = lower + upper + digit + dacbiet
    while len(password) < size:
        password.append( random.choice(all_kytu) )
        
    random.shuffle(password)

    return ''.join(password)


def main():
    size = int(input("Nhập độ dài mật khẩu muốn tạo: "))
    password = random_password(size)
    if password:
        print("Mật khẩu ngẫu nhiên : ", password)

if __name__ == "__main__":
    main()
