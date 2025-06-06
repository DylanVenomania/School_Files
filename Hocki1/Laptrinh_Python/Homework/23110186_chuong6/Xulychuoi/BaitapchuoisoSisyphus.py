chuoiso = (input("Nhap vao chuoi so : "))

def chanle( num ):
    if(num % 2 == 0):
        return True
    else:
        return False
    
cntchan = 0
cntle = 0

for i in range(len(chuoiso)):
    if( chanle(int( chuoiso[i] ) ) ):
        cntchan +=1
    else:
        cntle +=1

somoi = [ str(cntchan), str(cntle), str(len(chuoiso))  ]
print(''.join(somoi))