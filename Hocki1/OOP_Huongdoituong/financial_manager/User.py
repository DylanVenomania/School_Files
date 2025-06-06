from TaiKhoan import TaiKhoan
from GiaoDich import GiaoDich
from Goal import Goal
import json
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

    def perform_transaction(self, sender_name, receiver_user, receiver_name, amount, transaction_type, note="", interest_rate=0, due_date=None):
        sender = next((acc for acc in self.accounts if acc.name == sender_name), None)
        if not sender:
            raise ValueError("Tài khoản gửi không hợp lệ.")

        # Xử lý cho user nhận tiền
        receiver_account = next((acc for acc in receiver_user.accounts if acc.name == receiver_name), None)
        if not receiver_account:
            raise ValueError("Tài khoản nhận không hợp lệ.")

        # Kiểm tra và thực hiện giao dịch
        if transaction_type in ["Chuyển tiền", "Cho vay"] and sender.balance < amount:
            raise ValueError("Số dư không đủ.")

        if transaction_type == "Chuyển tiền":
            sender.withdraw(amount)
            receiver_account.deposit(amount)
        elif transaction_type == "Vay tiền":
            receiver_account.withdraw(amount)
            sender.deposit(amount)
        elif transaction_type == "Cho vay":
            sender.withdraw(amount)
            receiver_account.deposit(amount)

        transaction = GiaoDich(
            sender=sender_name,
            receiver=receiver_name,
            amount=amount,
            type_=transaction_type,
            note=note,
            interest_rate=interest_rate,
            due_date=due_date
        )
        self.transactions.append(transaction)
        receiver_user.transactions.append(transaction)

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
    
    @staticmethod
    def load_users_from_file(file_path="data.json"):
        try:
            with open(file_path, "r") as file:
                data = json.load(file)
                users = []
                for user_data in data:
                    user = User(
                        user_id=user_data["user_id"],
                        name=user_data["name"],
                        email=user_data["email"]
                    )
                    for acc in user_data.get("accounts", []):
                        account = TaiKhoan(acc["name"], acc["balance"])
                        user.accounts.append(account)
                    for tran in user_data.get("transactions", []):
                        transaction = GiaoDich(
                            sender=tran["sender"],
                            receiver=tran["receiver"],
                            amount=tran["amount"],
                            type_=tran["type"],
                            note=tran.get("note", "")
                        )
                        user.transactions.append(transaction)
                    users.append(user)
                return users
        except FileNotFoundError:
            return []

    def save_to_file(self, file_path="data.json"):
        try:
            with open(file_path, "r") as file:
                data = json.load(file)
        except FileNotFoundError:
            data = []

        user_data = {
            "user_id": self.user_id,
            "name": self.name,
            "email": self.email,
            "accounts": [{"name": acc.name, "balance": acc.balance} for acc in self.accounts],
            "transactions": [{
                "sender": tran.sender,
                "receiver": tran.receiver,
                "amount": tran.amount,
                "type": tran.type_,
                "note": tran.note
            } for tran in self.transactions],
        }

        # Cập nhật hoặc thêm dữ liệu người dùng vào file
        data = [ud for ud in data if ud["user_id"] != self.user_id]
        data.append(user_data)

        with open(file_path, "w") as file:
            json.dump(data, file, indent=4)