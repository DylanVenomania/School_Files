def remove_dupli(xaukitu):
    xaukitu_new = []
    for i in range( len(xaukitu)):
        if( xaukitu.count(xaukitu[i] ) == 1):
            xaukitu_new.append(xaukitu[i])
    return xaukitu_new

xaukitu = input("Nhập vào một xâu kí tự : ")
print("Xâu kí tự sau khi xoá các kí tự trùng : ", ''.join(remove_dupli(xaukitu) ) )