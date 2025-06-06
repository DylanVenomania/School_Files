# Khai báo mức thuế là hằng số
TAX_RATE = 0.1

# Nhập số lượng và đơn giá của sản phẩm
quantity = int(input("Nhập số lượng sản phẩm: "))
price_per_unit = float(input("Nhập đơn giá của sản phẩm: "))

# Tính tổng tiền trước thuế
total_before_tax = quantity * price_per_unit

# Tính tiền thuế
tax_amount = total_before_tax * TAX_RATE

# Tính tổng tiền sau thuế
total_after_tax = total_before_tax + tax_amount

# Xuất kết quả
print(f"Tổng tiền trước thuế: {total_before_tax:.2f} VND")
print(f"Tiền thuế 10%: {tax_amount:.2f} VND")
print(f"Tổng tiền sau thuế: {total_after_tax:.2f} VND")