def replace_string(xaukitu, kitucu, kituthaythe):
    xaukitu = xaukitu.replace(kitucu, kituthaythe)
    return xaukitu


xaukitu =  input("Nhập vào một xâu kí tự : ") 
print("".join(xaukitu) )

kitu_cu = input("Nhập vào từ cần thay thế :")
kitu_thaythe=  input("Nhập vào từ thay thế : ") 

print(f"Xâu kí tự sau khi thay đổi : {replace_string(xaukitu, kitu_cu, kitu_thaythe)}")
