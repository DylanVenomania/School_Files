from tkinter import *

root = Tk()

a = StringVar()
b = StringVar()
x = StringVar()

def Giai():
    a1 = float(a.get())
    b1 = float(b.get())

    if a1 == 0 and b1 == 0:
        x.set("Phương trình vô số nghiệm")
    if a1==0 and b1 !=0 :
        x.set("Phương trình vô nghiệm !")
    if a1 != 0:
        x.set(f"x = {-b1/a1}")

def Tiep():
    a.set("")
    b.set("")
    x.set("")

root.title("Phương trình bậc nhất ! ")

Label(root, text = "Phương trình bậc 1", fg = "red", font = "15", justify = CENTER).grid(row = 0, columnspan = 2)

Label(root, text = "Hệ số a : " ).grid(row = 1, column = 0)
Entry(root, textvariable = a, width = 30).grid(row = 1, column = 1)

Label(root, text = "Hệ số b : " ).grid(row = 2, column = 0)
Entry(root, textvariable = b, width = 30).grid(row = 2, column = 1)

frame = Frame(root)

Button(frame, text = "Giải", command = Giai).pack(side = LEFT)
Button(frame, text = "Tiếp", command = Tiep).pack(side = LEFT)
Button(frame, text = "Thoát", command = root.quit).pack(side = LEFT)


frame.grid(row = 3, columnspan = 2)

Label(root, text = "Kết quả: " ).grid(row = 4, column = 0)
Entry(root, textvariable = x, width = 30).grid(row = 4, column = 1)

root.mainloop()
