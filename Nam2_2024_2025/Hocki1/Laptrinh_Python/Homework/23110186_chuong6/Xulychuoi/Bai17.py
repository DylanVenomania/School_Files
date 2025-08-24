def xaucon_khacnhau(xaukitu):
    xaucon_lst = set()
    for i in range( len(xaukitu) ):
        for j in range(i+1, len(xaukitu) + 1):  #số lượng phần tử bỏ vào xâu con
            xaucon = xaukitu[i:j]
            xaucon_lst.add(xaucon)
    return xaucon_lst

xaukitu =  input("Nhập vào một xâu kí tự : ") 
xaucon_lst = xaucon_khacnhau(xaukitu)
print(f"Các xâu con khác nhau trong xâu kí tự :'{xaukitu}' là :")
for xaucon in xaucon_lst:
    print(xaucon)