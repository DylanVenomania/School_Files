def negative_in_string(xaukitu):
    num = ''
    so_am = []

    for i in range(len(xaukitu)):
        if xaukitu[i] == '-' and xaukitu[i+1].isdigit()  and ( i + 1 < len(xaukitu) ):
            num = '-'  

        elif xaukitu[i].isdigit():
            num += xaukitu[i]  

        else:
            if num:  
                so_am.append( int(num) )  
                num = ''  
    if num: 
        so_am.append( int(num) )

    so_am = [num for num in so_am if num < 0]
    if so_am:
        print("Các số nguyên âm trong chuỗi là:", so_am)
    else:
        print("Không có số âm trong chuỗi !")

def main():
    xaukitu = input("Nhập vào một chuỗi : ")
    negative_in_string(xaukitu)

if __name__ == "__main__":
    main()