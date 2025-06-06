#Tôn Hoàng Cầm 23110186
from collections import deque 
import heapq
import random
import math
import tkinter as tk
from tkinter import messagebox
import time
import copy

def count_inversions(state):
    flat = [x for row in state for x in row if x != 0]
    inversions = 0
    for i in range(len(flat)):
        for j in range(i + 1, len(flat)):
            if flat[i] > flat[j]:
                inversions += 1
    return inversions

def is_solvable(start, goal):
    start_inv = count_inversions(start)
    goal_inv = count_inversions(goal)
    return (start_inv % 2) == (goal_inv % 2)

def find_blank(state):
    for i in range(3):
        for j in range(3):
            if state[i][j] == 0:
                return i, j 

def move(state):
    x, y = find_blank(state)
    direction = [(-1, 0), (1, 0), (0, -1), (0, 1)] #lên, xuống, trái, phải
    next_state = []
    for dx, dy in direction:
        new_x, new_y = x + dx, y + dy
        if 0 <= new_x < 3 and 0 <= new_y < 3:
            new_state = [row[:] for row in state]
            new_state[x][y], new_state[new_x][new_y] = new_state[new_x][new_y], new_state[x][y]
            next_state.append(new_state)
    return next_state

def bfs(start_state, goal):
    queue = deque([(start_state, [])])
    visited = set()
    visited.add(tuple(map(tuple, start_state)))
    while queue:
        current_state, path = queue.popleft()
        if current_state == goal:
            return path + [current_state]
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                queue.append((next_state, path + [current_state]))
                visited.add(state_tuple)
    return None

def dfs(start_state, goal):
    stack = [(start_state, [])]
    visited = set()
    visited.add(tuple(map(tuple, start_state)))
    while stack:
        current_state, path = stack.pop()
        if current_state == goal:
            return path + [current_state]
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                stack.append((next_state, path + [current_state]))
                visited.add(state_tuple)
    return None

def ids(start_state, goal):
    def dls(state, path, depth):
        if state == goal:
            return path + [state]
        if depth == 0:
            return None
        for next_state in move(state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                visited.add(state_tuple)
                ketqua = dls(next_state, path + [state], depth - 1)
                if ketqua:
                    return ketqua
        return None
    for depth in range(1, 100):
        visited = set()
        visited.add(tuple(map(tuple, start_state)))
        ketqua = dls(start_state, [], depth)
        if ketqua:
            return ketqua
    return None

def ucs(start_state, goal):
    priority_queue = [(0, start_state, [])]
    visited = set()
    visited.add(tuple(map(tuple, start_state)))
    while priority_queue:
        cost, current_state, path = heapq.heappop(priority_queue)
        if current_state == goal:
            return path + [current_state]
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                heapq.heappush(priority_queue, (cost + 1, next_state, path + [current_state]))
                visited.add(state_tuple)
    return None

def khoangcach_manhattan(state, goal):
    khoangcach = 0
    for i in range(3):
        for j in range(3):
            if state[i][j] != 0:
                for x in range(3):
                    for y in range(3):
                        if goal[x][y] == state[i][j]:
                            target_x, target_y = x, y
                            break
                khoangcach += abs(target_x - i) + abs(target_y - j)
    return khoangcach

def greedy(start_state, goal):
    priority_queue = [(khoangcach_manhattan(start_state, goal), start_state, [])]
    visited = set()
    visited.add(tuple(map(tuple, start_state)))
    while priority_queue:
        _, current_state, path = heapq.heappop(priority_queue)
        if current_state == goal:
            return path + [current_state]
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                heapq.heappush(priority_queue, (khoangcach_manhattan(next_state, goal), next_state, path + [current_state]))
                visited.add(state_tuple)
    return None

def tongchiphi(manhattan, chiphi):
    return manhattan + chiphi

def A(start_state, goal):
    manhattan = khoangcach_manhattan(start_state, goal)
    cost = 0
    priority_queue = [(tongchiphi(manhattan, cost), manhattan, cost, start_state, [])]
    visited = set()
    visited.add(tuple(map(tuple, start_state)))
    while priority_queue:
        tong, manhattan, cost, current_state, path = heapq.heappop(priority_queue)
        if manhattan == 0 or current_state == goal:
            return path + [current_state]
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                next_manhattan = khoangcach_manhattan(next_state, goal)
                heapq.heappush(priority_queue, (tongchiphi(next_manhattan, cost + 1), next_manhattan, cost + 1, next_state, path + [current_state]))
                visited.add(state_tuple)
    return None

def ida(start_state, goal):
    def search(current_state, cost, path, alpha, visited):
        manhattan = khoangcach_manhattan(current_state, goal)
        f = tongchiphi(manhattan, cost)
        if f > alpha:
            return f, None
        if manhattan == 0 or current_state == goal:
            return f, path + [current_state]
        next_alpha = float("inf")
        for next_state in move(current_state):
            state_tuple = tuple(map(tuple, next_state))
            if state_tuple not in visited:
                visited.add(state_tuple)
                next_f, result = search(next_state, cost + 1, path + [current_state], alpha, visited)
                if result:
                    return next_f, result
                next_alpha = min(next_alpha, next_f)
        return next_alpha, None
    alpha = khoangcach_manhattan(start_state, goal)
    while True:
        visited = set()
        visited.add(tuple(map(tuple, start_state)))
        next_alpha, result = search(start_state, 0, [], alpha, visited)
        if result:
            return result
        if next_alpha == float("inf"):
            return None
        alpha = next_alpha

def simple_climb(start_state, goal):
    current_state = start_state.copy()
    path = [current_state]
    while True:
        if current_state == goal:
            path.append(current_state)
            return path
        neighbors = move(current_state)
        found_better = False
        for neighbor in neighbors:
            if khoangcach_manhattan(neighbor, goal) < khoangcach_manhattan(current_state, goal):
                current_state = neighbor
                path.append(current_state)
                found_better = True
                break
        if not found_better:
            return path
    return path

def steepest_climb(start_state, goal):
    current_state = copy.deepcopy(start_state)
    path = [current_state]
    while True:
        if current_state == goal:
            return path
        neighbors = move(current_state)
        if not neighbors:
            return path
        best_neighbor = current_state
        best_manhattan = khoangcach_manhattan(current_state, goal)
        for neighbor in neighbors:
            neighbor_manhattan = khoangcach_manhattan(neighbor, goal)
            if neighbor_manhattan < best_manhattan:
                best_manhattan = neighbor_manhattan
                best_neighbor = neighbor
        if best_neighbor == current_state:
            return path
        current_state = best_neighbor
        path.append(current_state)

def check_manhattan(state1, state2, goal):
    if khoangcach_manhattan(state2, goal) < khoangcach_manhattan(state1, goal):
        return True
    return False

def stochastic_climb(start_state, goal):
    current_state = copy.deepcopy(start_state)
    path = [current_state]
    while True:
        if current_state == goal:
            return path
        neighbors = move(current_state)
        better = False
        previous = copy.deepcopy(current_state)
        while not better and neighbors:
            next_state = random.choice(neighbors)
            neighbors.remove(next_state)
            if khoangcach_manhattan(next_state, goal) < khoangcach_manhattan(previous, goal):
                current_state = next_state
                path.append(current_state)
                better = True
                break
        if not better:
            return path

def beam(start_state, goal, beam_width=2):
    queue = [(khoangcach_manhattan(start_state, goal), start_state, [start_state])]
    visited = set([tuple(map(tuple, start_state))])
    while queue:
        current_level = []
        for _ in range(min(beam_width, len(queue))):
            if queue:
                _, state, path = heapq.heappop(queue)
                current_level.append((state, path))
        for state, path in current_level:
            if state == goal:
                return path
        next_candidates = []
        for state, path in current_level:
            neighbors = move(state)
            for neighbor in neighbors:
                state_tuple = tuple(map(tuple, neighbor))
                if state_tuple not in visited:
                    visited.add(state_tuple)
                    heuristic = khoangcach_manhattan(neighbor, goal)
                    next_candidates.append((heuristic, neighbor, path + [neighbor]))
        next_candidates.sort()
        queue = next_candidates[:beam_width]
    return None

def simulated_annealing(start_state, goal):
    current_state = copy.deepcopy(start_state)
    path = [current_state]
    T = 1000
    cooling_rate = 0.95
    max_iterations = 1000
    for _ in range(max_iterations):
        if current_state == goal:
            return path
        neighbors = move(current_state)
        if not neighbors:
            return path
        next_state = random.choice(neighbors)
        delta = khoangcach_manhattan(next_state, goal) - khoangcach_manhattan(current_state, goal)
        if delta < 0 or random.random() < math.exp(-delta / T):
            current_state = next_state
            path.append(current_state)
        T *= cooling_rate
        if T < 0.1:
            break
    return path

def flatten(state):
    return [state[i][j] for i in range(3) for j in range(3)]

def unflatten(flat_state):
    return [[flat_state[i * 3 + j] for j in range(3)] for i in range(3)]

def fitness(state, goal):
    return -khoangcach_manhattan(state, goal)

def crossover(parent1, parent2):
    point = random.randint(1, 8)
    child = parent1[:point] + parent2[point:]
    used = set(child)
    missing = [x for x in range(9) if x not in used]
    for i in range(9):
        if child.count(child[i]) > 1:
            child[i] = missing.pop(0)
    return child

def mutate(individual):
    pos = random.randint(0, 8)
    individual[pos] = random.randint(0, 8)
    used = set(individual)
    missing = [x for x in range(9) if x not in used]
    for i in range(9):
        if individual.count(individual[i]) > 1:
            individual[i] = missing.pop(0)
    return individual

def ditruyen(start_state, goal, pop_size=50, max_generations=100, mutation_rate=0.1):
    flat_start = flatten(start_state)
    flat_goal = flatten(goal)
    population = [flat_start[:] for _ in range(pop_size)]
    for i in range(1, pop_size):
        random.shuffle(population[i])
    for _ in range(max_generations):
        fitness_scores = [(ind, fitness(unflatten(ind), goal)) for ind in population]
        fitness_scores.sort(key=lambda x: x[1], reverse=True)
        if unflatten(fitness_scores[0][0]) == goal:
            path = [unflatten(ind) for ind, _ in fitness_scores[:1]]
            return path
        new_population = [fitness_scores[0][0][:]]
        while len(new_population) < pop_size:
            parent1, parent2 = random.sample([ind for ind, _ in fitness_scores[:pop_size//2]], 2)
            child = crossover(parent1, parent2)
            if random.random() < mutation_rate:
                child = mutate(child)
            new_population.append(child)
        population = new_population
    best_individual = fitness_scores[0][0]
    return [unflatten(best_individual)]

def and_or_search(start_state, goal):
    def search(state, path, visited, depth):
        if depth > 10:
            return None
        state_tuple = tuple(map(tuple, state))
        if state == goal:
            return path + [state]
        if state_tuple in visited:
            return None
        visited = visited | {state_tuple}
        neighbors = move(state)
        if not neighbors:
            return None
        for next_state in neighbors:
            blank_pos = find_blank(next_state)
            goal_blank_pos = find_blank(goal)
            result = search(next_state, path + [state], visited, depth + 1)
            if result:
                return result
        return None
    return search(start_state, [], set(), 0)

def search_no_observation(initial_state, goal):
    belief_state = {tuple(map(tuple, initial_state))}
    plan = []
    path = [copy.deepcopy(initial_state)]
    actions = ["Right", "Down"]
    def apply_action(state, action):
        x, y = find_blank(state)
        moves = {"Up": (-1, 0), "Down": (1, 0), "Left": (0, -1), "Right": (0, 1)}
        dx, dy = moves[action]
        new_x, new_y = x + dx, y + dy
        if 0 <= new_x < 3 and 0 <= new_y < 3:
            new_state = [row[:] for row in state]
            new_state[x][y], new_state[new_x][new_y] = new_state[new_x][new_y], new_state[x][y]
            return new_state
        return state
    for action in actions:
        new_belief_state = set()
        for state in belief_state:
            state_list = [list(row) for row in state]
            result = apply_action(state_list, action)
            new_belief_state.add(tuple(map(tuple, result)))
            if random.random() < 0.5:
                new_belief_state.add(tuple(map(tuple, state_list)))
        belief_state = new_belief_state
        path.append(copy.deepcopy(result))
        if tuple(map(tuple, goal)) in belief_state:
            return path
    return None

def partially_observable_search(start_state, goal):
    belief_state = {tuple(map(tuple, start_state))}
    path = [copy.deepcopy(start_state)]
    visited = set()
    max_steps = 50
    def apply_action(state, action):
        x, y = find_blank(state)
        moves = {"Up": (-1, 0), "Down": (1, 0), "Left": (0, -1), "Right": (0, 1)}
        dx, dy = moves.get(action, (0, 0))
        new_x, new_y = x + dx, y + dy
        if 0 <= new_x < 3 and 0 <= new_y < 3:
            new_state = [row[:] for row in state]
            new_state[x][y], new_state[new_x][new_y] = new_state[new_x][new_y], new_state[x][y]
            return new_state
        return None
    step = 0
    while belief_state and step < max_steps:
        if all(state == tuple(map(tuple, goal)) for state in belief_state):
            return path
        actions = ["Up", "Down", "Left", "Right"]
        action = random.choice(actions)
        new_belief_state = set()
        new_path_state = None
        for state in belief_state:
            state_list = [list(row) for row in state]
            new_state = apply_action(state_list, action)
            if new_state:
                new_state_tuple = tuple(map(tuple, new_state))
                new_belief_state.add(new_state_tuple)
                if not new_path_state:
                    new_path_state = new_state
        if new_belief_state:
            belief_state_tuple = frozenset(new_belief_state)
            if belief_state_tuple not in visited:
                visited.add(belief_state_tuple)
                belief_state = new_belief_state
                if new_path_state:
                    path.append(new_path_state)
            else:
                continue
        step += 1
    return None



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
tk.Label(title_frame, text="Hiện tại", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=1, padx=100, pady=5, sticky="n")
tk.Label(title_frame, text="Đích", font=("Arial", 14, "bold"), bg="#f0f0f0").grid(row=0, column=2, padx=150, pady=5, sticky="n")
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
        for i in range(3):
            for j in range(3):
                start_value = entry_cells[i][j].get()
                goal_value = goal_entry_cells[i][j].get()
                start_state[i][j] = int(start_value) if start_value else 0
                goal_state[i][j] = int(goal_value) if goal_value else 0
        flat_start = [start_state[i][j] for i in range(3) for j in range(3)]
        flat_goal = [goal_state[i][j] for i in range(3) for j in range(3)]
        if sorted(flat_start) != list(range(9)):
            raise ValueError("Trạng thái ban đầu không hợp lệ! Phải chứa các số từ 0-8 không trùng.")
        if sorted(flat_goal) != list(range(9)):
            raise ValueError("Trạng thái đích không hợp lệ! Phải chứa các số từ 0-8 không trùng.")
        if not is_solvable(start_state, goal_state):
            raise ValueError("Trạng thái ban đầu và đích không thể giải được!")
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
    "BFS": bfs,
    "DFS": dfs,
    "IDS": ids,
    "UCS": ucs,
    "Greedy": greedy,
    "A*": A,
    "IDA": ida,
    "Simple Climb": simple_climb,
    "Steeppest Climb": steepest_climb,
    "Stochastic Climb": stochastic_climb,
    "Simulated Annealing": simulated_annealing,
    "Beam Search": beam,
    "Genetic Algorithm": ditruyen,
    "And-Or Search": and_or_search,
    "No Observation": search_no_observation,
    "Partially Observable": partially_observable_search
}

def solve(algorithm_name):
    algorithm = algorithms[algorithm_name]
    solution = algorithm(start_state, goal_state)
    if solution:
        status_label.config(text=f"     Đang chạy {algorithm_name}... ({len(solution)-1} bước)      ")
        for step in solution:
            draw_grid(step, current_cells)
            root.update_idletasks()
            time.sleep(0.5)
        status_label.config(text=f"Hoàn thành! Tổng số bước: {len(solution)-1}")
    else:
        messagebox.showerror("Lỗi", "Không tìm thấy lời giải!")

button_frame = tk.Frame(root)
button_frame.pack(pady=10)
canvas = tk.Canvas(button_frame, width=1480, height=100, bg="#f0f0f0")
scrollbar = tk.Scrollbar(button_frame, orient="horizontal", command=canvas.xview)
canvas.configure(xscrollcommand=scrollbar.set)
scrollbar.pack(side=tk.BOTTOM, fill=tk.X)
canvas.pack(side=tk.LEFT)
inner_frame = tk.Frame(canvas, bg="#f0f0f0")
canvas.create_window((0, 0), window=inner_frame, anchor="nw")

for algorithm_name in algorithms.keys():
    btn = tk.Button(inner_frame, text=algorithm_name, font=("Arial", 10), width=15,
                    command=lambda name=algorithm_name: solve(name))
    btn.pack(side=tk.LEFT, padx=5, pady=5)

inner_frame.update_idletasks()
canvas.config(scrollregion=canvas.bbox("all"))

root.mainloop()
