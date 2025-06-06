def toiuu_string(xaukitu):
    xaukitu = xaukitu.strip()
    
    toiuu_string = " ".join(xaukitu.split())
    
    return toiuu_string

def main():
    xaukitu = input("Nhập một chuỗi cần tối ưu: ")
    toiuu_xau = toiuu_string(xaukitu)
    print(f"Chuỗi sau khi tối ưu: '{toiuu_xau}'")

if __name__ == "__main__":
    main()