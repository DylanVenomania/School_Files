#Tôn Hoàng Cầm 23110186
from collections import deque 

def find_blank( state ):
    for i in range (3):
        for j in range ( 3):
            if state[i][j] == 0:
                return i, j 
            

def move( state ):
    x, y = find_blank( state )
    direction = [ (-1, 0), (1, 0), (0, -1), (0, 1)] #lên, xuống, trái, phải
    
    next_state = []

    for dx, dy in direction : 
        new_x, new_y = x + dx, y + dy
        if 0 <= new_x < 3 and 0 <= new_y < 3:
            new_state = [  row[:] for row in state ]
            new_state[x][y], new_state[new_x][new_y] = new_state[new_x][new_y] , new_state[x][y]
            next_state.append( new_state )
    return next_state

def bfs( start_state, goal ):
    queue = deque( [ (start_state, [] ) ] )
    visited = set()
    visited.add( tuple( map(tuple, start_state )))

    while queue:
        current_state, path = queue.popleft()
        
        if current_state == goal:
            return path + [current_state]
        
        for next_state in move( current_state ):
            state_tuple = tuple( map (tuple, next_state) )

            if state_tuple not in visited:
                queue.append( (next_state, path+ [current_state]))
                visited.add(state_tuple)
    return None


def dfs( start_state, goal):
    stack = [  ( start_state, [] )  ]
    visited = set()
    visited.add( tuple (  map(tuple, start_state)  ) )

    while stack:
        current_state, path = stack.pop()

        if current_state == goal:
            return path+ [current_state]
        
        for next_state in move( current_state ):
            state_tuple = tuple( map(tuple, next_state) )

            if state_tuple not in visited:
                stack.append( ( next_state, path + [current_state] ) )
                visited.add( state_tuple)
    return None

def ids( start_state, goal):
    

    def dls( state, path, depth):
        if depth == 0:
            return None
        if state == goal:
            return path + [state]
        
        for next_state in move( state ):
            state_tuple = tuple( map(tuple, next_state))
            if state_tuple not in visited:
                visited.add( state_tuple)

                ketqua = dls( next_state, path + [state], depth - 1)
                if ketqua:
                    return ketqua
        return None
    
    for depth in range( 1, 100 ):
        visited = set()
        visited.add( tuple (  map(tuple, start_state)  ) )
        ketqua = dls( start_state, [], depth)
        if ketqua:
            return ketqua
    return None 


import heapq


def ucs( start_state, goal):
    priority_queue = [ (0, start_state, []) ]
    visited = set()
    visited.add( tuple(map(tuple, start_state)))

    while priority_queue:
        cost, current_state, path = heapq.heappop( priority_queue)

        if current_state == goal:
            return path+[current_state]
        
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))

            if state_tuple not in visited:
                heapq.heappush( priority_queue, ( cost + 1, next_state, path + [current_state]) )
                visited.add(state_tuple)
    return None
    

def khoangcach_manhattan( state, goal ):
    khoangcach = 0

    for i in range( 3 ):
        for j in range( 3):
            if state[i][j] != 0:
                #Tìm toạ độ đích của giá trị state[i][j]
                for x in range ( 3) :
                    for y in range ( 3) :
                        if goal[x][y] == state[i][j]:
                            target_x , target_y = x, y
                            break
                khoangcach += abs( target_x - i ) + abs ( target_y - j)

    return khoangcach 



def greedy( start_state, goal ):
    priority_queue = [ (  khoangcach_manhattan(start_state, goal), start_state, []  ) ]
    visited = set() 
    visited.add( tuple( map(tuple, start_state )) )

    while priority_queue : 
        _, current_state, path = heapq.heappop(  priority_queue ) 

        if current_state == goal:
            return path + [ current_state ]
        
        for next_state in move( current_state ):
            state_tuple = tuple( map (tuple, next_state))
            if state_tuple not in visited : 
                heapq.heappush(priority_queue, (khoangcach_manhattan(next_state, goal), next_state, path + [current_state]))
                visited.add(state_tuple)
    return None
                




def tongchiphi( manhattan, chiphi):
    return manhattan + chiphi


def A ( start_state, goal) :
    manhattan = khoangcach_manhattan( start_state, goal )
    cost = 0

    priority_queue = [ ( tongchiphi( manhattan, cost ), manhattan, cost, start_state, [] ) ]
    visited = set() 
    visited.add( tuple( map( tuple, start_state) )  )

    while priority_queue :
        tong, manhattan, cost,  current_state, path = heapq.heappop( priority_queue )

        if  manhattan == 0 or current_state == goal:
            return path + [ current_state ] 
        
        for next_state in move( current_state ):
            state_tuple = tuple ( map( tuple, next_state ))
            if state_tuple not in visited : 
                next_manhattan = khoangcach_manhattan( next_state, goal)
                heapq.heappush( priority_queue, ( tongchiphi(next_manhattan, cost + 1), next_manhattan, cost+1, next_state, path + [current_state] ))
                visited.add( state_tuple)
    return None


def ida (start_state, goal):
    def search( current_state, cost, path, alpha, visited):
        manhattan = khoangcach_manhattan( current_state, goal)
        f = tongchiphi( manhattan, cost)

        if f > alpha:
            return f, None   #vượt ngưỡng alpha thì trả về giá trị f để đièu chỉnh alpha
        
        if manhattan == 0 or current_state == goal:
            return f, path + [current_state] 
        

        next_alpha = float("inf")
        for next_state in  move(current_state):
            state_tuple = tuple( map(tuple, next_state))
            if state_tuple not in visited:
                visited.add(state_tuple)

                next_f, result= search( next_state, cost + 1, path + [current_state], alpha, visited)
                
                if result: 
                    return next_f, result
                
                next_alpha = min(next_alpha, next_f)  #cập nhật ngưỡng tiếp theo
    
        return next_alpha, None 
    

    
    alpha = khoangcach_manhattan( start_state, goal )  #ngưỡng khởi tạo
    
    while True:
        visited = set()
        visited.add( tuple(map(tuple, start_state)))
        next_alpha , result = search( start_state, 0, [], alpha, visited)
        if result:
            return result
        
        if next_alpha == float("inf"):
            return None
        

        alpha = next_alpha


#Thuật toán tìm kiếm Local Search 
#Leo núi đơn giản
def simple_climb( start_state, goal ):
    current_state = start_state.copy()
    path = [current_state]
    
    
    while True:
        if current_state == goal:
            return path.append( current_state )
        
        neighbors = move(current_state)
        found_better = False
        for neighbor in neighbors:
            if khoangcach_manhattan( neighbor, goal) < khoangcach_manhattan(current_state, goal):
                current_state = neighbor
                path.append( current_state )
                found_better = True
                break
        if not found_better:
            return path
    
    return path
        


#Steepest-Ascent Hill Climbing ( Leo đồi dốc nhất )
import copy
def steepest_climb( start_state, goal):
    current_state = copy.deepcopy(start_state)
    path = [current_state]

    while True:
        if current_state == goal:
            return path
        
        neighbors = move(current_state)
        
        if not neighbors:
            return path

        best_neighbor = current_state
        best_manhattan = khoangcach_manhattan( current_state, goal)

        for neighbor in neighbors:
            neighbor_manhattan = khoangcach_manhattan(neighbor, goal)
            if neighbor_manhattan < best_manhattan:
                best_manhattan = neighbor_manhattan
                best_neighbor = neighbor
        
        if  best_neighbor == current_state:
            return path 
        
        current_state = best_neighbor
        path.append( current_state)



import tkinter as tk
from tkinter import messagebox
import time

root = tk.Tk()
root.title("8-Puzzle - Tôn Hoàng Cầm - 23110186")
root.geometry("1500x500")
root.configure(bg="#f0f0f0")

goal_state = [[1, 2, 3], [4, 5, 6], [7, 8, 0]]
start_state = [[0 for _ in range(3)] for _ in range(3)]
current_cells = [[None for _ in range(3)] for _ in range(3)]
goal_cells = [[None for _ in range(3)] for _ in range(3)]
entry_cells = [[None for _ in range(3)] for _ in range(3)]
goal_entry_cells = [[None for _ in range(3)] for _ in range(3)]



frame = tk.Frame(root, bg="#f0f0f0")
frame.pack(pady=10)

title_frame = tk.Frame(frame, bg="#f0f0f0")
title_frame.grid(row=0, column=0, columnspan=4) 


tk.Label(title_frame, text="Nhập trạng thái ban đầu", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=0, padx=70, pady=5, sticky="n")
tk.Label(title_frame, text="Hiện tại", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=1, padx=110, pady=5, sticky="n")
tk.Label(title_frame, text="Đích", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=2, padx=110, pady=5, sticky="n")
tk.Label(title_frame, text="Nhập trạng thái đích", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=3, padx=70, pady=5, sticky="n")

state_frame = tk.Frame(frame, bg="#f0f0f0")
state_frame.grid(row=1, column=0, columnspan=3)

input_frame = tk.Frame(state_frame, bg="#f0f0f0")
input_frame.grid(row=0, column=0, padx=20)

current_frame = tk.Frame(state_frame, bg="#f0f0f0")
current_frame.grid(row=0, column=1, padx=20)

goal_frame = tk.Frame(state_frame, bg="#f0f0f0")
goal_frame.grid(row=0, column=2, padx=20)

goal_input_frame = tk.Frame(state_frame, bg="#f0f0f0")
goal_input_frame.grid(row=0, column=3, padx=20)


for i in range(3):
    for j in range(3):
        entry = tk.Entry(input_frame, width=5, font=("Arial", 24), justify="center")
        entry.grid(row=i, column=j, padx=5, pady=5)
        entry_cells[i][j] = entry


        entry = tk.Entry(goal_input_frame, width=5, font=("Arial", 24), justify="center")
        entry.grid(row=i, column=j, padx=5, pady=5)
        goal_entry_cells[i][j] = entry


        label = tk.Label(current_frame, text="", font=("Arial", 24), width=4, height=2, relief="solid")
        label.grid(row=i, column=j, padx=5, pady=5)
        current_cells[i][j] = label

        label = tk.Label(goal_frame, text="", font=("Arial", 24), width=4, height=2, relief="solid")
        label.grid(row=i, column=j, padx=5, pady=5)
        goal_cells[i][j] = label

        
def draw_grid(state, cells):
    # Kiểm tra xem state có phải là danh sách 2D không
    if not isinstance(state, list) or not all(isinstance(row, list) for row in state):
        raise ValueError(f"Trạng thái không hợp lệ: {state}")
    for i in range(3):
        for j in range(3):
            value = state[i][j]
            cells[i][j].config(
                text=str(value) if value != 0 else "",
                bg="white" if value != 0 else "gray",
                font=("Arial", 24, "bold"),
                width=4,
                height=2,
                relief="solid",
                borderwidth=2
            )

draw_grid(goal_state, goal_cells)

def get_start_state():
    try:
        # Lấy trạng thái bắt đầu từ ô nhập
        for i in range(3):
            for j in range(3):
                start_value = entry_cells[i][j].get()
                goal_value = goal_entry_cells[i][j].get()

                start_state[i][j] = int(start_value) if start_value else 0
                goal_state[i][j] = int(goal_value) if goal_value else 0

        # Kiểm tra hợp lệ
        flat_start = [start_state[i][j] for i in range(3) for j in range(3)]
        flat_goal = [goal_state[i][j] for i in range(3) for j in range(3)]

        if sorted(flat_start) != list(range(9)):
            raise ValueError("Trạng thái ban đầu không hợp lệ! Phải chứa các số từ 0-8 không trùng.")
        if sorted(flat_goal) != list(range(9)):
            raise ValueError("Trạng thái đích không hợp lệ! Phải chứa các số từ 0-8 không trùng.")

        # Cập nhật giao diện
        draw_grid(start_state, current_cells)
        draw_grid(goal_state, goal_cells)
        status_label.config(text="Trạng thái ban đầu và đích đã được cập nhật. Chọn thuật toán để giải.")

    except ValueError as e:
        messagebox.showerror("Lỗi", str(e))



confirm_button = tk.Button(frame, text="Xác nhận trạng thái", font=("Arial", 12), command=get_start_state)
confirm_button.grid(row=2, column=0, columnspan=3, pady=10)

status_label = tk.Label(root, text="Nhập trạng thái ban đầu và nhấn 'Xác nhận trạng thái'", font=("Arial", 14))
status_label.pack()

algorithms = {
    "BFS": bfs,  # Giả sử các hàm khác đã được định nghĩa
    "DFS": dfs,
    "IDS": ids,
    "UCS": ucs,
    "Greedy": greedy,
    "A*": A,
    "IDA": ida,
    "Simple Climb": simple_climb,
    "Steeppest Climb": steepest_climb
}

def solve(algorithm_name):
    algorithm = algorithms[algorithm_name]
    solution = algorithm(start_state, goal_state)
    if solution:
        status_label.config(text=f"Đang chạy {algorithm_name}... ({len(solution)-1} bước)")
        for step in solution:
            draw_grid(step, current_cells)
            root.update_idletasks()
            time.sleep(0.5)
        status_label.config(text=f"Hoàn thành! Tổng số bước: {len(solution)-1}")
    else:
        messagebox.showerror("Lỗi", "Không tìm thấy lời giải!")

button_frame = tk.Frame(root, bg="#f0f0f0")
button_frame.pack(pady=10)
for algorithm_name in algorithms.keys():
    btn = tk.Button(button_frame, text=algorithm_name, font=("Arial", 10), width=15, command=lambda name=algorithm_name: solve(name))
    btn.pack(side=tk.LEFT, padx=5, pady=5)

root.mainloop()