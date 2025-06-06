def toiuu_string(xaukitu):
    words = xaukitu.strip().split()
    
    toiuu_words = [word.capitalize() for word in words]
    
    toiuu_string = ' '.join(toiuu_words)
    return toiuu_string

def main():
    xaukitu = input("Nhập vào chuỗi: ")
    
    result = toiuu_string(xaukitu)
    
    print("Chuỗi tối ưu là:", result)

if __name__ == "__main__":
    main()