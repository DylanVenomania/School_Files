it_companies = {'Facebook', 'Google', 'Microsoft', 'Apple', 'IBM', 'Oracle', 'Amazon'}
A = {19, 22, 24, 20, 25, 26}
B = {19, 22, 20, 25, 26, 24, 28, 27}
age = [22, 19, 24, 25, 26, 24, 25, 24]

tapcon = A.issubset(B)
print("A có phải là một tập hợp con của B không?", tapcon)

taproirac = A.isdisjoint(B)
print("A và B có phải là tập hợp rời rạc không?", taproirac)

union_ab = A.union(B)
print("Nối A với B:", union_ab)

symmetric_difference = A.symmetric_difference(B)
print("Các phần tử khác biệt đối xứng giữa A và B:", symmetric_difference)

A.clear()
B.clear()
print("Tập hợp A sau khi xóa:", A)
print("Tập hợp B sau khi xóa:", B)

age_set = set(age)
length_age_list = len(age)
length_age_set = len(age_set)

print("Độ dài của danh sách age:", length_age_list)
print("Độ dài của tập hợp age_set:", length_age_set)

if length_age_list > length_age_set:
    print("Danh sách age lớn hơn tập hợp age_set.")
elif length_age_list < length_age_set:
    print("Tập hợp age_set lớn hơn danh sách age.")
else:
    print("Danh sách age và tập hợp age_set có độ dài bằng nhau.")