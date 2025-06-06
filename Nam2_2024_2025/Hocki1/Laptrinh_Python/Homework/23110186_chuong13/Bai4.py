import tkinter as tk
from tkinter import messagebox

def btn_click(event):
    global expression
    button = event.widget
    text = button["text"]

    if text == "=":
        try:
            result = eval(expression)
            entry_var.set(result)
            expression = str(result)
        except Exception as e:
            messagebox.showerror("Lỗi", "Biểu thức không hợp lệ!")
            expression = ""
            entry_var.set("")
    elif text == "Clr":
        expression = ""
        entry_var.set("")
    else:
        expression += text
        entry_var.set(expression)

root = tk.Tk()
root.title("23110334")
root.geometry("300x400")
root.resizable(False, False)

expression = ""

entry_var = tk.StringVar()
entry = tk.Entry(root, textvariable=entry_var, font=("Arial", 25), justify="right", bd=5, relief="sunken")
entry.pack(fill=tk.BOTH)

buttons = [
    ["1", "2", "3"],
    ["4", "5", "6"],
    ["7", "8", "9"],
    ["-", "0", "."],
    ["+", "-", "*", "/","="],
    ["Clr",]
]

frame = tk.Frame(root)
frame.pack(expand=True, fill=tk.BOTH)

for row in buttons:
    row_frame = tk.Frame(frame)
    row_frame.pack(expand=True, fill=tk.BOTH)

    for button_text in row:
        btn = tk.Button(row_frame, text=button_text, font=("Arial", 15), relief="raised", bd=3)
        btn.pack(side=tk.LEFT, expand=True, fill=tk.BOTH)
        btn.bind("<Button-1>", btn_click)

root.mainloop()
