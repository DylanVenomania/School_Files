class BaoCao:
    def __init__(self, transactions):
        self.transactions = transactions

    def generate_loan_report(self):
        loans = [t for t in self.transactions if t.type_ == "Vay tiền"]
        lent = [t for t in self.transactions if t.type_ == "Cho vay"]

        print("Danh sách Vay tiền:")
        for loan in loans:
            print(loan)

        print("\nDanh sách Cho vay:")
        for l in lent:
            print(l)