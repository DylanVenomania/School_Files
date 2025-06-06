
        
def tim_xau_max(xaukitu):
    xau_max = []
    xaucon = []
    for chac in xaukitu:
        if chac not in xaucon:
            xaucon.append(chac)
        else:
            if len(xaucon) == len(set(xaukitu)):
                xau_max.append(xaucon)

            xaucon = []
            xaucon.append( chac )

    if len(xaucon) == len(set(xaukitu)):
            xau_max.append(xaucon)
    if len(xau_max) != 0 :
         return xau_max
    else:
         return -1
xaukitu =  input("Nhập vào một xâu kí tự : ") 
if( tim_xau_max(xaukitu) != -1):
    print(f"Xâu con dài nhất có chứa tất cả các kí tự của xâu : '{xaukitu}' là : { tim_xau_max(xaukitu) } " )   
else:
     print("Không có xâu con dài nhất chứa tất cả các kí tự của xâu !")
