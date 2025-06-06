from TaiKhoan import TaiKhoan
from GiaoDich import GiaoDich
from Goal import Goal

class User:
    def __init__(self, user_id, name, email):
        self.user_id = user_id
        self.name = name
        self.email = email
        self.accounts = []
        self.transactions = []
        self.goals = []

    def add_account(self, account_name, initial_balance):
        new_account = TaiKhoan(account_name, initial_balance)
        self.accounts.append(new_account)

    def delete_account(self, account_name):
        account = next((acc for acc in self.accounts if acc.name == account_name), None)
        if not account:
            raise ValueError("Tài khoản không tồn tại.")
        self.accounts.remove(account)

    def view_balance(self):
        return [f"{acc.name}: {acc.balance}" for acc in self.accounts]

    def perform_transaction(self, sender_name, receiver_name, amount, transaction_type, note=""):
        sender = next((acc for acc in self.accounts if acc.name == sender_name), None)
        receiver = next((acc for acc in self.accounts if acc.name == receiver_name), None)
        if not sender or not receiver:
            raise ValueError("Tài khoản không hợp lệ.")
        if transaction_type in ["Chuyển tiền", "Cho vay"] and sender.balance < amount:
            raise ValueError("Số dư không đủ.")

        if transaction_type == "Chuyển tiền":
            sender.withdraw(amount)
            receiver.deposit(amount)
        elif transaction_type == "Vay tiền":
            receiver.withdraw(amount)
            sender.deposit(amount)
        elif transaction_type == "Cho vay":
            sender.withdraw(amount)
            receiver.deposit(amount)

        transaction = GiaoDich(sender.name, receiver.name, amount, transaction_type, note)
        self.transactions.append(transaction)

    def view_transactions(self):
        return [
            f"{t.date}: {t.type_} - {t.amount}"  # Không sử dụng category nếu không tồn tại
            for t in self.transactions
        ]

    def view_loans(self):
        loans = [t for t in self.transactions if t.type_ in ["Vay tiền", "Cho vay"]]
        return loans

    def generate_financial_report(self):
        report = {}
        for account in self.accounts:
            total_income = sum(
                t.amount for t in self.transactions 
                if t.receiver == account.name
            )
            total_expense = sum(
                t.amount for t in self.transactions 
                if t.sender == account.name
            )
            report[account.name] = {"Thu nhập": total_income, "Chi tiêu": total_expense}
        return report
    
    def create_goal(self, name, target_amount, target_date):
        goal_id = len(self.goals) + 1
        new_goal = Goal(goal_id, name, target_amount, target_date=target_date)
        self.goals.append(new_goal)

    def update_goal(self, goal_id, amount):
        goal = next((g for g in self.goals if g.goal_id == goal_id), None)
        if not goal:
            raise ValueError("Không tìm thấy mục tiêu.")
        goal.add_savings(amount)

    def view_goals(self):
        return [{
            "Tên mục tiêu": g.name,
            "Số tiền mục tiêu": g.target_amount,
            "Số tiền đã tiết kiệm": g.current_amount,
            "Tiến độ": f"{g.progress():.2f}%"
        } for g in self.goals]