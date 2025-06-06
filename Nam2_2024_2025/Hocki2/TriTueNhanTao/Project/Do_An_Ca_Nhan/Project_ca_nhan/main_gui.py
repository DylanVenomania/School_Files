import tkinter as tk
from tkinter import ttk, messagebox
from puzzle_solver import PuzzleState, PuzzleSolver
import random
from puzzle_solver import PartiallyObservablePuzzle, DynamicPuzzleEnvironment

class PuzzleGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("8-Puzzle Solver")
        self.root.geometry("600x700")
        self.root.resizable(False, False)
        
        # Khởi tạo các biến
        self.initial_state = None
        self.goal_state = PuzzleState([[1, 2, 3], [4, 5, 6], [7, 8, 0]])
        self.solution_path = None
        self.current_step = 0
        self.partial_observer = None
        self.dynamic_env = None
        self.change_prob = 0.1
        
        self.create_widgets()
        self.generate_random_board()  # Tự động tạo bảng khi khởi động
        
    def create_widgets(self):
        # Frame chính
        main_frame = ttk.Frame(self.root, padding="10")
        main_frame.pack(fill=tk.BOTH, expand=True)
        
        # Tiêu đề
        ttk.Label(main_frame, text="8-PUZZLE SOLVER", 
                 font=('Arial', 16, 'bold')).pack(pady=10)
        
        # Frame điều khiển
        control_frame = ttk.Frame(main_frame)
        control_frame.pack(pady=5)
        
        # Nút tạo mới
        ttk.Button(control_frame, text="Tạo bảng mới", 
                  command=self.generate_random_board).pack(side=tk.LEFT, padx=5)
        # Nút nhập trạng thái
        ttk.Button(control_frame, text="Nhập trạng thái", 
                  command=self.input_custom_board).pack(side=tk.LEFT, padx=5)
        
        # Chọn thuật toán
        ttk.Label(control_frame, text="Thuật toán:").pack(side=tk.LEFT, padx=5)
        self.algorithm = ttk.Combobox(
            control_frame, 
            values=[
                "BFS", "DFS", "UCS", "IDS", 
                "Greedy", "A*", "IDA*",
                "Simple Hill Climbing", 
                "Stochastic Hill Climbing",
                "Steepest Ascent Hill Climbing",
                "Simulated Annealing",
                "Genetic Algorithm",
                "Beam Search",
                "AND-OR Search",                    
                "Partial Observation",              
                "Dynamic Environment",
                # Nhóm 5: Thuật toán CSP
                "CSP: Backtracking",
                "CSP: Forward Checking",
                "CSP: AC-3",
                # Nhóm 6: Q-learning
                "Q-learning"
            ],
            state="readonly",
            width=20
        )
        self.algorithm.current(0)  # Mặc định chọn BFS
        self.algorithm.pack(side=tk.LEFT, padx=5)
        self.algorithm.bind("<<ComboboxSelected>>", self.on_algorithm_change)
        
        # Nút giải
        self.solve_btn = ttk.Button(
            control_frame, 
            text="Giải", 
            command=self.solve_puzzle
        )
        self.solve_btn.pack(side=tk.LEFT, padx=5)
        
        # Hiển thị bảng
        self.board_frame = ttk.Frame(main_frame, relief="sunken", padding=5)
        self.board_frame.pack(pady=10)
        self.tiles = []
        for i in range(3):
            row = []
            for j in range(3):
                tile = tk.Label(
                    self.board_frame, 
                    text="", 
                    width=6, 
                    height=3,
                    relief="ridge",
                    font=('Arial', 16, 'bold'),
                    bg='white'
                )
                tile.grid(row=i, column=j, padx=2, pady=2)
                row.append(tile)
            self.tiles.append(row)
        
        # Frame điều hướng
        nav_frame = ttk.Frame(main_frame)
        nav_frame.pack(pady=10)
        
        ttk.Button(nav_frame, text="Bắt đầu", 
                  command=self.start_solution).pack(side=tk.LEFT, padx=2)
        ttk.Button(nav_frame, text="Trước", 
                  command=self.prev_step).pack(side=tk.LEFT, padx=2)
        ttk.Button(nav_frame, text="Tiếp", 
                  command=self.next_step).pack(side=tk.LEFT, padx=2)
        
        # Thông tin
        self.info_label = ttk.Label(
            main_frame, 
            text="Nhấn 'Tạo bảng mới' để bắt đầu", 
            wraplength=500
        )
        self.info_label.pack(pady=10)
        
        # Hướng dẫn
        help_text = """HƯỚNG DẪN:
1. Nhấn 'Tạo bảng mới' để tạo bảng ngẫu nhiên
2. Chọn thuật toán và nhấn 'Giải'
3. Dùng nút 'Trước'/'Tiếp' để xem từng bước"""
        
        ttk.Label(main_frame, text=help_text, 
                 justify=tk.LEFT).pack(pady=10)
        
    def generate_random_board(self):
        """Tạo bảng ngẫu nhiên có thể giải được"""
        import random
        while True:
            numbers = list(range(9))
            random.shuffle(numbers)
            board = [numbers[i:i+3] for i in range(0, 9, 3)]
            if self.is_solvable(board):
                break
                
        self.set_board_state(board)

    def set_board_state(self, board):
        """Cập nhật giao diện và trạng thái với board cho trước"""
        # Cập nhật giao diện
        for i in range(3):
            for j in range(3):
                num = board[i][j]
                self.tiles[i][j].config(
                    text=str(num) if num != 0 else "",
                    bg='lightblue' if num != 0 else 'white'
                )
        # Lưu trạng thái
        self.initial_state = PuzzleState(board)
        self.solution_path = None
        self.current_step = 0
        self.info_label.config(
            text="Đã cập nhật trạng thái ban đầu. Chọn thuật toán và nhấn 'Giải'.",
            foreground='black'
        )

    def input_custom_board(self):
        """Hiện popup cho phép nhập trạng thái ban đầu tùy ý"""
        popup = tk.Toplevel(self.root)
        popup.title("Nhập trạng thái ban đầu")
        popup.geometry("320x250")
        ttk.Label(popup, text="Nhập 9 số (0-8, không trùng, 0 là ô trống)", font=('Arial', 10)).pack(pady=5)
        entry_vars = [[tk.StringVar() for _ in range(3)] for _ in range(3)]
        entry_widgets = []
        frame = ttk.Frame(popup)
        frame.pack(pady=5)
        for i in range(3):
            row_widgets = []
            for j in range(3):
                e = ttk.Entry(frame, width=2, font=('Arial', 14), textvariable=entry_vars[i][j], justify='center')
                e.grid(row=i, column=j, padx=4, pady=4)
                row_widgets.append(e)
            entry_widgets.append(row_widgets)
        def submit():
            try:
                nums = []
                for i in range(3):
                    row = []
                    for j in range(3):
                        val = entry_vars[i][j].get().strip()
                        if not val.isdigit():
                            raise ValueError(f"Vị trí ({i+1},{j+1}) không hợp lệ!")
                        n = int(val)
                        row.append(n)
                        nums.append(n)
                    
                    if len(row) != 3:
                        raise ValueError("Mỗi dòng phải có 3 số")
                if sorted(nums) != list(range(9)):
                    raise ValueError("Phải nhập đủ 9 số từ 0 đến 8, không trùng!")
                board = [nums[i*3:(i+1)*3] for i in range(3)]
                if not self.is_solvable(board):
                    raise ValueError("Bảng này không thể giải được!")
                self.set_board_state(board)
                popup.destroy()
            except Exception as e:
                messagebox.showerror("Lỗi nhập liệu", str(e), parent=popup)
        ttk.Button(popup, text="Xác nhận", command=submit).pack(pady=10)
        ttk.Button(popup, text="Hủy", command=popup.destroy).pack()
    
    def is_solvable(self, board):
        """Kiểm tra xem bảng có thể giải được không"""
        inversions = 0
        flat = [num for row in board for num in row if num != 0]
        
        for i in range(len(flat)):
            for j in range(i + 1, len(flat)):
                if flat[i] > flat[j]:
                    inversions += 1
        
        return inversions % 2 == 0
    
    def solve_puzzle(self):
        """Giải bài toán với thuật toán đã chọn"""
        if not hasattr(self, 'initial_state') or not self.initial_state:
            messagebox.showerror("Lỗi", "Vui lòng tạo bảng trước!")
            return

        # Ánh xạ tên thuật toán
        method_map = {
            # Nhóm 1: Tìm kiếm cơ bản
            "BFS": "bfs",
            "DFS": "dfs",
            "UCS": "ucs",
            "IDS": "ids",
            # Nhóm 2: Tìm kiếm heuristic
            "Greedy": "greedy",
            "A*": "a_star",
            "IDA*": "ida_star",
            # Nhóm 3: Tìm kiếm cục bộ
            "Simple Hill Climbing": "simple_hill_climb",
            "Stochastic Hill Climbing": "stochastic_hill_climb",
            "Steepest Ascent Hill Climbing": "steepest_hill_climb",
            "Simulated Annealing": "simulated_annealing",
            "Genetic Algorithm": "genetic",
            "Beam Search": "beam_search",
            # Nhóm 4: Thuật toán nâng cao
            "AND-OR Search": "and_or",
            "Partial Observation": "partial_observation",
            "Dynamic Environment": "dynamic_env",
            # Nhóm 5: Thuật toán CSP
            "CSP: Backtracking": "csp_backtracking",
            "CSP: Forward Checking": "csp_forward_checking",
            "CSP: AC-3": "csp_ac3",
            # Nhóm 6: Q-learning
            "Q-learning": "q_learning"
        }

        method = method_map.get(self.algorithm.get())
        if not method:
            messagebox.showerror("Lỗi", "Vui lòng chọn thuật toán hợp lệ!")
            return

        # Vô hiệu hóa nút giải trong khi xử lý
        self.solve_btn.config(state=tk.DISABLED)
        self.info_label.config(text=f"Đang giải bằng {self.algorithm.get()}...", foreground='blue')
        self.root.update()

        # Xóa solution cũ
        self.solution_path = None
        self.current_step = 0

        # Xóa partial_observer cũ nếu có
        if hasattr(self, 'partial_observer'):
            self.partial_observer = None

        try:
            # Giải trong một luồng riêng để tránh đóng băng giao diện
            import threading
            
            def solve():
                try:
                    result = None
                    
                    # Xử lý riêng cho từng nhóm thuật toán
                    if method in ['and_or', 'partial_observation', 'dynamic_env']:
                        # Chuẩn bị tham số cho thuật toán nhóm 4
                        kwargs = {
                            'max_steps': 1000
                        }
                        
                        # Thêm tham số đặc biệt cho từng thuật toán
                        if method == 'dynamic_env':
                            kwargs['change_probability'] = getattr(self, 'change_prob', 0.1)
                        elif method == 'and_or':
                            kwargs['max_depth'] = 30
                        
                        # Xử lý đặc biệt cho Partial Observation
                        if method == 'partial_observation':
                            self.partial_observer = PartiallyObservablePuzzle(self.initial_state)
                        
                        result = PuzzleSolver.advanced_search(
                            self.initial_state,
                            self.goal_state,
                            method=method,
                            **kwargs
                        )
                    elif method.startswith('csp_'):
                        # Xử lý các thuật toán CSP
                        csp_method = method[4:]  # Bỏ 'csp_' ở đầu
                        result = PuzzleSolver.solve_with_csp(
                            self.initial_state,
                            self.goal_state,
                            method=csp_method
                        )
                    else:
                        # Xử lý cho các thuật toán nhóm 1-3 và Q-learning
                        if method == 'q_learning':
                            result = PuzzleSolver.q_learning(
                                self.initial_state,
                                self.goal_state,
                                episodes=2000, max_steps=100, alpha=0.1, gamma=0.9, epsilon=0.2
                            )
                        elif method in ['dfs', 'ids']:
                            result = PuzzleSolver.solve(
                                self.initial_state, 
                                self.goal_state, 
                                method, 
                                max_depth=30
                            )
                        elif method == 'ida_star':
                            result = PuzzleSolver.solve(
                                self.initial_state, 
                                self.goal_state, 
                                method, 
                                max_depth=100
                            )
                        else:
                            result = PuzzleSolver.solve(
                                self.initial_state, 
                                self.goal_state, 
                                method
                            )
                    
                    # Cập nhật giao diện khi hoàn thành
                    self.root.after(0, self._on_solve_complete, result)
                    
                except Exception as e:
                    import traceback
                    error_msg = f"{str(e)}\n\n{traceback.format_exc()}"
                    self.root.after(0, self._on_solve_error, error_msg)
            
            # Bắt đầu luồng giải
            threading.Thread(target=solve, daemon=True).start()
            
        except Exception as e:
            self._on_solve_error(str(e))
            self.solve_btn.config(state=tk.NORMAL)

    def _on_solve_complete(self, result):
        """Xử lý khi giải xong"""
        self.solve_btn.config(state=tk.NORMAL)
        
        if result and len(result) > 0:
            self.solution_path = result
            self.current_step = 0
            
            # Cập nhật giao diện với trạng thái ban đầu
            if hasattr(self, 'partial_observer') and self.partial_observer:
                # Lấy trạng thái hiện tại từ partial_observer
                if self.partial_observer.belief_states:
                    current_state = next(iter(self.partial_observer.belief_states))
                    self.update_board(current_state.board)
                else:
                    self.update_board(self.initial_state.board)
            else:
                self.update_board(self.initial_state.board)
            
            # Đếm số bước thực tế (bỏ qua các bước thay đổi môi trường)
            actual_steps = len([step for step in result if step[0] not in ('env_change', None)])
            
            self.info_label.config(
                text=f"Đã tìm thấy lời giải với {actual_steps} bước.\n"
                    "Sử dụng các nút 'Trước'/'Tiếp' để xem từng bước.",
                foreground='green'
            )
        else:
            self.solution_path = None
            self.info_label.config(
                text="Không tìm thấy lời giải sau số bước tối đa!",
                foreground='red'
            )
    
    def _on_solve_error(self, error_msg):
        """Xử lý khi có lỗi"""
        self.solve_btn.config(state=tk.NORMAL)
        messagebox.showerror("Lỗi", f"Có lỗi xảy ra: {error_msg}")
        self.info_label.config(
            text="Đã xảy ra lỗi. Vui lòng thử lại!",
            foreground='red'
        )
    
    def start_solution(self):
        """Bắt đầu hiển thị lời giải từng bước"""
        if not hasattr(self, 'solution_path') or not self.solution_path:
            self.info_label.config(text="Không có lời giải để hiển thị", foreground='red')
            return
        
        # Nếu đang ở chế độ Partial Observation
        if hasattr(self, 'partial_observer') and self.partial_observer is not None:
            self.current_step = 0
            # Hiển thị trạng thái ban đầu với các ô chưa quan sát
            observed_board = self.partial_observer.get_observed_board(self.initial_state)
            self.update_board(observed_board)
            self.info_label.config(
                text=f"Bắt đầu lời giải Partial Observation\n" +f"Đã quan sát: {len(self.partial_observer.observed_positions)}/9 ô",
                foreground='black'
            )
            self.update_board(self.solution_path[0][1] if self.solution_path[0][1] is not None 
                            else self.initial_state.board)
            self.info_label.config(
                text=f"Bước {self.current_step + 1}/{len(self.solution_path)}", 
                foreground='black'
            )
            # Kích hoạt nút "Tiếp" nếu còn bước
            self.next_btn.config(state=tk.NORMAL if len(self.solution_path) > 1 else tk.DISABLED)
    
    def prev_step(self):
        """Về bước trước đó"""
        if not self.solution_path or self.current_step <= 0:
            return
            
        self.current_step -= 1
        
        if self.current_step == 0:
            # Về trạng thái ban đầu
            self.update_board(self.initial_state.board)
        else:
            # Xử lý tương tự next_step nhưng với current_step - 1
            step = self.solution_path[self.current_step - 1]
            
            if isinstance(step, tuple) and len(step) == 2:
                # Trường hợp (move, board)
                move, board = step
                self.update_board(board)
            else:
                # Trường hợp chỉ có move, cần tạo lại từ đầu
                current_state = self.initial_state
                for i in range(self.current_step):
                    move = self.solution_path[i]
                    if isinstance(move, tuple) and len(move) == 2:
                        move = move[0]  # Lấy move từ (move, board)
                    
                    found = False
                    for b, m in current_state.get_possible_moves():
                        if m == move:
                            current_state = PuzzleState(b, current_state, m, 0, 0)
                            found = True
                            break
                    
                    if not found:
                        messagebox.showerror("Lỗi", f"Không thể quay lại bước {i+1}")
                        return
                
                self.update_board(current_state.board)
    
    def next_step(self):
        """Chuyển đến bước tiếp theo trong lời giải"""
        if not hasattr(self, 'solution_path') or not self.solution_path:
            self.info_label.config(text="Không có lời giải để hiển thị", foreground='red')
            return

        # Lấy phương pháp hiện tại
        current_method = self.algorithm.get()

        # Xử lý Partial Observation
        if hasattr(self, 'partial_observer') and self.partial_observer is not None:
            if self.current_step < len(self.solution_path):
                move, _ = self.solution_path[self.current_step]
                self.partial_observer.update_belief(move)
                # Lấy một trạng thái hiện tại bất kỳ trong belief_states để hiển thị
                if self.partial_observer.belief_states:
                    current_state = next(iter(self.partial_observer.belief_states))
                    self.update_board(current_state.board)
                self.current_step += 1
                self.info_label.config(
                    text=f"Bước {self.current_step}/{len(self.solution_path)}",
                    foreground='black'
                )
                if self.current_step >= len(self.solution_path):
                    self.next_btn.config(state=tk.DISABLED)
                    self.info_label.config(text="Đã hoàn thành lời giải!", foreground='green')
            else:
                self.info_label.config(text="Đã đến bước cuối cùng", foreground='green')

        # Xử lý CSP
        elif current_method in ['CSP: Backtracking', 'CSP: Forward Checking', 'CSP: AC-3']:
            if self.current_step + 1 < len(self.solution_path):
                self.current_step += 1
                _, state = self.solution_path[self.current_step]
                self.update_board(state)  # state is already a board (list of lists)
                self.info_label.config(
                    text=f"Bước {self.current_step + 1}/{len(self.solution_path)}",
                    foreground='black'
                )
                if self.current_step + 1 >= len(self.solution_path):
                    self.next_btn.config(state=tk.DISABLED)
                    self.info_label.config(text="Đã hoàn thành lời giải!", foreground='green')
            else:
                self.info_label.config(text="Đã đến bước cuối cùng", foreground='green')

        # Các thuật toán khác
        else:
            if self.current_step + 1 < len(self.solution_path):
                self.current_step += 1
                self.update_board(
                    self.solution_path[self.current_step][1]
                    if self.solution_path[self.current_step][1] is not None
                    else self.initial_state.board
                )
                self.info_label.config(
                    text=f"Bước {self.current_step + 1}/{len(self.solution_path)}",
                    foreground='black'
                )
                if self.current_step + 1 >= len(self.solution_path):
                    self.next_btn.config(state=tk.DISABLED)
                    self.info_label.config(text="Đã hoàn thành lời giải!", foreground='green')
            else:
                self.info_label.config(text="Đã đến bước cuối cùng", foreground='green')

    def update_board(self, board):
        """Cập nhật giao diện bảng"""
        if board is None:
            return
            
        for i in range(3):
            for j in range(3):
                tile = self.tiles[i][j]
                
                # Kiểm tra nếu đang ở chế độ Partial Observation
                if hasattr(self, 'partial_observer') and self.partial_observer is not None:
                    # Kiểm tra ô (i,j) đã được quan sát chưa
                    if (i, j) not in self.partial_observer.observed_positions:
                        tile.config(
                            text="?",
                            bg='#CCCCCC',  # Màu xám cho ô chưa quan sát
                            font=('Arial', 16, 'bold')
                        )
                        continue
                
                # Hiển thị giá trị ô bình thường
                num = board[i][j] if i < len(board) and j < len(board[i]) else 0
                bg_color = 'lightgreen' if num != 0 else 'white'
                
                # Đánh dấu ô đúng vị trí đích
                if (hasattr(self, 'goal_state') and 
                    i < len(self.goal_state.board) and 
                    j < len(self.goal_state.board[0]) and
                    num != 0 and 
                    num == self.goal_state.board[i][j]):
                    bg_color = '#90EE90'  # Màu xanh lá nhạt
                
                tile.config(
                    text=str(num) if num != 0 else "",
                    bg=bg_color,
                    font=('Arial', 16, 'bold')
                )

    def solve_partial_observation(self):
        """Giải bài toán Partial Observation và trả về danh sách các bước"""
        if not hasattr(self, 'partial_observer') or not self.partial_observer:
            return []
        
        solution = []
        current_state = self.initial_state
        max_steps = 100  # Tăng số bước tối đa
        visited = set()  # Theo dõi các trạng thái đã thăm
        
        for _ in range(max_steps):
            # Kiểm tra nếu đã đến đích
            if current_state.is_goal(self.goal_state):
                break
            
            # Lấy các nước đi có thể
            possible_moves = current_state.get_possible_moves()
            if not possible_moves:
                break
            
            # Chọn nước đi tốt nhất dựa trên heuristic
            best_move = None
            best_score = float('inf')
            best_board = None
            
            for board, move in possible_moves:
                # Tạo trạng thái mới
                new_state = PuzzleState(
                    board, 
                    current_state, 
                    move, 
                    current_state.depth + 1, 
                    0
                )
                
                # Tính điểm heuristic (khoảng cách Manhattan)
                score = new_state.manhattan_distance(self.goal_state)
                
                # Tránh lặp lại các trạng thái
                state_key = tuple(tuple(row) for row in board)
                if state_key in visited:
                    score += 1000  # Phạt các trạng thái đã thăm
                    
                if score < best_score:
                    best_score = score
                    best_move = move
                    best_board = board
            
            # Nếu không tìm được nước đi hợp lệ
            if best_move is None:
                break
            
            # Lưu lại bước đi
            solution.append((best_move, best_board))
            
            # Cập nhật trạng thái hiện tại
            current_state = PuzzleState(
                best_board, 
                current_state, 
                best_move, 
                current_state.depth + 1, 
                0
            )
            
            # Đánh dấu đã thăm
            visited.add(tuple(tuple(row) for row in best_board))
        
        return solution
    
    def on_algorithm_change(self, event=None):
        """Xử lý khi thay đổi thuật toán"""
        algo = self.algorithm.get()
        
        # Xóa frame tùy chọn nâng cao cũ nếu có
        if hasattr(self, 'advanced_frame'):
            self.advanced_frame.destroy()
        
        # Thêm tùy chọn cho Dynamic Environment
        if algo == "Dynamic Environment":
            self.advanced_frame = ttk.Frame(self.root)
            self.advanced_frame.pack(pady=5)
            
            ttk.Label(
                self.advanced_frame, 
                text="Xác suất thay đổi:"
            ).pack(side=tk.LEFT, padx=5)
            
            self.change_prob_var = tk.DoubleVar(value=0.1)
            
            def update_prob(val):
                self.change_prob = float(val)
                self.prob_label.config(text=f"{float(val):.2f}")
            
            ttk.Scale(
                self.advanced_frame,
                from_=0,
                to=0.5,
                variable=self.change_prob_var,
                command=update_prob,
                length=200
            ).pack(side=tk.LEFT)
            
            self.prob_label = ttk.Label(self.advanced_frame, text="0.10")
            self.prob_label.pack(side=tk.LEFT, padx=5)
            
            # Khởi tạo giá trị mặc định
            self.change_prob = 0.1

if __name__ == "__main__":
    root = tk.Tk()
    app = PuzzleGUI(root)
    root.mainloop()

    