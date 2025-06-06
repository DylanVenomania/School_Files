import pandas as pd
import numpy as np

series1 = pd.Series(np.random.randint(1, 5, size=100)) 
series2 = pd.Series(np.random.randint(1, 4, size=100)) 
series3 = pd.Series(np.random.randint(10000, 30001, size=100))  

df = pd.concat([ series1, series2, series3 ], axis=1 )

df.columns = ['bedrs', 'bathrs', 'price_sqr_meter']

df['bigcolumn'] = pd.concat([ series1, series2, series3 ], axis=0 ).reset_index(drop=True)

df = df.reindex(range(300)).reset_index(drop=True)
print("Randomly Generated DataFrame:")
print(df)

df.to_csv("random_dataframe.csv", index=False)
