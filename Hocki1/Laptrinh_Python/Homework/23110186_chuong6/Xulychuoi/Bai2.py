xaukitu =  input("Nhập vào một xâu kí tự : ")
xaukitu_new = []
for i in range(len(xaukitu)-1, -1, -1):
    xaukitu_new.append(xaukitu[i])

print("Xâu kí tự sau khi đảo ngược : ", ''.join(xaukitu_new) )