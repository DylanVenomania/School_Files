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
            


import tkinter as tk
from tkinter import messagebox
import time

root = tk.Tk()
root.title("8-Puzzle - Tôn Hoàng Cầm - 23110186")
root.geometry("800x400")
root.configure(bg="#f0f0f0")


start_state = [[2, 6, 5], [0, 8, 7], [4, 3, 1]]
goal_state = [[1, 2, 3], [4, 5, 6], [7, 8, 0]]


current_cells = [[None for _ in range(3)] for _ in range(3)]
goal_cells = [[None for _ in range(3)] for _ in range(3)]

# Khung chứa lưới 8-Puzzle
frame = tk.Frame(root, bg="#f0f0f0")
frame.pack(pady=10)  



title_frame = tk.Frame(frame, bg="#f0f0f0")
title_frame.grid(row=0, column=0, columnspan=2)


tk.Label(title_frame, text="Hiện tại", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=0, padx=120)
tk.Label(title_frame, text="Đích", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=1, padx=120)


state_frame = tk.Frame(root, bg="#f0f0f0")
state_frame.pack()

current_frame = tk.Frame(state_frame)
current_frame.grid(row=1, column=0, padx=50)

goal_frame = tk.Frame(state_frame)
goal_frame.grid(row=1, column=1, padx=50)





algorithms = {
    "BFS": bfs,
    "DFS": dfs,
    "IDS": ids,
    "UCS": ucs,
    "Greedy": greedy,
    "A*": A,
    "IDA" : ida,
}



# Hiển thị trạng thái lên lưới
def draw_grid(state, cells):
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

for i in range(3):
    for j in range(3):
        label = tk.Label(current_frame, text="", font=("Arial", 24), width=4, height=2, relief="solid")
        label.grid(row=i, column=j, padx=5, pady=5)
        current_cells[i][j] = label

        label = tk.Label(goal_frame, text="", font=("Arial", 24), width=4, height=2, relief="solid")
        label.grid(row=i, column=j, padx=5, pady=5)
        goal_cells[i][j] = label


#Vẽ trạng thái
draw_grid(start_state, current_cells)
draw_grid(goal_state, goal_cells)


status_label = tk.Label(root, text="Chọn thuật toán để giải bài toán", font=("Arial", 14))
status_label.pack()

# giải thuật toán
def solve(algorithm_name):
    algorithm = algorithms[algorithm_name]
    solution = algorithm(start_state, goal_state)

    if solution:
        status_label.config(text=f"Đang chạy {algorithm_name}... ({len(solution)-1} bước)")
        for step in solution:
            draw_grid(step, current_cells)
            root.update_idletasks()  
            time.sleep(0.05)
        status_label.config(text=f"Hoàn thành! Tổng số bước: {len(solution)-1}")
    else:
        messagebox.showerror("Lỗi", "Không tìm thấy lời giải!")


button_frame = tk.Frame(root, bg="#f0f0f0")
button_frame.pack()

# Tạo các nút 
for algorithm_name in algorithms.keys():
    btn = tk.Button(button_frame, text=algorithm_name, font=("Arial", 12), width=10, command=lambda name=algorithm_name: solve(name))
    btn.pack(side=tk.LEFT, padx=5, pady=5)

root.mainloop()