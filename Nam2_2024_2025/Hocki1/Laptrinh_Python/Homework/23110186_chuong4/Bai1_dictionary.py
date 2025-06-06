def merge_dicts(dict1, dict2):
    merged_dict = {**dict1, **dict2}
    return merged_dict

dict1_input = input("Nhập dictionary 1 : ")
dict2_input = input("Nhập dictionary 2 : ")
dict1 = eval(dict1_input)
dict2 = eval(dict2_input)
dict3 = merge_dicts(dict1, dict2)

print("Kết quả của việc merge hai dictionary:", dict3)