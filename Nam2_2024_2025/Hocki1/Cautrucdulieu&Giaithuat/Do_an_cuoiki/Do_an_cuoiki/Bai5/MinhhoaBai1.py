import tkinter as tk
from tkinter import messagebox
import time
import math

def dfs_minhhoa():
    try:
        sodinh = int(nhap_sodinh.get())
        input_canh = nhap_danhsachcanh.get("1.0", tk.END).strip()
        start = int(dinh_batdau.get())

        if start < 0 or start >= sodinh :
            raise ValueError(f"Đỉnh bắt đầu không hợp lệ (Phải trong khoảng từ 0 đến {sodinh - 1})")

        canh_lst = input_canh.split("\n")
        canhke_lst = [ [] for _ in range(sodinh) ]
        for canh in canh_lst:
            u, v = map(int, canh.split() )
            if u < 0 or u >= sodinh or v < 0 or v >= sodinh :
                raise ValueError( f"Cạnh ({u} {v}) không hợp lệ (Phải trong khoảng từ 0 đến {sodinh - 1})")
            canhke_lst[u].append( v )
            canhke_lst[v].append( u )

        draw_graph(sodinh, canh_lst)

        visited = [False] * sodinh
        stack = [start]
        result = []

        while stack:
            current = stack.pop()
            if not visited[ current ]:
                visited[ current ] = True
                result.append( current )
                highlight( current, "red")
                canvas.update()
                time.sleep( 1.5 )
                highlight(current, "blue")
                canvas.update()

                for neighbor in sorted(canhke_lst[current], reverse = True):
                    if not visited[neighbor]:
                        stack.append( neighbor )
        
        result_label.config( text = f"Kết quả DFS: {' '.join( map( str, result ))}")
       
        for node in result :
            highlight( node, "blue")
    except Exception :
        messagebox.showerror("Lỗi", f"Dữ liệu không hợp lệ : {Exception}")

def draw_graph( sodinh, danhsach_canh ):
    canvas.delete("all")
    node_positions.clear()
    width = 500
    height = 500
    radius = 160
    center_x, center_y = width // 2, height // 2

    for i in range(sodinh):
        angle = (2 * math.pi * i)/ sodinh
        x = center_x + radius * math.cos( angle )
        y = center_y + radius * math.sin( angle )
        node_positions[i] = (x, y)
        draw_node(i, x, y)
    
    for canh in danhsach_canh:
        u, v = map( int, canh.split())
        x1, y1 = node_positions[u]
        x2, y2 = node_positions[v]
        canvas.create_line(x1, y1, x2, y2, fill ="black", width = 2)

def draw_node(node, x, y):
    canvas.create_oval(x - 20, y - 20, x + 20, y + 20, fill = "white", outline = "black")
    canvas.create_text(x, y, text = str(node), font = ("Arial", 12, "bold"))

def highlight(node, color):
    x, y = node_positions[node]
    canvas.create_oval(x - 20, y - 20, x + 20, y + 20, fill = color, outline = "black")
    canvas.create_text(x, y, text = str(node), font = ("Arial", 12, "bold"))



root = tk.Tk()
root.title("Duyệt đồ thị DFS - Minh hoạ")

frame1 = tk.Frame(root)
frame1.pack(pady = 10)
tk.Label(frame1, text = "Số đỉnh:").grid(row =0, column = 0)
nhap_sodinh = tk.Entry(frame1, width = 10)
nhap_sodinh.grid(row = 0, column = 1)

tk.Label(frame1, text = "Danh sách các cạnh (nhập mỗi dòng với định dạng u v):").grid(row = 1, column = 0, columnspan = 2)
nhap_danhsachcanh = tk.Text(frame1, width = 40, height = 10)
nhap_danhsachcanh.grid(row = 2, column = 0, columnspan = 2)

tk.Label(frame1, text = "Đỉnh bắt đầu:").grid(row = 3, column = 0)
dinh_batdau = tk.Entry(frame1, width = 10)
dinh_batdau.grid(row = 3, column = 1)

start_button = tk.Button(frame1, text = "Bắt đầu duyệt", command = dfs_minhhoa)
start_button.grid(row = 4, column = 0, columnspan = 2, pady = 10)

frame2 = tk.Frame(root)
frame2.pack()
canvas = tk.Canvas(frame2, width = 500, height = 500, bg = "white")
canvas.pack()

result_label = tk.Label(root, text = "Kết quả : ", font = ("Arial", 12))
result_label.pack()

node_positions = {}

root.mainloop()