# Tôn Hoàng Cầm 23110186 
import math
arr = []
for i in range(3):
    arr = arr + [ float(input()) ]

for i in range(3):
    if( abs(arr[i]) < 10 ):
        print(arr[i], " ")