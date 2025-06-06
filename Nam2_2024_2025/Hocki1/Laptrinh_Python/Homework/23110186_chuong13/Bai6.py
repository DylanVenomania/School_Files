import tkinter as tk
from tkinter import messagebox

def chuyen_nam_am_lich():
    try:
        nam_duong_lich = int(nhap_nam.get())
        nam_am_lich = nam_duong_lich - 3  
        messagebox.showinfo("Kết quả", f"Năm âm lịch tương ứng: {nam_am_lich}")
    except ValueError:
        messagebox.showerror("Lỗi", "Vui lòng nhập một năm hợp lệ.")

def chuyen_doi_do_C():
    try:
        do_F = float(nhap_do_F.get())
        do_C = (do_F - 32) * 5 / 9
        messagebox.showinfo("Kết quả", f"{do_F} độ F tương ứng {do_C:.2f} độ C" )
    except ValueError:
        messagebox.showerror("Lỗi", "Vui lòng nhập một giá trị nhiệt độ hợp lệ.")

def tinh_bmi():
    try:
        can_nang = float( nhap_can_nang.get() )
        chieu_cao = float( nhap_chieu_cao.get() )
        bmi = can_nang / ( chieu_cao ** 2 )

        if bmi < 18.5:
            trang_thai = "Gầy"
        elif 18.5 <= bmi <= 24.9:
            trang_thai = "Bình thường"
        elif 25 <= bmi <= 29.9:
            trang_thai = "Mập"
        else:
            trang_thai = "Béo phì"

        messagebox.showinfo("Kết quả BMI", f"BMI : {bmi:.2f}\nTình trạng: {trang_thai}")
    except ValueError:
        messagebox.showerror("Lỗi", "Vui lòng nhập cân nặng và chiều cao hợp lệ.")

root = tk.Tk()
root.title("Chương trình tiện ích")
root.geometry("350x400")

tk.Label(root, text="1. Chuyển năm dương lịch sang năm âm lịch").pack(pady=5)
tk.Label(root, text="Nhập năm dương lịch:").pack()
nhap_nam = tk.Entry(root)
nhap_nam.pack()
tk.Button(root, text="Chuyển đổi", command=chuyen_nam_am_lich).pack(pady=5)

tk.Label(root, text="2. Chuyển đổi độ F sang độ C").pack(pady=10)
tk.Label(root, text="Nhập nhiệt độ (°F):").pack()
nhap_do_F = tk.Entry(root)
nhap_do_F.pack()
tk.Button(root, text="Chuyển đổi", command=chuyen_doi_do_C).pack(pady=5)

tk.Label(root, text="3. Tính chỉ số BMI").pack(pady=10)
tk.Label(root, text="Nhập cân nặng (kg):").pack()
nhap_can_nang = tk.Entry(root)
nhap_can_nang.pack()
tk.Label(root, text="Nhập chiều cao (m):").pack()
nhap_chieu_cao = tk.Entry(root)
nhap_chieu_cao.pack()
tk.Button(root, text="Tính BMI", command=tinh_bmi).pack(pady=5)

root.mainloop()