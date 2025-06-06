def xau_asc2(xaukitu):
    xau_temp = [ ord(kitu) for kitu in xaukitu]
    return xau_temp

def asc2_xau(xaukitu):
    xau_temp = "".join( [ chr(kitu) for kitu in xaukitu] )
    return xau_temp

def main():
    print("Menu : ")
    print("1. Chuyển từ xâu kí tự sang mã ASCII")
    print("2. Chuyển từ mã ASCII sang xâu kí tự")
    flag = False
    while flag == False:
        choose = input("Xin chọn yêu cầu :")
        if choose == '1':
            xaukitu =  input("Nhập vào một xâu kí tự : ") 
            xaukitu = xau_asc2(xaukitu)
            print(f"Sau khi chuyển đổi : {xaukitu}")
            flag = True
        elif choose == '2':
            xaukitu =  input("Nhập vào danh sách mã ASCII, cách nhau bởi dấu cách : ")
            xaukitu = [ int(kitu) for kitu in xaukitu.split() ]

            xaukitu = asc2_xau(xaukitu)
            print(f"Sau khi chuyển đổi : {xaukitu}")
            flag = True
        else:
            print("Yêu cầu không hợp lệ !")
            flag = False

if __name__ == "__main__":
    main()