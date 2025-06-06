it_companies = {'Facebook', 'Google', 'Microsoft', 'Apple', 'IBM', 'Oracle', 'Amazon'}
A = {19, 22, 24, 20, 25, 26}
B = {19, 22, 20, 25, 26, 24, 28, 27}
age = [22, 19, 24, 25, 26, 24, 25, 24]

length_it_companies = len(it_companies)
print("Chiều dài của tập hợp it_companies:", length_it_companies)

it_companies.add('Twitter')
print("Tập hợp it_companies sau khi thêm Twitter:", it_companies)

additional_companies_input = input("Nhập các công ty khác để thêm vào (phân tách bằng dấu phẩy): ")
it_companies.update(company.strip() for company in additional_companies_input.split(','))
print("Tập hợp it_companies sau khi thêm một số phần tử khác:", it_companies)

company_to_remove = input("Nhập tên công ty cần xóa khỏi tập hợp: ")
if company_to_remove in it_companies:
    it_companies.remove(company_to_remove)  
    print(f"Tập hợp it_companies sau khi xóa {company_to_remove}:", it_companies)
else:
    print(f"{company_to_remove} không có trong tập hợp it_companies.")

print("remove() sẽ gây lỗi nếu phần tử không tồn tại, trong khi discard() sẽ không gây lỗi.")

union_ab = A.union(B)  
print("Tập hợp A và B sau khi nối:", union_ab)

intersection_ab = A.intersection(B) 
print("Phần tử chung giữa A và B:", intersection_ab)