import pandas as pd

file_path = "D:/Nam2_2024_2025/Hocki1/Bài tập python/23110186_chuong12/chipotle.tsv"
data = pd.read_csv( file_path, sep = '\t')

data['item_value'] = data['item_price'].replace('[\$,]', '', regex = True).astype(float)
product_more10 = data[ data['item_value'] > 10]
print(product_more10)

sorted_items = data['item_name'].sort_values()
print(sorted_items)

max_price_item = data.loc[ data['item_price'].idxmax() ]

print(max_price_item)

data = data[ data['item_name']  == "Veggie Salad Bowl" ].groupy('item_name').agg( {'order_id' : 'count', 'quantity' : 'sum'})