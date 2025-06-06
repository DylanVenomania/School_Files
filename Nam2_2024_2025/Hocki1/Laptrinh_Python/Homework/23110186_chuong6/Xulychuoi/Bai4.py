def doixung(xaukitu):
        dem = 0
        mid = len(xaukitu)/2
        while(dem < mid):
            if xaukitu[dem] != xaukitu[len(xaukitu)-1-dem]:
                return False
            dem+=1
        return True

xaukitu = input("Nhập vào một xâu kí tự : ")
if doixung(xaukitu):
     print("'", xaukitu , "' là một xâu đối xứng !")
else:
     print("'", xaukitu, "' không là một xâu đối xứng!")
    


            