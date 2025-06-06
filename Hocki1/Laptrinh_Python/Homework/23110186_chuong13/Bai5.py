import tkinter as tk
from tkinter import messagebox

def change_password():
    old_password = old_password_entry.get()
    new_password = new_password_entry.get()
    confirm_password = confirm_password_entry.get()

    if new_password != confirm_password:
        messagebox.showerror("Lỗi", "Mật khẩu mới không khớp!")
    else:
        messagebox.showinfo("Thành công", "Đổi mật khẩu thành công!")

root = tk.Tk()
root.title("Enter New Password")
root.geometry("350x150")
root.resizable(False, False)


tk.Label(root, text="Old Password:").grid(row=0, column=0, padx=10, pady=5)
tk.Label(root, text="New Password:").grid(row=1, column=0, padx=10, pady=5)
tk.Label(root, text="Enter New Password Again:").grid(row=2, column=0, padx=10, pady=5)

old_password_entry = tk.Entry(root, show="*")
new_password_entry = tk.Entry(root, show="*")
confirm_password_entry = tk.Entry(root, show="*")

old_password_entry.grid(row=0, column=1, padx=10, pady=5)
new_password_entry.grid(row=1, column=1, padx=10, pady=5)
confirm_password_entry.grid(row=2, column=1, padx=10, pady=5)

ok_button = tk.Button(root, text="OK", command=change_password)
cancel_button = tk.Button(root, text="Cancel", command=root.quit)

ok_button.grid(row=3, column=0, padx=10, pady=20)
cancel_button.grid(row=3, column=1, padx=10, pady=20)

root.mainloop()