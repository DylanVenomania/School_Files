import numpy as np
import pandas as pd

#Tạo 1 Series từ 1 từ điển
dictionary = { 'a' : 1, 'b' : 3 , 'c' : 10 , 'd' : 2}
series1 = pd.Series( dictionary )
print( "Series tạo từ 1 từ điển :\n", series1, "\n" )

#Tạo 1 Series từ 1 mảng numpy
numpy_arr = np.arange( 1, 100, 4)
series2 = pd.Series( numpy_arr )
print( "Series tạo từ 1 mảng numpy :\n", series2, "\n" )

#Tạo 1 Series tự điều chỉnh index
arr = np.random.randint( 1, 10, size = 9 )
series3 = pd.Series( arr, index = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'] )
print( "Series tạo tự điều chỉnh index:\n" , series3)

#Tạo từ 1 số ( một Scalar ) 
series4 = pd.Series ( data = 3.14, index = [1, 2, 3, 4, 5, 6])
print( series4 )
