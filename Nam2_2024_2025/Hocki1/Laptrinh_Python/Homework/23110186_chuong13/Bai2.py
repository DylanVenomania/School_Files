from tkinter import *
import math as m
root = Tk()

a = StringVar()
b = StringVar()
c= StringVar()
x = StringVar()

def Giai():
    a1 = float(a.get())
    b1 = float(b.get())
    c1 = float(c.get())

    if a1 > 0 :
        delta = b1**2 - 4*a1*c1
        if delta == 0:
            x.set(f"x = {-b1/(2*a)}")
        if delta > 0 :
            x.set(f"x1 = { (-b1 - m.sqrt(delta))/ (2*a1)};x2 ={ (-b1 + m.sqrt(delta))/ (2*a1)} ")
        if delta < 0:
            x.set(f"Vô nghiệm")
    else :
        if a1 < 0:
            x.set(f"Vô nghiệm")
        if a1 == 0 :
            x.set(f"Phương trình bậc 1")

def Tiep():
    a.set("")
    b.set("")
    x.set("")

root.title("23110186 - Tôn Hoàng Cầm ")

Label(root, text = "Tôn Hoàng Cầm", fg = "blue", font = "15", justify = CENTER).grid(row = 0, columnspan = 2)

Label(root, text = "Hệ số a : " ).grid(row = 1, column = 0)
Entry(root, textvariable = a, width = 30).grid(row = 1, column = 1)

Label(root, text = "Hệ số b : " ).grid(row = 2, column = 0)
Entry(root, textvariable = b, width = 30).grid(row = 2, column = 1)

Label(root, text = "Hệ số c : " ).grid(row = 3, column = 0)
Entry(root, textvariable = c, width = 30).grid(row = 3, column = 1)

frame = Frame(root)

Button(frame, text = "Giải", command = Giai).pack(side = LEFT)
Button(frame, text = "Tiếp", command = Tiep).pack(side = LEFT)
Button(frame, text = "Thoát", command = root.quit).pack(side = LEFT)


frame.grid(row = 4, columnspan = 2)

Label(root, text = "Kết quả: " ).grid(row = 6, column = 0)
Entry(root, textvariable = x, width = 30).grid(row = 6, column = 1)

root.mainloop()
