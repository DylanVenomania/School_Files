import string

def lst_xaucon(xaukitu):
    xaukitu_temp = []
    max = []
    for i in range(len(xaukitu)):
        if xaukitu[i] not in max:
            max.append(xaukitu[i])
        else:
            xaukitu_temp.append(max)
            max = []
            max.append(xaukitu[i])

    return xaukitu_temp

def max_xaucon(xaukitu):
    max = xaukitu[0]
    for xaucon in xaukitu:
        if len(xaucon) > len(max) :
            max = xaucon
    return max

xaukitu = str(input("Nhập vào một xâu kí tự : "))
print("Xâu con không trùng kí tự dài nhất trong xâu kí tự là : ", "".join( max_xaucon( lst_xaucon(xaukitu) ) ) )
        



