from datetime import datetime


class GiaoDich:
    def __init__(self, sender, receiver, amount, transaction_type, note="", date=None):
        self.sender = sender
        self.receiver = receiver
        self.amount = amount
        self.type_ = transaction_type  # "Chuyển tiền", "Vay tiền", "Cho vay"
        self.note = note
        self.date = date if date else datetime.now()

    def __str__(self):
        return f"{self.date} - {self.type_}: {self.sender} -> {self.receiver}, {self.amount} ({self.note})"