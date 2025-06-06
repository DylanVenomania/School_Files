import numpy as np
import pandas as pd

dictionary = { 'Tuổi' : [21, 22, 33, 24, 45] , 
              'Tên' : ['a', 'b', 'c', 'd', 'e']}

df1 = pd.DataFrame( dictionary )
print( df1 )

row_data = [ 'row1', 'row2', 'row3', 'row4', 'row5']
df2 = pd.DataFrame( dictionary, index = row_data)
print( df2)

numpy_arr = np.array( [  [1,3,4], [4,52,45], [23,4,1]  ])
df3 = pd.DataFrame( numpy_arr, columns = [ 'Cot1', 'Cot2', 'Cot3'])
print( df3 )


#Tạo dataframe từ Tuple
tuple = ( ('An', 5, 7) , ('Thiên', 6, 8), ('Mỹ', 8, 9) )

df4 = pd.DataFrame( tuple, columns = ['Tên', 'Toán', 'Văn'] )
print( df4 )
print()

#Indexing với [ ]
arr1 = np.array( [ [ 1, 2, 3], [4, 5, 6], [7, 8, 9] ] )
df5 = pd.DataFrame( arr1)
print( df5)
print()

df5_indexing = df5[ 1 : ]
print(df5_indexing)

#Indexing với .loc và .iloc
# df.iloc[] để lập chỉ mục bằng số nguyên
# df.loc[] để lập chỉ mục bằng nhãn

    #dùng .iloc[]
data1 = { 'Tên' : ['An', 'Hạnh', 'Nhung'], 'Tuổi' : [23, 21, 30], 'Trạng thái' : ['vui', 'buồn', 'vui']}
df6 = pd.DataFrame( data1 )
df6_con1 = df6.iloc[ 0:2, 0:2]
print( df6 )
print('\n', df6_con1)

    #dùng .loc[]
df6_con2 = df6.loc[ 0:2, ["Tên", "Trạng thái"] ]
print( '\n', df6_con2)