so = int(input())
donvi = so % 10
so = so//10
hangchuc = so % 10
hangtram = so//10 
tb = ( donvi + hangchuc + hangtram )/3
print('%.2f' %tb)