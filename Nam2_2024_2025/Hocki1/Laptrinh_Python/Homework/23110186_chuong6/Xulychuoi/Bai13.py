def isReverse(xaukitu1, xaukitu2):
    if len(xaukitu1) != len(xaukitu2):
        return False
    for i in range( len(xaukitu1) ):
        if xaukitu1[i] != xaukitu2[ len(xaukitu2) -1 - i]:
            return False
    return True

xaukitu1 = input("Nhập vào một xâu kí tự : ")
xaukitu2 = input(f"Nhập vào xâu kí tự mà bạn muốn kiểm tra có phải là đảo ngược của xâu '{xaukitu1}' không ? : ")

if isReverse(xaukitu1, xaukitu2):
    print(f"Xâu : '{xaukitu1}' và xâu : '{xaukitu2}' là đảo ngược của nhau!")
else:
    print(f"Xâu : '{xaukitu1}' và xâu : '{xaukitu2}' không là đảo ngược của nhau!")