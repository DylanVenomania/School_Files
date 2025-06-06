def count_appear(xaukitu, xaucon):
    return xaukitu.count(xaucon)

xaukitu = input("Nhập vào một xâu kí tự : ")
xaucon = input("Nhập vào một xâu con, để tìm số lần xuất hiện trong xâu kí tự: ")
print("Số lần xuất hiện của '", xaucon, "' trong chuỗi '", xaukitu, "' là : ", count_appear(xaukitu, xaucon))
