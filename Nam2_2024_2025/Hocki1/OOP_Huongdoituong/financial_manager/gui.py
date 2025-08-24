from tkinter import messagebox, ttk
from User import User
from TaiKhoan import TaiKhoan
from GiaoDich import GiaoDich
from datetime import datetime
import tkinter as tk


class FinancialApp:
    def __init__(self):
        self.window = tk.Tk()
        self.window.title("Quản lý Tài chính Cá nhân")
        self.window.geometry("900x600")
        self.all_users = User.load_users_from_file()
        self.user = None
        
        self.build_login_interface()


    def build_login_interface(self):
        self.clear_window()
        ttk.Label(self.window, text="Quản lý Tài chính Cá nhân", font=("Arial", 24, "bold")).pack(pady=20)

        ttk.Label(self.window, text="Tên người dùng:").pack(pady=5)
        name_entry = ttk.Entry(self.window)
        name_entry.pack(pady=5)

        ttk.Label(self.window, text="Email:").pack(pady=5)
        email_entry = ttk.Entry(self.window)
        email_entry.pack(pady=5)

        def login_user():
            name = name_entry.get()
            email = email_entry.get()
            if name and email:
                for u in self.all_users:
                    if u.name == name and u.email == email:
                        self.user = u
                        break
                else:
                    self.user = User(user_id=len(self.all_users) + 1, name=name, email=email)
                    self.all_users.append(self.user)
                self.build_main_interface()
            else:
                messagebox.showerror("Lỗi", "Vui lòng nhập đủ thông tin!")

        ttk.Button(self.window, text="Đăng nhập", command=login_user).pack(pady=10)

    def logout_user(self):
        if self.user:
            self.user.save_to_file()
        self.user = None
        self.build_login_interface()

    def build_main_interface(self):
        self.clear_window()
        ttk.Label(self.window, text=f"Chào mừng, {self.user.name}!", font=("Arial", 20, "bold")).pack(pady=20)

        ttk.Button(self.window, text="Quản lý tài khoản", command=self.manage_accounts, width=25).pack(pady=5)
        ttk.Button(self.window, text="Thực hiện giao dịch", command=self.perform_transaction, width=25).pack(pady=5)
        ttk.Button(self.window, text="Báo cáo tài chính", command=self.view_reports, width=25).pack(pady=5)
        ttk.Button(self.window, text="Quản lý mục tiêu", command=self.manage_goals, width=25).pack(pady=5)
        ttk.Button(self.window, text="Đăng xuất", command=self.build_login_interface, width=25).pack(pady=5)

    def save_and_logout(self):
        self.user.save_to_file()
        User.save_users_to_file(self.all_users)
        self.build_login_interface()

    def manage_accounts(self):
        self.clear_window()
        ttk.Label(self.window, text="Quản lý tài khoản", font=("Arial", 18, "bold")).pack(pady=20)

        ttk.Button(self.window, text="Tạo tài khoản", command=self.create_account, width=25).pack(pady=5)
        ttk.Button(self.window, text="Xóa tài khoản", command=self.delete_account, width=25).pack(pady=5)
        ttk.Button(self.window, text="Xem danh sách tài khoản", command=self.view_accounts, width=25).pack(pady=5)
        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack(pady=5)

    def create_account(self):
        account_window = tk.Toplevel(self.window)
        account_window.title("Tạo tài khoản")
        account_window.geometry("400x300")

        ttk.Label(account_window, text="Tên tài khoản:").pack(pady=5)
        name_entry = ttk.Entry(account_window)
        name_entry.pack(pady=5)

        ttk.Label(account_window, text="Số dư ban đầu:").pack(pady=5)
        balance_entry = ttk.Entry(account_window)
        balance_entry.pack(pady=5)

        def save_account():
            name = name_entry.get()
            try:
                balance = float(balance_entry.get())
                self.user.add_account(name, balance)
                messagebox.showinfo("Thành công", f"Tài khoản '{name}' đã được tạo.")
                account_window.destroy()
            except ValueError:
                messagebox.showerror("Lỗi", "Số dư phải là số hợp lệ.")

        ttk.Button(account_window, text="Lưu", command=save_account).pack(pady=10)

    def delete_account(self):
        if not self.user.accounts:
            messagebox.showinfo("Thông báo", "Không có tài khoản nào để xóa.")
            return

        delete_window = tk.Toplevel(self.window)
        delete_window.title("Xóa tài khoản")
        delete_window.geometry("400x300")

        ttk.Label(delete_window, text="Chọn tài khoản để xóa:").pack(pady=5)

        accounts = [acc.name for acc in self.user.accounts]
        selected_account = tk.StringVar(value=accounts[0])

        account_menu = ttk.OptionMenu(delete_window, selected_account, *accounts)
        account_menu.pack(pady=10)

        def confirm_delete():
            acc_name = selected_account.get()
            try:
                self.user.delete_account(acc_name)
                messagebox.showinfo("Thành công", f"Tài khoản '{acc_name}' đã được xóa.")
                delete_window.destroy()
            except ValueError as e:
                messagebox.showerror("Lỗi", str(e))

        ttk.Button(delete_window, text="Xóa", command=confirm_delete).pack(pady=10)

    def view_accounts(self):
        accounts = self.user.view_balance()
        account_list = "\n".join(accounts)
        messagebox.showinfo("Danh sách tài khoản", account_list)

    def perform_transaction(self):
        transaction_window = tk.Toplevel(self.window)
        transaction_window.title("Thực hiện giao dịch")
        transaction_window.geometry("400x500")

        ttk.Label(transaction_window, text="Loại giao dịch:").pack(pady=5)
        transaction_type = tk.StringVar(value="Chuyển tiền")
        ttk.OptionMenu(transaction_window, transaction_type, "Chuyển tiền", "Vay tiền", "Cho vay").pack(pady=10)

        # Chọn user nhận tiền
        ttk.Label(transaction_window, text="User nhận tiền:").pack(pady=5)
        receiver_user_entry = ttk.Entry(transaction_window)
        receiver_user_entry.pack(pady=5)

        # Chọn tài khoản nhận tiền
        ttk.Label(transaction_window, text="Tài khoản nhận:").pack(pady=5)
        receiver_account_entry = ttk.Entry(transaction_window)
        receiver_account_entry.pack(pady=5)

        # Chọn tài khoản gửi
        ttk.Label(transaction_window, text="Tài khoản gửi:").pack(pady=5)
        sender_account_entry = ttk.Entry(transaction_window)
        sender_account_entry.pack(pady=5)

        # Nhập số tiền
        ttk.Label(transaction_window, text="Số tiền:").pack(pady=5)
        amount_entry = ttk.Entry(transaction_window)
        amount_entry.pack(pady=5)

        # Thêm phần lãi suất và ngày hạn trả cho giao dịch vay/cho vay
        ttk.Label(transaction_window, text="Lãi suất (%):").pack(pady=5)
        interest_rate_entry = ttk.Entry(transaction_window)
        interest_rate_entry.pack(pady=5)

        ttk.Label(transaction_window, text="Ngày hạn trả (YYYY-MM-DD):").pack(pady=5)
        due_date_entry = ttk.Entry(transaction_window)
        due_date_entry.pack(pady=5)

        def save_transaction():
            try:
                receiver_user_name = receiver_user_entry.get()
                receiver_account_name = receiver_account_entry.get()
                sender_account_name = sender_account_entry.get()
                amount = float(amount_entry.get())
                interest_rate = float(interest_rate_entry.get() or 0)
                due_date = due_date_entry.get() or None
                trans_type = transaction_type.get()

                receiver_user = next((u for u in self.all_users if u.name == receiver_user_name), None)
                if not receiver_user:
                    raise ValueError("Không tìm thấy user nhận tiền.")

                # Thực hiện giao dịch
                self.user.perform_transaction(
                    sender_name=sender_account_name,
                    receiver_user=receiver_user,
                    receiver_name=receiver_account_name,
                    amount=amount,
                    transaction_type=trans_type,
                    interest_rate=interest_rate,
                    due_date=due_date
                )
                messagebox.showinfo("Thành công", "Giao dịch đã được thực hiện.")
                transaction_window.destroy()
            except Exception as e:
                messagebox.showerror("Lỗi", str(e))

        ttk.Button(transaction_window, text="Thực hiện", command=save_transaction).pack(pady=10)


    def view_reports(self):
        report_data = self.user.view_transactions()
        report_text = "\n".join(report_data)
        messagebox.showinfo("Báo cáo tài chính", report_text)

    def manage_goals(self):
        self.clear_window()
        ttk.Label(self.window, text="Quản lý mục tiêu tài chính", font=("Arial", 18, "bold")).pack(pady=20)

        ttk.Button(self.window, text="Tạo mục tiêu mới", command=self.create_goal, width=25).pack(pady=5)
        ttk.Button(self.window, text="Cập nhật mục tiêu", command=self.update_goal, width=25).pack(pady=5)
        ttk.Button(self.window, text="Xem danh sách mục tiêu", command=self.view_goals, width=25).pack(pady=5)
        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack(pady=5)

    def create_goal(self):
        goal_window = tk.Toplevel(self.window)
        goal_window.title("Tạo mục tiêu mới")
        goal_window.geometry("400x300")

        ttk.Label(goal_window, text="Tên mục tiêu:").pack(pady=5)
        name_entry = ttk.Entry(goal_window)
        name_entry.pack(pady=5)

        ttk.Label(goal_window, text="Số tiền mục tiêu:").pack(pady=5)
        target_amount_entry = ttk.Entry(goal_window)
        target_amount_entry.pack(pady=5)

        ttk.Label(goal_window, text="Ngày hoàn thành (YYYY-MM-DD):").pack(pady=5)
        target_date_entry = ttk.Entry(goal_window)
        target_date_entry.pack(pady=5)

        def save_goal():
            try:
                name = name_entry.get()
                target_amount = float(target_amount_entry.get())
                target_date = target_date_entry.get()
                self.user.create_goal(name, target_amount, target_date)
                messagebox.showinfo("Thành công", f"Đã tạo mục tiêu '{name}'.")
                goal_window.destroy()
            except Exception as e:
                messagebox.showerror("Lỗi", str(e))

        ttk.Button(goal_window, text="Lưu", command=save_goal).pack(pady=10)

    def update_goal(self):
        update_window = tk.Toplevel(self.window)
        update_window.title("Cập nhật mục tiêu")
        update_window.geometry("400x300")

        ttk.Label(update_window, text="Chọn mục tiêu:").pack(pady=5)
        goals = [g.name for g in self.user.goals]
        selected_goal = tk.StringVar(value=goals[0] if goals else "")
        goal_menu = ttk.OptionMenu(update_window, selected_goal, *goals)
        goal_menu.pack(pady=10)

        ttk.Label(update_window, text="Số tiền thêm vào:").pack(pady=5)
        amount_entry = ttk.Entry(update_window)
        amount_entry.pack(pady=5)

        def save_update():
            try:
                goal_name = selected_goal.get()
                amount = float(amount_entry.get())
                goal = next(g for g in self.user.goals if g.name == goal_name)
                self.user.update_goal(goal.goal_id, amount)
                messagebox.showinfo("Thành công", f"Đã cập nhật mục tiêu '{goal_name}'.")
                update_window.destroy()
            except Exception as e:
                messagebox.showerror("Lỗi", str(e))

        ttk.Button(update_window, text="Lưu", command=save_update).pack(pady=10)

    def view_goals(self):
        goals_window = tk.Toplevel(self.window)
        goals_window.title("Danh sách mục tiêu")
        goals_window.geometry("400x400")

        goals = self.user.view_goals()
        for g in goals:
            ttk.Label(goals_window, text=f"Tên: {g['Tên mục tiêu']}, Tiến độ: {g['Tiến độ']}").pack(pady=5)

        ttk.Button(goals_window, text="Đóng", command=goals_window.destroy).pack(pady=10)

    def save_and_logout(self):
        self.user.save_to_file()
        self.build_login_interface()

    def clear_window(self):
        for widget in self.window.winfo_children():
            widget.destroy()

    def run(self):
        self.window.mainloop()


if __name__ == "__main__":
    app = FinancialApp()
    app.run()