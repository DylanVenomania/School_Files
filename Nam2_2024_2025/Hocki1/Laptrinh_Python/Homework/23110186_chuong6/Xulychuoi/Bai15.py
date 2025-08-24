def tim_xaucon(xaukitu, min_size):
    lst_xaucon = []
    for i in range(len(xaukitu)):
        for j in range( i + min_size, len(xaukitu)):
            xaucon = []
            for k in range(i, j):
                xaucon.append(xaukitu[k])
            lst_xaucon.append("".join(xaucon ))
    return lst_xaucon


xaukitu =  input("Nhập vào một xâu kí tự : ") 
min_size = int(input("Nhập vào độ dài tối thiểu : "))

lst_xaucon = tim_xaucon(xaukitu,min_size)
print(f"Các xâu con có độ dài kí tự >= {min_size} trong xâu : '{xaukitu}' :")
for xaucon in lst_xaucon:
    print(xaucon)
