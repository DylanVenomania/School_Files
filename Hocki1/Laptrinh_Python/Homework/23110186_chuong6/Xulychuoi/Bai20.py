def count_char(xaukitu):
    num_count = 0
    upper_count = 0
    lower_count = 0
    special_count = 0

    for chac in xaukitu:
        if chac.isdigit():
            num_count+=1
        elif chac.isupper():
            upper_count+=1
        elif chac.islower():
            lower_count+=1
        else:
            special_count+=1

    return num_count, upper_count, lower_count, special_count

def main():
    xaukitu =  input("Nhập vào một xâu kí tự : ") 
    num_cnt, upper_cnt, lower_cnt, spec_cnt = count_char(xaukitu)
    print(f"Số lượng ký tự số: {num_cnt}")
    print(f"Số lượng ký tự in hoa: {upper_cnt}")
    print(f"Số lượng ký tự thường: {lower_cnt}")
    print(f"Số lượng ký tự đặc biệt: {spec_cnt}")

if __name__ == "__main__":
    main()