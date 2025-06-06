import tkinter as tk
from tkinter import messagebox
import math

class TreeNode:
    def __init__(self, key):
        self.key = key
        self.left = None
        self.right = None

class BinaryTreeApp:
    def __init__(self, root):
        self.root = root
        self.tree_root = None  # Root of the BST

        # GUI Components
        self.entry_value = tk.Entry(root)
        self.entry_value.pack()

        self.btn_insert_recursive = tk.Button(root, text="Insert Recursive", command=self.insert_recursive)
        self.btn_insert_recursive.pack()

        self.btn_insert_non_recursive = tk.Button(root, text="Insert Non-Recursive", command=self.insert_non_recursive)
        self.btn_insert_non_recursive.pack()

        self.btn_delete_recursive = tk.Button(root, text="Delete Recursive", command=self.delete_recursive)
        self.btn_delete_recursive.pack()

        self.btn_delete_non_recursive = tk.Button(root, text="Delete Non-Recursive", command=self.delete_node_recursive)
        self.btn_delete_non_recursive.pack()

        self.canvas = tk.Canvas(root, width=800, height=600, bg="white")
        self.canvas.pack()

    # BST Operations
    def insert_recursive(self):
        try:
            value = int(self.entry_value.get())
            self.tree_root = self.insert_node_recursive(self.tree_root, value)
            self.redraw_tree()
        except ValueError:
            messagebox.showerror("Error", "Invalid Input! Please enter an integer.")

    def insert_node_recursive(self, root, key):
        if root is None:
            return TreeNode(key)
        if key < root.key:
            root.left = self.insert_node_recursive(root.left, key)
        elif key > root.key:
            root.right = self.insert_node_recursive(root.right, key)
        return root

    def insert_non_recursive(self):
        try:
            value = int(self.entry_value.get())
            self.tree_root = self.insert_node_non_recursive(self.tree_root, value)
            self.redraw_tree()
        except ValueError:
            messagebox.showerror("Error", "Invalid Input! Please enter an integer.")

    def insert_node_non_recursive(self, root, key):
        new_node = TreeNode(key)
        if root is None:
            return new_node
        current = root
        parent = None
        while current:
            parent = current
            if key < current.key:
                current = current.left
            elif key > current.key:
                current = current.right
            else:
                return root
        if key < parent.key:
            parent.left = new_node
        else:
            parent.right = new_node
        return root

    def delete_recursive(self):
        try:
            value = int(self.entry_value.get())
            self.tree_root = self.delete_node_recursive(self.tree_root, value)
            self.redraw_tree()
        except ValueError:
            messagebox.showerror("Error", "Invalid Input! Please enter an integer.")

    def delete_node_recursive(self, root, key):
        if root is None:
            return root
        if key < root.key:
            root.left = self.delete_node_recursive(root.left, key)
        elif key > root.key:
            root.right = self.delete_node_recursive(root.right, key)
        else:
            if root.left is None:
                return root.right
            elif root.right is None:
                return root.left
            min_larger_node = self.get_min(root.right)
            root.key = min_larger_node.key
            root.right = self.delete_node_recursive(root.right, min_larger_node.key)
        return root

    def get_min(self, root):
        while root.left:
            root = root.left
        return root

    # Visualization
    def redraw_tree(self):
        self.canvas.delete("all")  # Clear canvas
        if self.tree_root:
            self.draw_tree(self.tree_root, 400, 50, 200)

    def draw_tree(self, node, x, y, h_gap):
        if node is None:
            return
        r = 20  # Radius of the circle
        # Draw the node
        self.canvas.create_oval(x - r, y - r, x + r, y + r, fill="lightblue")
        self.canvas.create_text(x, y, text=str(node.key), font=("Arial", 12))

        # Draw left subtree
        if node.left:
            x_left = x - h_gap
            y_left = y + 70
            self.canvas.create_line(x, y, x_left, y_left)
            self.draw_tree(node.left, x_left, y_left, h_gap // 2)

        # Draw right subtree
        if node.right:
            x_right = x + h_gap
            y_right = y + 70
            self.canvas.create_line(x, y, x_right, y_right)
            self.draw_tree(node.right, x_right, y_right, h_gap // 2)

# Main Application
if __name__ == "__main__":
    root = tk.Tk()
    root.title("Binary Search Tree Visualization")
    app = BinaryTreeApp(root)
    root.mainloop()