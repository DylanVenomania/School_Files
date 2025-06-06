import string

def max_appear(xaukitu):
    xuat_hien_nhieu = []
    solan_max = 0

    for kitu in xaukitu:
        if xaukitu.count(kitu) > solan_max:
            solan_max = xaukitu.count(kitu)

    for kitu in xaukitu:
        if xaukitu.count(kitu) == solan_max and kitu not in xuat_hien_nhieu:
            xuat_hien_nhieu.append(kitu)

    return solan_max, xuat_hien_nhieu


xaukitu = input("Nhập vào một xâu kí tự : ")
count, mylst = max_appear(xaukitu)

if len(mylst) > 1:
    print(f"Các kí tự xuất hiện nhiều nhất trong xâu là : {mylst} với số lần là {count}")
else:
    print(f"Kí tự xuất hiện nhiều nhất trong xâu là : {mylst} với số lần là {count}")