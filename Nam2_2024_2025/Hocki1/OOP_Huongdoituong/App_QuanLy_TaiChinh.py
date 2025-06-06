import collections
from dateutil.relativedelta import relativedelta
import tkinter as tk
from tkinter import messagebox, simpledialog, ttk, Toplevel
from datetime import datetime
import ttkbootstrap as ttkb



class User:
    def __init__(self, name, email):
        self.name = name
        self.email = email
        self.accounts = []

    def add_account(self, account):
        self.accounts.append(account)


class Account:
    def __init__(self, name, balance=0.0):
        self.name = name
        self.balance = balance

    def adjust_balance(self, amount):
        self.balance += amount


class Loan:
    def __init__(self, source, target, amount, loan_date, due_date,
                 remaining_amount, interest_rate = None,
                 compound= False, note = None):
        self.source = source  # Tài khoản nguồn
        self.target = target  # Tài khoản đích
        self.amount = amount  # Số tiền vay
        self.loan_date = loan_date
        self.due_date = due_date  # Ngày đến hạn (YYYY-MM-DD)
        self.remaining_amount = remaining_amount  # Số tiền còn nợ
        self.interest_rate = interest_rate  # Lãi suất (nếu có)
        self.compound = compound  # Lãi suất kép hay đơn
        self.note = note  

    def repay(self, payment: float):
        """Trả nợ một phần hoặc toàn bộ."""
        if payment > self.remaining_amount:
            raise ValueError("Số tiền trả vượt quá số nợ.")
        self.remaining_amount -= payment
        self.target.adjust_balance(payment)
        self.source.adjust_balance(-payment) 


class Transaction:
    def __init__(self, account, type_, amount, date, category, note=""):
        self.account = account
        self.type_ = type_ 
        self.amount = amount
        self.date = date
        self.category = category
        self.note = note


class Goal:
    def __init__(self, name, target_amount, target_date, progress=0):
        self.name = name
        self.target_amount = target_amount
        self.target_date = target_date
        self.progress = progress


class FinancialApp:
    def __init__(self):
        self.window = ttkb.Window(themename="superhero")
        self.window.title("Quản lý Tài chính Cá nhân")
        self.window.geometry("900x650")
        self.accounts = []
        self.transactions = []
        self.loans = []
        self.goals = []
        self.current_user = None
        self.users = []

        self.build_login_interface()


    def build_login_interface(self):
        self.clear_window()
        self.window.configure() 

   
        ttk.Label(self.window,text="Quản lý Tài chính Cá nhân",font=("Arial", 20, "bold") ).pack(pady=20)


        ttk.Label(self.window, text="Tên người dùng:", font=("Arial", 10)).pack(pady=5)
        name_entry = ttk.Entry(self.window)
        name_entry.pack(pady=5)

        ttk.Label(self.window, text="Email:", font=("Arial", 10)).pack(pady=5)
        email_entry = ttk.Entry(self.window)
        email_entry.pack(pady=5)

        def login_user():
            name = name_entry.get()
            email = email_entry.get()
            if name and email:
                if not email.endswith("@gmail.com"):
                    messagebox.showwarning("Lỗi", "Email không hợp lệ. Vui lòng nhập lại.")
                else:
                    user = next((u for u in self.users if u.email == email), None)
                    if not user:
                        user = User(name=name, email=email)
                        self.users.append(user)
                    self.current_user = user
                    self.build_main_interface()
            else:
                messagebox.showerror("Lỗi", "Vui lòng nhập đủ thông tin!")

        ttk.Button(self.window, text="Đăng nhập", command=login_user).pack(pady=20)


    def build_main_interface(self):
        self.clear_window()
        self.window.configure()

        ttk.Label(self.window, text=f"Chào mừng {self.current_user.name} đến với Quản Lý Tài Chính !",font=("Arial", 20, "bold")).pack(pady=20)


        button_frame = ttk.Frame(self.window, padding=10)
        button_frame.pack(pady=10)


        ttk.Button(button_frame, text="Quản lý tài khoản", command=self.manage_accounts, width=25).grid( row=0, column=0, pady=5 )
        ttk.Button(button_frame, text="Quản lý giao dịch", command=self.manage_transactions, width=25).grid(row=1, column=0, pady=5 )
        ttk.Button(button_frame, text="Quản lý khoản vay", command=self.manage_loans, width=25).grid(row=2, column=0 , pady=5)
        ttk.Button(button_frame, text="Báo cáo tài chính", command=self.generate_report, width=25 ).grid(row= 3, column=0, pady=5 )
        ttk.Button(button_frame, text="Quản lý mục tiêu", command=self.manage_goals, width=25 ).grid(row=4, column=0, pady=5 )
        ttk.Button(button_frame, text="Đăng xuất", command=self.build_login_interface, width=25).grid( row= 5 , column=0, pady=5 )
        

    def transfer_between_users(self):
        if not self.current_user:
            messagebox.showerror("Lỗi", "Vui lòng đăng nhập trước.")
            return

        source_name = simpledialog.askstring("Chuyển khoản", "Nhập tên tài khoản nguồn:", parent=self.window)
        source_account = next((acc for acc in self.current_user.accounts if acc.name == source_name), None)
        if not source_account:
            messagebox.showerror("Lỗi", "Không tìm thấy tài khoản nguồn.")
            return

        target_user_email = simpledialog.askstring("Chuyển khoản", "Nhập email của người nhận:", parent=self.window)
        target_user = next((u for u in self.users if u.email == target_user_email), None)
        if not target_user:
            messagebox.showerror("Lỗi", "Không tìm thấy người dùng đích.")
            return

        target_account_name = simpledialog.askstring("Chuyển khoản", "Nhập tên tài khoản đích:", parent=self.window)
        target_account = next((acc for acc in target_user.accounts if acc.name == target_account_name), None)
        if not target_account:
            messagebox.showerror("Lỗi", "Không tìm thấy tài khoản đích.")
            return

        amount = simpledialog.askfloat("Chuyển khoản", "Nhập số tiền chuyển:", parent=self.window)
        if not amount or amount <= 0:
            messagebox.showerror("Lỗi", "Số tiền chuyển không hợp lệ.")
            return

        if source_account.balance < amount:
            messagebox.showerror("Lỗi", "Số dư tài khoản nguồn không đủ.")
            return

        source_account.adjust_balance(-amount)
        target_account.adjust_balance(amount)

        now = datetime.now()
        transaction = Transaction(
            account=f"{source_account.name} -> {target_account.name}",
            type_="Chuyển khoản liên người dùng",
            amount=amount,
            date=now.strftime("%Y-%m-%d %H:%M"),
            category=f"Từ {self.current_user.name} -> {target_user.name}",
            note=f"Chuyển từ tài khoản {source_account.name} tới tài khoản {target_account.name}.")
        self.transactions.append(transaction)

        messagebox.showinfo("Thành công", f"Đã chuyển {amount} VNĐ từ '{source_name}' tới '{target_account_name}'.")


    def manage_accounts(self):
        self.clear_window()
        ttk.Label(self.window, text="Quản lý tài khoản", font=("Arial", 18, "bold")).pack( pady=(90,5) )
        ttk.Button(self.window, text="Tạo tài khoản", command=self.add_account, width=25).pack(pady=5)
        ttk.Button(self.window, text="Xóa tài khoản", command=self.delete_account, width=25).pack(pady=5 )
        ttk.Button(self.window, text="Chỉnh sửa tài khoản", command=self.edit_account, width=25).pack( pady=5)
        ttk.Button(self.window, text="Xem danh sách tài khoản", command=self.view_accounts, width=25).pack( pady=5)
        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack( pady=5 )


    def add_account(self):
        if not self.current_user:
            messagebox.showerror("Lỗi", "Vui lòng đăng nhập trước.")
            return

        name = simpledialog.askstring("Thêm tài khoản", "Nhập tên tài khoản :",parent=self.window)

        if any(account.name == name for account in self.current_user.accounts):
            messagebox.showinfo("Lỗi", "Tên tài khoản bị trùng. Vui lòng nhập tên khác.")
            return

        initial_balance = simpledialog.askfloat("Thêm tài khoản", "Nhập số dư ban đầu:", initialvalue=0.0,parent=self.window)
        if name and initial_balance is not None:
            new_account = Account(name=name, balance=initial_balance)
            self.current_user.add_account(new_account)
            messagebox.showinfo("Thành công", f"Đã thêm tài khoản '{name}' với số dư {initial_balance} VNĐ.")


    def delete_account(self):
        if not self.current_user or not self.current_user.accounts:
            messagebox.showinfo("Thông báo", "Không có tài khoản nào để xóa.")
            return

        # Lấy danh sách tên tài khoản của user hiện tại
        account_names = [account.name for account in self.current_user.accounts]
        account_to_delete = simpledialog.askstring(
            "Xóa tài khoản",
            "Nhập tên tài khoản cần xóa:",
            initialvalue=account_names[0],  
            parent=self.window
        )

        account = next((acc for acc in self.current_user.accounts if acc.name == account_to_delete), None)

        if account:
            self.current_user.accounts.remove(account)  
            messagebox.showinfo("Thành công", f"Đã xóa tài khoản '{account_to_delete}'.")
        else:
            messagebox.showwarning("Lỗi", "Không tìm thấy tài khoản.")


    def edit_account(self):
        if not self.current_user.accounts:
            messagebox.showinfo("Thông báo", "Không có tài khoản nào để chỉnh sửa.")
            return

        account_names = [account.name for account in self.current_user.accounts]
        account_to_edit = simpledialog.askstring("Chỉnh sửa tài khoản", "Nhập tên tài khoản cần chỉnh sửa:", initialvalue=account_names[0],parent=self.window)
        account = next((acc for acc in self.current_user.accounts if acc.name == account_to_edit), None)
        
        if account:
            new_name = simpledialog.askstring("Chỉnh sửa tài khoản", f"Nhập tên mới cho tài khoản '{account.name}':",parent=self.window)
            if new_name:
                account.name = new_name
                messagebox.showinfo("Thành công", f"Đã đổi tên tài khoản thành '{new_name}'.")
            else:
                messagebox.showwarning("Lỗi", "Không tìm thấy tài khoản.")
    
    
    def view_accounts(self):
        if not self.current_user.accounts:
            messagebox.showinfo("Danh sách tài khoản", "Không có tài khoản nào.")
            return
        account_list = "\n".join( [f"Tài khoản: {account.name}, Số dư: {account.balance} VNĐ" for account in self.current_user.accounts] )
        messagebox.showinfo("Danh sách tài khoản", account_list)


    def manage_transactions(self):
        self.clear_window()
        ttk.Label(self.window, text="Quản lý giao dịch", font=("Arial", 18, "bold")).pack(pady=(90,5))
        ttk.Button(self.window, text="Thêm giao dịch nội bộ", command=self.add_transaction, width=25).pack(pady=5)
        ttk.Button(self.window, text="Giao dịch giữa người dùng", command=self.transfer_between_users, width=25).pack(pady=5)
        ttk.Button(self.window, text="Xem giao dịch", command=self.view_transactions, width=25).pack(pady=5)
        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack(pady=5)


    def add_transaction(self):
        if not self.current_user or not self.current_user.accounts:
            messagebox.showinfo("Thông báo", "Hãy thêm tài khoản trước.")
            return

        # Tạo hộp thoại chọn loại giao dịch
        def get_transaction_type():
            nonlocal transaction_type
            transaction_type = combobox.get()
            dialog.destroy()

        transaction_type = None
        dialog = Toplevel()
        dialog.title("Chọn loại giao dịch")
        dialog.geometry("300x150")

        tk.Label(dialog, text="Chọn loại giao dịch:", font=("Arial", 12)).pack(pady=10)
        combobox = ttk.Combobox(dialog, values=["Thu nhập", "Chi tiêu", "Chuyển khoản"], state="readonly")
        combobox.pack(pady=5)
        combobox.current(0)  # Chọn mục đầu tiên mặc định

        tk.Button(dialog, text="Xác nhận", command=get_transaction_type).pack(pady=10)
        dialog.transient(self.window)  # Đặt hộp thoại trên cửa sổ chính
        dialog.grab_set()  # Khóa các tương tác khác với cửa sổ chính
        self.window.wait_window(dialog)  

        if not transaction_type:
            return

        if transaction_type in ["Thu nhập", "Chi tiêu"]:
            account_name = simpledialog.askstring("Giao dịch", "Nhập tên tài khoản:", parent=self.window)
            account = next((acc for acc in self.current_user.accounts if acc.name == account_name), None)

            if not account:
                messagebox.showwarning("Lỗi", "Không tìm thấy tài khoản.")
                return

            amount = simpledialog.askfloat("Giao dịch", "Nhập số tiền:", parent=self.window)
            category = simpledialog.askstring("Giao dịch", "Nhập danh mục giao dịch:", parent=self.window)
            note = simpledialog.askstring("Giao dịch", "Ghi chú (nếu có):", parent=self.window)

            now = datetime.now()
            transaction = Transaction(account=account.name,type_=transaction_type, amount=amount,date=now.strftime("%Y-%m-%d %H:%M"), category=category, note=note)
            self.transactions.append(transaction)

            if transaction_type == "Thu nhập":
                account.adjust_balance(amount)
            elif transaction_type == "Chi tiêu":
                account.adjust_balance(-amount)

            messagebox.showinfo("Thành công", "Đã thêm giao dịch.")

        elif transaction_type == "Chuyển khoản":
            if len(self.current_user.accounts) < 2:
                messagebox.showinfo("Thông báo", "Cần ít nhất hai tài khoản để chuyển khoản.")
                return

            source_name = simpledialog.askstring("Chuyển khoản", "Nhập tên tài khoản nguồn:", parent=self.window)
            target_name = simpledialog.askstring("Chuyển khoản", "Nhập tên tài khoản đích:", parent=self.window)
            amount = simpledialog.askfloat("Chuyển khoản", "Nhập số tiền chuyển:", parent=self.window)

            source = next((acc for acc in self.current_user.accounts if acc.name == source_name), None)
            target = next((acc for acc in self.current_user.accounts if acc.name == target_name), None)

            if not source or not target:
                messagebox.showwarning("Lỗi", "Không tìm thấy tài khoản nguồn hoặc đích.")
                return

            if source.balance < amount:
                messagebox.showwarning("Lỗi", "Số dư tài khoản nguồn không đủ.")
                return

            source.adjust_balance(-amount)
            target.adjust_balance(amount)

            now = datetime.now()
            transaction = Transaction(account=f"{source.name} -> {target.name}",type_="Chuyển khoản",amount=amount,date=now.strftime("%Y-%m-%d %H:%M"),category="Chuyển khoản nội bộ", note="")
            self.transactions.append(transaction)
            messagebox.showinfo("Thành công", f"Đã chuyển {amount} VNĐ từ '{source_name}' sang '{target_name}'.")
        else:
            messagebox.showwarning("Lỗi", "Loại giao dịch không hợp lệ.")


    def view_transactions(self):
        if not self.transactions:
            messagebox.showinfo("Thông báo", "Chưa có giao dịch nào.")
            return

        # Lấy danh sách tên tài khoản thuộc về user hiện tại
        user_accounts = {account.name for account in self.current_user.accounts}

        # Lọc các giao dịch liên quan đến tài khoản của user hiện tại
        user_transactions = [
            t for t in self.transactions
            if t.account.split(" -> ")[0] in user_accounts or t.account.split(" -> ")[-1] in user_accounts
        ]

        if not user_transactions:
            messagebox.showinfo("Thông báo", "Bạn chưa có giao dịch nào.")
            return

        transaction_list = "\n".join([
            f"Ngày: {t.date}, Loại: {t.type_}, Số tiền: {t.amount} VNĐ, Danh mục: {t.category}, Ghi chú: {t.note}"
            for t in user_transactions
        ])
        messagebox.showinfo("Lịch sử giao dịch", transaction_list)


    def manage_loans(self):
        self.clear_window()
        ttk.Button(self.window, text="Thêm khoản vay", command=self.add_loan, width=25).pack(pady=(90,5))
        ttk.Button(self.window, text="Danh sách khoản vay", command=self.view_loans, width=25).pack(pady=5)
        ttk.Button(self.window, text="Tính lãi khoản vay", command=self.view_interest, width=25).pack(pady=5)
        ttk.Button(self.window, text="Nhắc nhở trả nợ", command=self.remind_due_loans, width=25).pack(pady=5)
        ttk.Button(self.window, text="Trả nợ", command=self.repay_loan, width=25).pack(pady=5)

        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack(pady=5)


    def add_loan(self):
        source_user_email = simpledialog.askstring("Thêm khoản vay", "Email người vay:", parent=self.window)
        source_user = next((u for u in self.users if u.email == source_user_email), None)
        if not source_user:
            messagebox.showerror("Lỗi", "Không tìm thấy người vay.")
            return

        source_account_name = simpledialog.askstring("Thêm khoản vay", "Tên tài khoản người vay:", parent=self.window)
        source_account = next((acc for acc in source_user.accounts if acc.name == source_account_name), None)
        if not source_account:
            messagebox.showerror("Lỗi", "Không tìm thấy tài khoản người vay.")
            return

        target_user_email = simpledialog.askstring("Thêm khoản vay", "Email người cho vay:", parent=self.window)
        target_user = next((u for u in self.users if u.email == target_user_email), None)
        if not target_user:
            messagebox.showerror("Lỗi", "Không tìm thấy người cho vay.")
            return

        target_account_name = simpledialog.askstring("Thêm khoản vay", "Tên tài khoản người cho vay:", parent=self.window)
        target_account = next((acc for acc in target_user.accounts if acc.name == target_account_name), None)
        if not target_account:
            messagebox.showerror("Lỗi", "Không tìm thấy tài khoản người cho vay.")
            return

        amount = simpledialog.askfloat("Thêm khoản vay", "Số tiền vay:", parent=self.window)
        if not amount or amount <= 0:
            messagebox.showerror("Lỗi", "Số tiền vay không hợp lệ.")
            return

        due_date = simpledialog.askstring("Thêm khoản vay", "Ngày đáo hạn (YYYY-MM-DD):", parent=self.window)
        interest_rate = simpledialog.askfloat("Thêm khoản vay", "Lãi suất (%):", parent=self.window)
        note = simpledialog.askstring("Thêm khoản vay", "Ghi chú (nếu có):", parent=self.window)

        if target_account.balance < amount:
            messagebox.showerror("Lỗi", "Số dư tài khoản người cho vay không đủ.")
            return

        source_account.adjust_balance(amount)
        target_account.adjust_balance(-amount)
        loan = Loan(
            source=source_account,
            target=target_account,
            amount=amount,
            loan_date=datetime.now().strftime("%Y-%m-%d"),
            due_date=due_date,
            remaining_amount=amount,
            interest_rate=interest_rate / 100 if interest_rate else None,
            note=note,
        )
        self.loans.append(loan)

        messagebox.showinfo("Thành công", f"Đã thêm khoản vay từ '{source_account_name}' tới '{target_account_name}'.")


    def calculate_interest(self, loan):
        loan_date = datetime.strptime(loan.loan_date, "%Y-%m-%d").date()
        today = datetime.now().date()
        delta = relativedelta(today, loan_date)
        months = delta.years * 12 + delta.months  # Tính số tháng từ ngày vay

        if loan.interest_rate is None:
            return loan.remaining_amount  # Nếu không có lãi suất, chỉ trả số tiền còn nợ

        if loan.compound:  # Nếu tính lãi kép
            total_with_interest = loan.remaining_amount * ((1 + loan.interest_rate) ** months)
        else:  # Nếu tính lãi đơn
            total_with_interest = loan.remaining_amount * (1 + loan.interest_rate * months / 12)

        return round(total_with_interest, 2)


    def view_interest(self):
        if not self.loans:
            messagebox.showinfo("Thông báo", "Không có khoản vay nào.")
            return

        user_accounts = {account.name for account in self.current_user.accounts}
        user_loans = [
            loan for loan in self.loans 
            if loan.source.name in user_accounts or loan.target.name in user_accounts
        ]

        if not user_loans:
            messagebox.showinfo("Thông báo", "Bạn không có khoản vay nào.")
            return

        # Hiển thị thông tin khoản vay và số tiền cần trả
        interest_details = []
        for loan in user_loans:
            total_to_pay = self.calculate_interest(loan)  # Tổng tiền cần trả
            interest_details.append(
                f"Người vay: {next(user.name for user in self.users if loan.source in user.accounts)} "
                f"(Tài khoản: {loan.source.name})\n"
                f"Người cho vay: {next(user.name for user in self.users if loan.target in user.accounts)} "
                f"(Tài khoản: {loan.target.name})\n"
                f"Số tiền vay: {loan.amount} VNĐ, Còn nợ: {loan.remaining_amount} VNĐ\n"
                f"Lãi suất: {loan.interest_rate * 100 if loan.interest_rate else 0:.2f}%\n"
                f"Tổng tiền phải trả: {total_to_pay} VNĐ\n"
                f"Đáo hạn: {loan.due_date}, Ghi chú: {loan.note or 'Không có'}\n"
            )

        messagebox.showinfo("Tổng tiền phải trả cho các khoản vay", "\n\n".join(interest_details))


    def view_loans(self):
        user_accounts = {account.name for account in self.current_user.accounts}
        user_loans = [loan for loan in self.loans if loan.source.name in user_accounts or loan.target.name in user_accounts]

        if not user_loans:
            messagebox.showinfo("Danh sách khoản vay", "Bạn không có khoản vay nào.")
            return

        loan_list = "\n\n".join([
            f"Người vay: {next(user.name for user in self.users if loan.source in user.accounts)} "
            f"(Tài khoản vay: {loan.source.name}), "
            f"Người cho vay: {next(user.name for user in self.users if loan.target in user.accounts)} "
            f"(Tài khoản cho vay: {loan.target.name})\n"
            f"Số tiền vay: {loan.amount} VNĐ, Còn nợ: {loan.remaining_amount} VNĐ\n"
            f"Lãi suất: {loan.interest_rate * 100 if loan.interest_rate else 0:.2f}%, "
            f"Số tiền lãi hiện tại: {self.calculate_interest(loan) - loan.amount} VNĐ\n"
            f"Đáo hạn: {loan.due_date}, Ghi chú: {loan.note or 'Không có'}"
            for loan in user_loans
        ])

        messagebox.showinfo("Danh sách khoản vay", loan_list)


    def remind_due_loans(self):
        today = datetime.now().date()
        reminders = []

        # Lấy danh sách tài khoản của user hiện tại
        user_accounts = {account.name for account in self.current_user.accounts}

        # Lọc các khoản vay liên quan đến user hiện tại
        user_loans = [
            loan for loan in self.loans 
            if loan.source.name in user_accounts or loan.target.name in user_accounts
        ]

        for loan in user_loans:
            due_date = datetime.strptime(loan.due_date, "%Y-%m-%d").date()
            days_left = (due_date - today).days

            if loan.remaining_amount > 0:
                if days_left < 0:
                    reminders.append(
                        f"[Quá hạn] Người vay: {loan.source.name}, Người cho vay: {loan.target.name}\n"
                        f"Số tiền còn nợ: {loan.remaining_amount} VNĐ\n"
                        f"Đã quá hạn {abs(days_left)} ngày.\n"
                    )
                elif days_left == 0:
                    reminders.append(
                        f"[Đến hạn hôm nay] Người vay: {loan.source.name}, Người cho vay: {loan.target.name}\n"
                        f"Số tiền còn nợ: {loan.remaining_amount} VNĐ\n"
                    )
                elif days_left <= 3:
                    reminders.append(
                        f"[Cận hạn] Người vay: {loan.source.name}, Người cho vay: {loan.target.name}\n"
                        f"Số tiền còn nợ: {loan.remaining_amount} VNĐ\n"
                        f"Đến hạn trong {days_left} ngày.\n"
                    )
                elif days_left > 3:
                    reminders.append(
                        f"[Tương lai] Người vay: {loan.source.name}, Người cho vay: {loan.target.name}\n"
                        f"Số tiền còn nợ: {loan.remaining_amount} VNĐ\n"
                        f"Đến hạn trong {days_left} ngày.\n"
                    )

        if reminders:
            messagebox.showinfo("Nhắc nhở khoản vay", "\n".join(reminders))
        else:
            messagebox.showinfo("Nhắc nhở khoản vay", "Không có khoản vay nào cần nhắc nhở.")


    def repay_loan(self):
        if not self.loans:
            messagebox.showinfo("Trả nợ", "Không có khoản vay nào.")
            return

        # Lọc các khoản vay mà user hiện tại là người vay
        user_loans = [loan for loan in self.loans if any(acc == loan.source for acc in self.current_user.accounts)]

        if not user_loans:
            messagebox.showinfo("Trả nợ", "Bạn không có khoản vay nào để trả.")
            return

        # Hiển thị danh sách khoản vay liên quan
        loan_options = [
            f"Người vay: {next(user.name for user in self.users if loan.source in user.accounts)}, "
            f"Tài khoản vay: {loan.source.name}, Người cho vay: {next(user.name for user in self.users if loan.target in user.accounts)}, "
            f"Tài khoản cho vay: {loan.target.name}, Số tiền vay: {loan.amount} VNĐ, Còn nợ: {loan.remaining_amount} VNĐ"
            for loan in user_loans
        ]

        selected = simpledialog.askinteger(
            "Trả nợ",
            f"Chọn khoản vay để trả (1-{len(loan_options)}):\n" +
            "\n".join([f"{i + 1}. {option}" for i, option in enumerate(loan_options)]),
            parent=self.window
        )

        if selected and 1 <= selected <= len(user_loans):
            loan = user_loans[selected - 1]
            repay_amount = simpledialog.askfloat(
                "Trả nợ",
                f"Nhập số tiền muốn trả (tối đa {loan.remaining_amount} VNĐ):",
                parent=self.window
            )

            if repay_amount and 0 < repay_amount <= loan.remaining_amount:
                # Cập nhật số dư và trạng thái khoản vay
                loan.remaining_amount -= repay_amount
                loan.source.adjust_balance(-repay_amount)
                loan.target.adjust_balance(repay_amount)

                if loan.remaining_amount == 0:
                    messagebox.showinfo(
                        "Thành công",
                        f"Khoản vay giữa {next(user.name for user in self.users if loan.source in user.accounts)} "
                        f"và {next(user.name for user in self.users if loan.target in user.accounts)} đã được trả hết."
                    )
                else:
                    messagebox.showinfo(
                        "Thành công",
                        f"Bạn đã trả {repay_amount} VNĐ. Còn lại: {loan.remaining_amount} VNĐ."
                    )
            else:
                messagebox.showwarning("Lỗi", "Số tiền trả không hợp lệ.")
        else:
            messagebox.showwarning("Lỗi", "Không có khoản vay hợp lệ được chọn.")


    def manage_goals(self):
        self.clear_window()
        ttk.Button(self.window, text="Tạo mục tiêu mới", command=self.create_goal, width=25).pack(pady= (90,5) )
        ttk.Button(self.window, text="Xem danh sách mục tiêu", command=self.view_goals, width=25).pack( pady=5)
        ttk.Button(self.window, text="Quay lại", command=self.build_main_interface, width=25).pack( pady= (5) )


    def create_goal(self):
        name = simpledialog.askstring("Tạo mục tiêu mới", "Tên mục tiêu:",parent=self.window)
        target_amount = simpledialog.askfloat("Tạo mục tiêu mới", "Số tiền mục tiêu:",parent=self.window)
        target_date = simpledialog.askstring("Tạo mục tiêu mới", "Ngày hoàn thành (YYYY-MM-DD):",parent=self.window)
        if name and target_amount and target_date:
            self.goals.append(Goal(name=name, target_amount=target_amount, target_date=target_date))
            messagebox.showinfo("Thành công", f"Đã tạo mục tiêu '{name}'.")


    def view_goals(self):
        if not self.goals:
            messagebox.showinfo("Danh sách mục tiêu", "Không có mục tiêu nào.")
            return

        goal_details = []
        total_balance = sum(account.balance for account in self.current_user.accounts)

        for goal in self.goals:
            
            total_progress = min(goal.target_amount, total_balance + goal.progress)
            progress_percentage = (total_progress / goal.target_amount) * 100

            goal_details.append(
                f"Tên: {goal.name}\n"
                f"Mục tiêu: {goal.target_amount} VNĐ\n"
                f"Ngày hoàn thành: {goal.target_date}\n"
                f"Tiến độ: {total_progress}/{goal.target_amount} VNĐ ({progress_percentage:.2f}%)\n"
            )

        messagebox.showinfo("Danh sách mục tiêu", "\n\n".join(goal_details))


    def generate_report(self):
        report_window = ttk.LabelFrame(self.window, text="Chọn loại báo cáo", padding="10")
        report_window.pack(padx=10, pady=10, fill="both", expand=True)

        ttk.Label(report_window, text="Chọn loại báo cáo:", font=("Arial", 12)).pack(pady=10)

        report_type = tk.StringVar(value="Thu nhập/Chi tiêu")

        ttk.Radiobutton(report_window, text="Thu nhập/Chi tiêu", variable=report_type, value="Thu nhập/Chi tiêu").pack( pady=5)
        ttk.Radiobutton(report_window, text="Khoản vay/Cho vay", variable=report_type, value="Khoản vay/Cho vay").pack( pady=5)

        def show_report():
            selected_report = report_type.get()
            if selected_report == "Thu nhập/Chi tiêu":
                user_accounts = {account.name for account in self.current_user.accounts}
                user_transactions = [t for t in self.transactions if t.account in user_accounts]

                if not user_transactions:
                    messagebox.showinfo("Lỗi", "Chưa có giao dịch nào!")
                    return

                income = sum(t.amount for t in user_transactions if t.type_ == "Thu nhập")
                expense = sum(t.amount for t in user_transactions if t.type_ == "Chi tiêu")
                messagebox.showinfo("Báo cáo Thu nhập/Chi tiêu", f"Tổng thu nhập: {income} VNĐ\nTổng chi tiêu: {expense} VNĐ")

            elif selected_report == "Khoản vay/Cho vay":
                user_accounts = set(self.current_user.accounts)
                user_loans = [loan for loan in self.loans if loan.source in user_accounts or loan.target in user_accounts]

                if not user_loans:
                    messagebox.showinfo("Lỗi", "Chưa có khoản vay/cho vay nào!")
                    return

                loan_summary = collections.defaultdict(lambda: {'vay': 0, 'cho_vay': 0})

                for loan in user_loans:
                    if loan.source in user_accounts:
                        loan_summary[loan.source]['vay'] += loan.amount
                    if loan.target in user_accounts:
                        loan_summary[loan.target]['cho_vay'] += loan.amount

                report_message = ""
                for account, amounts in loan_summary.items():
                    report_message += (f"Tài khoản {account.name}: Vay {amounts['vay']} VNĐ, "
                                    f"Cho vay {amounts['cho_vay']} VNĐ\n")

                messagebox.showinfo("Báo cáo Khoản vay/Cho vay", report_message)

            report_window.destroy()

        ttk.Button(report_window, text="Xem báo cáo", command=show_report).pack(pady=10)

  
    def clear_window(self):
        for widget in self.window.winfo_children():
            widget.destroy()


    def run(self):
        self.window.mainloop()


app = FinancialApp()
app.run()

