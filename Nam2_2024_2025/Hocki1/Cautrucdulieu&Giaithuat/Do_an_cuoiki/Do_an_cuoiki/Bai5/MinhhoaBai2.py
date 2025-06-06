import tkinter as tk
from tkinter import simpledialog
from tkinter import messagebox

class Sach:
    def __init__(self, maSach, tenSach, tacGia, giaBan):
        self.maSach =  maSach
        self.tenSach = tenSach
        self.tacGia = tacGia
        self.giaBan = giaBan

    def __lt__(self, other):
        return self.maSach < other.maSach

    def __gt__(self, other):
        return self.maSach > other.maSach

    def __eq__(self, other):
        return self.maSach == other.maSach

class Node:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None
    
class BST:
    def __init__(self):
        self.root = None
    
    def insert_dequy( self, root, key ):
        if root is None:
            return Node(key)

        if key.maSach < root.key.maSach:
            root.left = self.insert_dequy( root.left, key )
        elif key.maSach > root.key.maSach:
            root.right = self.insert_dequy( root.right, key )
        return root

    def insert_khong_dequy( self, root, key ):
        new_node = Node( key )
        if root is None:
            return new_node
        
        current = root
        parent = None
        while current is not None:
            parent  = current
            if key.maSach < current.key.maSach:
                current = current.left
            elif key.maSach > current.key.maSach:
                current = current.right
            else:
                return root 

        if key.maSach < parent.key.maSach:
            parent.left = new_node
        else:
            parent.right = new_node
        return root

    def delete_dequy(self, root, key):
        if root is None:
            return root

        if key.maSach < root.key.maSach:
            root.left = self.delete_dequy(root.left, key)
        elif key.maSach > root.key.maSach:
            root.right = self.delete_dequy(root.right, key)
        else:
            if root.left is None:
                return root.right
            elif root.right is None:
                return root.left

            min_larger_node = self.find_min(root.right)
            root.key = min_larger_node.key
            root.right = self.delete_dequy(root.right, min_larger_node.key)

        return root

    
    def delete_khongdequy( self, root, key ):
        if root is None:
            return root

        parent = None
        current = root
        while current is not None and current.key.maSach != key.maSach:
            parent = current
            if key.maSach < current.key.maSach:
                current = current.left
            else:
                current = current.right

        if current is None:
            return root  
            
        if current.left is None or current.right is None:
            new_child = current.left if current.left else current.right
    
            if parent is None:
                return new_child
            if parent.left == current:
                parent.left = new_child
            else:
                parent.right = new_child

        else:
            min_larger_node = self.find_min(current.right)
            current.key = min_larger_node.key
            current.right = self.delete_khongdequy(current.right, min_larger_node.key)
        return root
        
    def find_min(self, root):
        while root.left is not None:
            root = root.left
        return root

    def get_height(self, root):
        if root is None:
            return 0
        return max( self.get_height(root.left), self.get_height(root.right) ) + 1

    def search(self, root, key):
        if root is None:
            return False
        if key == root.key.maSach:
            return True
        elif key < root.key.maSach:
            return self.search(root.left, key)
        else:
            return self.search(root.right, key)

class giaodienBST:
    def __init__(self, master):
        self.master = master
        self.master.title( "Cây nhị phân tìm kiếm")

        self.bst = BST()
        self.canvas = tk.Canvas( self.master, width = 800, height = 600, bg = "white" )
        self.canvas.pack()
        
        self.add_button_recursive = tk.Button( self.master, text="Them sach ( De quy )", command=lambda: self.add_node(True) )
        self.add_button_recursive.pack()

        self.add_button_non_recursive = tk.Button( self.master, text="Them sach ( khong de quy )", command=lambda: self.add_node(False) )
        self.add_button_non_recursive.pack()

        self.delete_button_recursive = tk.Button( self.master, text="Xoa sach ( De quy )", command=lambda: self.delete_node(True) )
        self.delete_button_recursive.pack()

        self.delete_button_non_recursive = tk.Button( self.master, text="Xoa sach ( Khong de quy )", command=lambda: self.delete_node(False) )
        self.delete_button_non_recursive.pack()

        self.height_button = tk.Button( self.master, text="Chieu cao cua cay", command=self.show_height )
        self.height_button.pack()


    def draw_tree(self, root, x, y, dx):
        if root is None or root.key is None:
            return
        
        self.canvas.create_oval( x -20, y - 20, x + 20, y + 20, fill = "lightblue" )
        self.canvas.create_text( x, y, text = str(root.key.maSach), font = ("Arial", 10) )

        if root.left : 
            x_left = x - dx
            y_left = y + 70

            self.canvas.create_line( x, y, x_left, y_left )
            self.draw_tree( root.left, x_left, y_left, dx // 2)

        if root.right :
            x_right = x + dx 
            y_right = y + 70
            
            self.canvas.create_line( x, y, x_right, y_right)
            self.draw_tree( root.right, x_right, y_right, dx // 2)

    
    def refresh_canvas(self):
        self.canvas.delete("all")
        self.draw_tree(self.bst.root, 400, 50, 200)


    def add_node(self, dequy):
        maSach = simpledialog.askinteger("Input", "Nhập mã sách:" )
        tenSach = simpledialog.askstring("Input", "Nhập tên sách:" )
        tacGia = simpledialog.askstring("Input", "Nhập tác giả:" )
        giaBan = simpledialog.askfloat("Input", "Nhập giá bán: ")

        if maSach is None or tenSach is None or tacGia is None or giaBan is None:
            tk.messagebox.showinfo("Thông báo", "Hủy thao tác.")
            return

        sach = Sach(maSach, tenSach, tacGia, giaBan)
        if dequy:
            self.bst.root = self.bst.insert_dequy(self.bst.root, sach)
        else:
            self.bst.root = self.bst.insert_khong_dequy(self.bst.root, sach)

        self.refresh_canvas()


    def delete_node(self, dequy):
        maSach = simpledialog.askinteger( "Input", "Nhập mã sách cần xóa:" )

        if maSach is None:
            return 

        if not self.bst.search(self.bst.root, maSach):
            tk.messagebox.showwarning( "Không tìm thấy." )
            return

        key = Sach(maSach, "", "", 0)

        if dequy:
            self.bst.root = self.bst.delete_dequy( self.bst.root, key )
        else:
            self.bst.root = self.bst.delete_khongdequy( self.bst.root, key )

        self.refresh_canvas()

    def show_height(self):
        height = self.bst.get_height(self.bst.root)
        tk.messagebox.showinfo( "Tree Height", f"Chiều cao hiện tại của cây là: {height}" )

if __name__ == "__main__":
    root = tk.Tk()
    app = giaodienBST(root)
    root.mainloop()