def is_symmetrical(xaukitu):
    size = len(xaukitu)
    
    if size % 2 == 0:
        left = xaukitu[:size // 2]
        right = xaukitu[size // 2:]
    else:
        left = xaukitu[:size // 2]
        right = xaukitu[size // 2 + 1:]
    
    if left == right:
        return True
    else:
        return False

def main():
    s = input("Nhập vào một chuỗi: ")
    if is_symmetrical(s):
        print(f"'{s}' là chuỗi symmetrical.")
    else:
        print(f"'{s}' không là chuỗi symmetrical.")

if __name__ == "__main__":
    main()