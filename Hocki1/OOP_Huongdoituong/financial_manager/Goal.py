class Goal:
    def __init__(self, goal_id, name, target_amount, current_amount=0, target_date=None):
        self.goal_id = goal_id
        self.name = name
        self.target_amount = target_amount
        self.current_amount = current_amount
        self.target_date = target_date

    def add_savings(self, amount):
        if amount > 0:
            self.current_amount += amount
        else:
            raise ValueError("Số tiền phải lớn hơn 0.")

    def progress(self):
        return (self.current_amount / self.target_amount) * 100 if self.target_amount else 0