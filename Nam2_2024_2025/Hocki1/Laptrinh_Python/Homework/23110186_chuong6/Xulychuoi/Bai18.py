def xaucon_laplai(xaukitu):
    xaucon_lst = set()

    for i in range(len(xaukitu)):
        for j in range(i+1, len(xaukitu) + 1):
            xaucon = xaukitu[i : j]
            if xaukitu.count(xaucon) > 1:
                xaucon_lst.add(xaucon)
    return xaucon_lst

xaukitu =  input("Nhập vào một xâu kí tự : ") 
xaucon_laplai_lst = xaucon_laplai(xaukitu)
print(f"Xâu con lặp lại của xâu : '{xaukitu}' là : ")
for xaucon in xaucon_laplai_lst :
    print(xaucon)