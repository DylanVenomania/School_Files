def upper_lower(xaukitu):
    xaukitu_new = []
    for chac in xaukitu:
        if chac.isupper():
            xaukitu_new.append(chac.lower())
        else:
            xaukitu_new.append(chac.upper())
    return xaukitu_new

xaukitu = input("Nhập vào một xâu kí tự : ") 
print("".join(upper_lower(xaukitu)))
