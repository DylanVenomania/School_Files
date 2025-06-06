import random
import math
import copy
import heapq
from collections import defaultdict

class PuzzleState:
    """Lớp đại diện cho một trạng thái của bài toán 8-puzzle.
    
    Attributes:
        board (list): Ma trận 3x3 đại diện cho trạng thái hiện tại
        parent (PuzzleState): Trạng thái cha
        move (str): Bước di chuyển để đạt được trạng thái này
        cost (int): Chi phí để đạt được trạng thái này
        depth (int): Độ sâu của trạng thái trong cây tìm kiếm
        blank_pos (tuple): Vị trí của ô trống (hàng, cột)
    """
    def __init__(self, board, parent=None, move="", cost=0, depth=0):
        """Khởi tạo một trạng thái mới.
        
        Args:
            board (list): Ma trận 3x3
            parent (PuzzleState, optional): Trạng thái cha. Mặc định là None.
            move (str, optional): Bước di chuyển. Mặc định là "".
            cost (int, optional): Chi phí. Mặc định là 0.
            depth (int, optional): Độ sâu. Mặc định là 0.
            
        Raises:
            ValueError: Nếu board không hợp lệ
        """
        # Kiểm tra đầu vào
        if not self._is_valid_board(board):
            raise ValueError("Board không hợp lệ: phải là ma trận 3x3 chứa các số từ 0-8 không trùng lặp")
            
        self.board = [row[:] for row in board]  # Tạo bản sao để tránh thay đổi ngoài ý muốn
        self.parent = parent
        self.move = move
        self.cost = cost
        self.depth = depth
        self.blank_pos = self.find_blank()
        
    def _is_valid_board(self, board):
        """Kiểm tra xem board có hợp lệ không."""
        if len(board) != 3 or any(len(row) != 3 for row in board):
            return False
            
        # Kiểm tra các số từ 0-8 và không trùng lặp
        numbers = [num for row in board for num in row]
        return sorted(numbers) == list(range(9))
        
    def find_blank(self):
        for i in range(3):
            for j in range(3):
                if self.board[i][j] == 0:
                    return (i, j)
        return None
    
    def is_goal(self, goal_state):
        return self.board == goal_state.board
    
    def get_possible_moves(self):
        moves = []
        i, j = self.blank_pos
        directions = [(-1, 0, 'Up'), (1, 0, 'Down'), (0, -1, 'Left'), (0, 1, 'Right')]
        
        for di, dj, move in directions:
            new_i, new_j = i + di, j + dj
            if 0 <= new_i < 3 and 0 <= new_j < 3:
                new_board = [row[:] for row in self.board]
                new_board[i][j], new_board[new_i][new_j] = new_board[new_i][new_j], new_board[i][j]
                moves.append((new_board, move))
        return moves
    
    def get_path(self):
        path = []
        current = self
        while current.parent is not None:
            path.append((current.move, current.board))
            current = current.parent
        path.reverse()
        return path
    
    def __eq__(self, other):
        """Kiểm tra hai trạng thái có bằng nhau không"""
        if not isinstance(other, PuzzleState):
            return False
        return self.board == other.board
    
    def __hash__(self):
        """Hàm băm cho đối tượng, cần thiết khi sử dụng trong set"""
        return hash(tuple(tuple(row) for row in self.board))
    
    def __str__(self):
        return '\n'.join([' '.join(map(str, row)) for row in self.board])
    
    def manhattan_distance(self, goal_state):
        """Tính tổng khoảng cách Manhattan từ trạng thái hiện tại đến đích."""
        distance = 0
        # Tạo từ điển lưu vị trí đích của các số
        goal_positions = {}
        for i in range(3):
            for j in range(3):
                goal_positions[goal_state.board[i][j]] = (i, j)
        
        # Tính tổng khoảng cách Manhattan
        for i in range(3):
            for j in range(3):
                num = self.board[i][j]
                if num != 0:  # Bỏ qua ô trống
                    goal_i, goal_j = goal_positions[num]
                    distance += abs(i - goal_i) + abs(j - goal_j)
        return distance

    def get_flattened(self):
        """Chuyển ma trận thành mảng 1 chiều (bỏ qua số 0 - ô trống)"""
        flattened = []
        for row in self.board:
            for num in row:
                if num != 0:  # Bỏ qua ô trống
                    flattened.append(num)
        return flattened

    def get_flat_index(self, num):
        """Lấy vị trí của một số trong ma trận phẳng (bỏ qua ô trống)"""
        for i in range(3):
            for j in range(3):
                if self.board[i][j] == num:
                    return i * 3 + j
        return -1

    def __lt__(self, other):
        if not isinstance(other, PuzzleState):
            return NotImplemented
        # Sử dụng một heuristic đơn giản để so sánh
        return str(self.board) < str(other.board)



class PuzzleSolver:

    @staticmethod
    def q_learning(initial_state, goal_state, episodes=5000, max_steps=100, alpha=0.1, gamma=0.9, epsilon=0.2):
        """
        Q-learning cho 8-puzzle. Trả về [(move, board), ...] từ initial_state đến goal_state (theo chính sách tốt nhất học được).
        """
        import random
        from collections import defaultdict
        
        # Chuyển board thành tuple để hash
        def board_to_tuple(board):
            return tuple(tuple(row) for row in board)
        
        actions = ['Up', 'Down', 'Left', 'Right']
        Q = defaultdict(lambda: {a: 0.0 for a in actions})
        
        def get_possible_moves(state):
            return state.get_possible_moves()
        
        # Training
        for ep in range(episodes):
            state = PuzzleState([row[:] for row in initial_state.board])
            for step in range(max_steps):
                state_key = board_to_tuple(state.board)
                possible = get_possible_moves(state)
                if not possible:
                    break
                # Chọn action
                if random.random() < epsilon:
                    idx = random.randint(0, len(possible)-1)
                else:
                    # Chọn action có Q lớn nhất
                    qvals = [(Q[state_key][move], i) for i, (b, move) in enumerate(possible)]
                    idx = max(qvals)[1]
                next_board, action = possible[idx]
                next_state = PuzzleState(next_board)
                reward = 1 if next_state.is_goal(goal_state) else -0.1
                next_key = board_to_tuple(next_board)
                # Q update
                Q[state_key][action] += alpha * (reward + gamma * max(Q[next_key].values()) - Q[state_key][action])
                state = next_state
                if next_state.is_goal(goal_state):
                    break
        # Sau huấn luyện, lấy đường đi tốt nhất từ initial_state
        path = []
        state = PuzzleState([row[:] for row in initial_state.board])
        visited = set()
        for _ in range(max_steps):
            if state.is_goal(goal_state):
                break
            state_key = board_to_tuple(state.board)
            possible = get_possible_moves(state)
            if not possible:
                break
            # Chọn action tốt nhất
            qvals = [(Q[state_key][move], i) for i, (b, move) in enumerate(possible)]
            idx = max(qvals)[1]
            next_board, action = possible[idx]
            path.append((action, next_board))
            # Tránh lặp vô hạn
            state_tuple = board_to_tuple(next_board)
            if state_tuple in visited:
                break
            visited.add(state_tuple)
            state = PuzzleState(next_board)
        return path if path else None


    #Nhóm 1 ###############################################################################
    @staticmethod
    def bfs(initial_state, goal_state, max_steps=100000):
        """Tìm kiếm theo chiều rộng.
        
        Args:
            initial_state (PuzzleState): Trạng thái ban đầu
            goal_state (PuzzleState): Trạng thái đích
            max_steps (int, optional): Số bước tối đa. Mặc định là 100000.
            
        Returns:
            list: Danh sách các bước di chuyển nếu tìm thấy, None nếu không tìm thấy
        """
        if not isinstance(initial_state, PuzzleState) or not isinstance(goal_state, PuzzleState):
            raise TypeError("initial_state và goal_state phải là đối tượng PuzzleState")
            
        if initial_state.is_goal(goal_state):
            return []
            
        from collections import deque
        queue = deque([initial_state])
        visited = {initial_state}  # Sử dụng set để tìm kiếm nhanh hơn
        steps = 0
        
        while queue and steps < max_steps:
            steps += 1
            current_state = queue.popleft()
            
            for board, move in current_state.get_possible_moves():
                new_state = PuzzleState(board, current_state, move, 
                                    current_state.cost + 1, 
                                    current_state.depth + 1)
                
                if new_state.is_goal(goal_state):
                    return new_state.get_path()
                    
                if new_state not in visited:
                    visited.add(new_state)
                    queue.append(new_state)
        
        # Nếu vượt quá số bước tối đa
        if steps >= max_steps:
            print(f"Warning: BFS đạt tối đa {max_steps} bước nhưng chưa tìm thấy lời giải")
        return None

    @staticmethod
    def dfs(initial_state, goal_state, max_depth=30):
        if initial_state.is_goal(goal_state):
            return []
            
        stack = [(initial_state, 0)]
        visited = set()
        
        while stack:
            current_state, depth = stack.pop()
            
            if current_state.is_goal(goal_state):
                return current_state.get_path()
                
            if depth >= max_depth:
                continue
                
            if current_state in visited:
                continue
                
            visited.add(current_state)
            
            for board, move in reversed(current_state.get_possible_moves()):
                new_state = PuzzleState(board, current_state, move, current_state.cost + 1, depth + 1)
                stack.append((new_state, depth + 1))
        
        return None

    @staticmethod
    def ucs(initial_state, goal_state):
        if initial_state.is_goal(goal_state):
            return []
            
        import heapq
        from functools import total_ordering
        
        # Sử dụng một lớp wrapper để so sánh các trạng thái dựa trên chi phí
        @total_ordering
        class Node:
            def __init__(self, cost, state):
                self.cost = cost
                self.state = state
                
            def __lt__(self, other):
                return self.cost < other.cost
                
            def __eq__(self, other):
                return self.cost == other.cost
        
        # Hàng đợi ưu tiên
        frontier = []
        heapq.heappush(frontier, Node(0, initial_state))
        
        # Từ điển lưu chi phí tốt nhất đến mỗi trạng thái
        # Sử dụng chuỗi đại diện cho trạng thái làm khóa
        cost_so_far = {str(initial_state.board): 0}
        # Lưu trữ các trạng thái đã mở rộng
        came_from = {str(initial_state.board): None}
        
        while frontier:
            current_node = heapq.heappop(frontier)
            current_state = current_node.state
            current_board_str = str(current_state.board)
            
            # Kiểm tra nếu đã đến đích
            if current_state.is_goal(goal_state):
                # Truy vết lại đường đi
                path = []
                state = current_state
                while state.parent is not None:
                    path.append((state.move, state.board))
                    state = state.parent
                path.reverse()
                return path
            
            # Duyệt qua các trạng thái kế tiếp
            for board, move in current_state.get_possible_moves():
                new_state = PuzzleState(
                    board, 
                    current_state, 
                    move, 
                    current_state.cost + 1, 
                    current_state.depth + 1
                )
                new_cost = current_node.cost + 1  # Chi phí mỗi bước là 1
                new_board_str = str(new_state.board)
                
                # Nếu chưa thăm hoặc tìm được đường đi tốt hơn
                if (new_board_str not in cost_so_far or 
                    new_cost < cost_so_far[new_board_str]):
                    
                    cost_so_far[new_board_str] = new_cost
                    heapq.heappush(frontier, Node(new_cost, new_state))
                    came_from[new_board_str] = current_board_str
        
        return None  # Không tìm thấy đường đi

    @staticmethod
    def _dls(node, goal_state, depth_limit, visited=None):
        if visited is None:
            visited = set()
            
        if node in visited:
            return None
        visited.add(node)
        
        if node.is_goal(goal_state):
            return node.get_path()
            
        if depth_limit <= 0:
            return None
            
        for board, move in node.get_possible_moves():
            new_node = PuzzleState(board, node, move, node.cost + 1, node.depth + 1)
            result = PuzzleSolver._dls(new_node, goal_state, depth_limit - 1, visited)
            if result is not None:
                return result
                    
        return None

    @staticmethod
    def ids(initial_state, goal_state, max_depth=30):
        for depth in range(max_depth + 1):
            visited = set()  # Làm mới visited cho mỗi độ sâu
            result = PuzzleSolver._dls(initial_state, goal_state, depth, visited)
            if result is not None:
                return result
        return None
    


#Nhóm 2 ######################################################################################

    def get_heuristic(self, goal_state, heuristic='manhattan'):
        """Tính giá trị heuristic của trạng thái hiện tại.
        
        Args:
            goal_state: Trạng thái đích
            heuristic: Loại heuristic ('manhattan' hoặc 'misplaced')
            
        Returns:
            Giá trị heuristic
        """
        if heuristic == 'manhattan':
            return self.manhattan_distance(goal_state)
        elif heuristic == 'misplaced':
            return self.misplaced_tiles(goal_state)
        else:
            raise ValueError(f"Unknown heuristic: {heuristic}")
        

    @staticmethod
    def greedy(initial_state, goal_state):
        """Tìm kiếm tham lam (Greedy Best-First Search) sử dụng Manhattan distance."""
        if initial_state.is_goal(goal_state):
            return []
            
        # Hàng đợi ưu tiên dựa trên heuristic
        frontier = []
        # Sử dụng bộ đếm để tránh lỗi so sánh giữa các state
        counter = 0
        heapq.heappush(frontier, (0, counter, initial_state))
        counter += 1
        
        # Từ điển lưu trữ thông tin đường đi
        came_from = {}
        came_from[str(initial_state.board)] = (None, None)  # (parent_board, move)
        
        visited = set()
        
        while frontier:
            _, _, current_state = heapq.heappop(frontier)
            current_board_str = str(current_state.board)
            
            if current_state.is_goal(goal_state):
                # Truy vết lại đường đi qua parent của PuzzleState
                path = []
                state = current_state
                while state.parent is not None:
                    path.append((state.move, state.board))
                    state = state.parent
                path.reverse()
                return path

            if current_board_str in visited:
                continue
                
            visited.add(current_board_str)
            
            for board, move in current_state.get_possible_moves():
                new_state = PuzzleState(
                    board, 
                    current_state, 
                    move, 
                    current_state.cost + 1, 
                    current_state.depth + 1
                )
                new_board_str = str(board)
                
                if new_board_str not in visited:
                    # Sử dụng Manhattan distance làm heuristic
                    h = new_state.manhattan_distance(goal_state)
                    heapq.heappush(frontier, (h, counter, new_state))
                    counter += 1
                    if new_board_str not in came_from:
                        came_from[new_board_str] = (current_board_str, move)
        
        return None  # Không tìm thấy đường đi
    
    @staticmethod
    def a_star(initial_state, goal_state):
        """Thuật toán A* sử dụng Manhattan distance."""
        if initial_state.is_goal(goal_state):
            return []
            
        # Hàng đợi ưu tiên: (f_score, counter, state)
        frontier = []
        counter = 0
        heapq.heappush(frontier, (0, counter, initial_state))
        counter += 1
        
        # Từ điển lưu trữ g(n) - chi phí từ start đến n
        g_scores = {str(initial_state.board): 0}
        # Từ điển lưu trữ f(n) = g(n) + h(n)
        f_scores = {str(initial_state.board): initial_state.manhattan_distance(goal_state)}
        
        # Từ điển lưu trữ thông tin đường đi
        came_from = {str(initial_state.board): (None, None)}  # (parent_board, move)
        
        while frontier:
            _, _, current_state = heapq.heappop(frontier)
            current_board_str = str(current_state.board)
            
            if current_state.is_goal(goal_state):
                # Truy vết lại đường đi qua parent của PuzzleState
                path = []
                state = current_state
                while state.parent is not None:
                    path.append((state.move, state.board))
                    state = state.parent
                path.reverse()
                return path

            for board, move in current_state.get_possible_moves():
                new_state = PuzzleState(
                    board, 
                    current_state, 
                    move, 
                    current_state.cost + 1, 
                    current_state.depth + 1
                )
                new_board_str = str(board)
                
                # Chi phí từ start đến new_state qua current_state
                tentative_g_score = g_scores[current_board_str] + 1
                
                if (new_board_str not in g_scores or 
                    tentative_g_score < g_scores[new_board_str]):
                    
                    # Cập nhật đường đi
                    came_from[new_board_str] = (current_board_str, move)
                    g_scores[new_board_str] = tentative_g_score
                    h = new_state.manhattan_distance(goal_state)
                    f_scores[new_board_str] = tentative_g_score + h
                    
                    # Thêm vào hàng đợi ưu tiên
                    heapq.heappush(frontier, (f_scores[new_board_str], counter, new_state))
                    counter += 1
        
        return None  # Không tìm thấy đường đi
    
    @staticmethod
    def ida_star(initial_state, goal_state, max_depth=100):
        """Thuật toán IDA* (Iterative Deepening A*) sử dụng Manhattan distance."""
        def search(path, g, bound, visited):
            current_state = path[-1]
            h = current_state.manhattan_distance(goal_state)
            f = g + h
            
            if f > bound:
                return f
            if current_state.is_goal(goal_state):
                return 'FOUND'
                
            min_f = float('inf')
            
            for board, move in current_state.get_possible_moves():
                new_state = PuzzleState(
                    board, 
                    current_state, 
                    move, 
                    g + 1, 
                    len(path)
                )
                
                board_str = str(new_state.board)
                if board_str not in visited:
                    visited.add(board_str)
                    path.append(new_state)
                    result = search(path, g + 1, bound, visited)
                    
                    if result == 'FOUND':
                        return 'FOUND'
                    if result < min_f:
                        min_f = result
                        
                    path.pop()
                    visited.remove(board_str)
            
            return min_f
        
        # Bắt đầu với giới hạn ban đầu là heuristic của trạng thái ban đầu
        bound = initial_state.manhattan_distance(goal_state)
        path = [initial_state]
        visited = {str(initial_state.board)}
        
        while True:
            result = search(path, 0, bound, visited)
            
            if result == 'FOUND':
                # Truy vết lại đường đi
                solution = []
                for i in range(1, len(path)):
                    solution.append((path[i].move, path[i].board))
                return solution
                
            if result == float('inf'):
                return None  # Không tìm thấy đường đi
                
            bound = result  # Tăng giới hạn cho lần lặp tiếp theo
            path = [initial_state]
            visited = {str(initial_state.board)}
            
            # Kiểm tra giới hạn độ sâu
            if bound > max_depth:
                return None


#Nhóm 3 ######################################################################################


    @staticmethod
    def simple_hill_climbing(initial_state, goal_state, max_restarts=10, max_steps=1000):
        """Leo đồi đơn giản với khởi tạo lại ngẫu nhiên"""
        best_path = None
        best_h = float('inf')
        
        for _ in range(max_restarts):
            current_state = initial_state
            current_h = current_state.manhattan_distance(goal_state)
            path = []
            visited = set()
            
            for _ in range(max_steps):
                if current_state.is_goal(goal_state):
                    return path
                    
                # Thêm trạng thái hiện tại vào đã thăm
                state_key = str(current_state.board)
                visited.add(state_key)
                
                # Tạo danh sách các trạng thái kế tiếp chưa thăm
                neighbors = []
                for board, move in current_state.get_possible_moves():
                    neighbor = PuzzleState(board, current_state, move, 0, 0)
                    neighbor_key = str(board)
                    if neighbor_key not in visited:
                        h = neighbor.manhattan_distance(goal_state)
                        neighbors.append((h, move, neighbor))
                
                if not neighbors:
                    break  # Không còn lựa chọn nào
                    
                # Chọn trạng thái tốt nhất
                neighbors.sort()
                h, move, neighbor = neighbors[0]
                
                if h >= current_h:
                    break  # Đạt đến đỉnh đồi
                    
                path.append((move, neighbor.board))
                current_state = neighbor
                current_h = h
            
            # Cập nhật lời giải tốt nhất
            if current_state.is_goal(goal_state):
                return path
            if current_h < best_h:
                best_h = current_h
                best_path = path.copy()
                
            # Khởi tạo lại ngẫu nhiên
            initial_state = PuzzleSolver._generate_random_solvable_state(goal_state)
        
        return best_path if best_path else None
    

    @staticmethod
    def steepest_ascent_hill_climbing(initial_state, goal_state, max_restarts=5, max_steps=1000):
        """Leo đồi dốc đứng với khởi tạo lại"""
        best_path = None
        best_h = float('inf')
        
        for _ in range(max_restarts):
            current_state = initial_state
            current_h = current_state.manhattan_distance(goal_state)
            path = []
            visited = set()
            
            for _ in range(max_steps):
                state_key = str(current_state.board)
                if state_key in visited:
                    break
                visited.add(state_key)
                
                if current_state.is_goal(goal_state):
                    return path
                    
                # Tìm láng giềng tốt nhất
                best_move = None
                best_neighbor = None
                best_neighbor_h = current_h
                
                for board, move in current_state.get_possible_moves():
                    neighbor = PuzzleState(board, current_state, move, 0, 0)
                    h = neighbor.manhattan_distance(goal_state)
                    if h < best_neighbor_h:
                        best_neighbor_h = h
                        best_move = move
                        best_neighbor = neighbor
                
                # Nếu không có láng giềng nào tốt hơn, dừng
                if best_neighbor is None:
                    break
                    
                # Di chuyển đến láng giềng tốt nhất
                path.append((best_move, best_neighbor.board))
                current_state = best_neighbor
                current_h = best_neighbor_h
            
            # Cập nhật lời giải tốt nhất
            if current_h < best_h:
                best_h = current_h
                best_path = path.copy()
                
            # Nếu đã tìm thấy lời giải, trả về ngay
            if best_h == 0:
                return best_path
                
            # Khởi tạo lại từ một trạng thái ngẫu nhiên
            initial_state = PuzzleSolver._generate_random_solvable_state(goal_state)
        
        return best_path

    @staticmethod
    def stochastic_hill_climbing(initial_state, goal_state, max_restarts=10, max_steps=1000):
        """Leo đồi ngẫu nhiên với khởi tạo lại"""
        best_path = None
        best_h = float('inf')
        
        for restart in range(max_restarts):
            current_state = initial_state
            current_h = current_state.manhattan_distance(goal_state)
            path = []
            visited = set()
            
            for _ in range(max_steps):
                state_key = str(current_state.board)
                if state_key in visited:
                    break
                visited.add(state_key)
                
                if current_state.is_goal(goal_state):
                    return path
                    
                # Tìm tất cả láng giềng tốt hơn
                better_neighbors = []
                for board, move in current_state.get_possible_moves():
                    neighbor = PuzzleState(board, current_state, move, 0, 0)
                    h = neighbor.manhattan_distance(goal_state)
                    if h < current_h:
                        better_neighbors.append((h, move, neighbor))
                
                if not better_neighbors:
                    break  # Không còn láng giềng nào tốt hơn
                    
                # Chọn ngẫu nhiên một trong các láng giềng tốt hơn
                h, move, neighbor = random.choice(better_neighbors)
                path.append((move, neighbor.board))
                current_state = neighbor
                current_h = h
            
            # Cập nhật lời giải tốt nhất
            if current_h < best_h:
                best_h = current_h
                best_path = path.copy()
                
            # Nếu đã tìm thấy lời giải, trả về ngay
            if best_h == 0:
                return best_path
                
            # Khởi tạo lại từ một trạng thái ngẫu nhiên
            initial_state = PuzzleSolver._generate_random_solvable_state(goal_state)
        
        return best_path
    

    @staticmethod
    def simulated_annealing(initial_state, goal_state, max_steps=10000, initial_temp=1000, cooling_rate=0.99):
        """Thuật toán ủ mô phỏng cải tiến"""
        current = initial_state
        current_energy = current.manhattan_distance(goal_state)
        path = []
        temp = initial_temp
        best_state = current
        best_energy = current_energy
        best_path = []
        
        for step in range(max_steps):
            if current.is_goal(goal_state):
                return path
                
            # Lấy ngẫu nhiên một trạng thái kế tiếp
            possible_moves = current.get_possible_moves()
            if not possible_moves:
                break
                
            board, move = random.choice(possible_moves)
            neighbor = PuzzleState(board, current, move, 0, 0)
            neighbor_energy = neighbor.manhattan_distance(goal_state)
            
            # Tính xác suất chấp nhận
            delta_energy = neighbor_energy - current_energy
            if delta_energy < 0 or random.random() < math.exp(-delta_energy / (temp + 1e-10)):
                path.append((move, neighbor.board))
                current = neighbor
                current_energy = neighbor_energy
                
                # Cập nhật trạng thái tốt nhất
                if current_energy < best_energy:
                    best_energy = current_energy
                    best_state = current
                    best_path = path.copy()
            
            # Hạ nhiệt độ
            temp *= cooling_rate
            
            # Nhiệt độ quá thấp, dừng sớm
            if temp < 0.1:
                break
        
        # Kiểm tra xem có tìm thấy lời giải không
        if current.is_goal(goal_state):
            return path
            
        # Nếu không tìm thấy lời giải, thử lại với trạng thái tốt nhất
        if best_energy < float('inf'):
            # Tạo lại đường đi đến trạng thái tốt nhất
            state = best_state
            best_path_reversed = []
            while state.parent is not None:
                best_path_reversed.append((state.move, state.board))
                state = state.parent
            return best_path_reversed[::-1]
        
        return None
    

    @staticmethod
    def genetic_algorithm(initial_state, goal_state, population_size=100, generations=50, mutation_rate=0.1):
        """Thuật toán di truyền cải tiến cho 8-puzzle"""
        # Tạo danh sách các số cần sắp xếp (bỏ qua số 0)
        target_numbers = [num for row in goal_state.board for num in row if num != 0]
        
        def create_individual():
            """Tạo một cá thể bằng cách hoán vị ngẫu nhiên các số"""
            numbers = target_numbers.copy()
            random.shuffle(numbers)
            return numbers
        
        def evaluate(individual):
            """Đánh giá độ phù hợp của cá thể"""
            # Tạo bảng từ cá thể
            board = [[0]*3 for _ in range(3)]
            idx = 0
            for i in range(3):
                for j in range(3):
                    if goal_state.board[i][j] != 0:  # Bỏ qua ô trống
                        board[i][j] = individual[idx]
                        idx += 1
                    else:
                        board[i][j] = 0
            
            # Tạo trạng thái và tính heuristic
            state = PuzzleState(board, None, "", 0, 0)
            return state.manhattan_distance(goal_state)
        
        # Khởi tạo quần thể
        population = [create_individual() for _ in range(population_size)]
        
        best_individual = None
        best_fitness = float('inf')
        best_solution = None
        
        for generation in range(generations):
            # Đánh giá quần thể
            fitness_scores = [evaluate(ind) for ind in population]
            
            # Tìm cá thể tốt nhất
            min_fitness = min(fitness_scores)
            if min_fitness < best_fitness:
                best_fitness = min_fitness
                best_idx = fitness_scores.index(min_fitness)
                best_individual = population[best_idx]
                
                # Nếu tìm thấy lời giải
                if best_fitness == 0:
                    break
            
            # Tạo quần thể mới
            new_population = []
            
            # Giữ lại một số cá thể tốt nhất (elitism)
            elite_size = max(1, int(population_size * 0.1))
            elite_indices = sorted(range(len(fitness_scores)), key=lambda i: fitness_scores[i])[:elite_size]
            new_population.extend([population[i] for i in elite_indices])
            
            # Tạo các cá thể mới bằng lai ghép và đột biến
            while len(new_population) < population_size:
                # Chọn bố mẹ bằng cách lấy mẫu theo độ phù hợp
                weights = [1.0 / (f + 1) for f in fitness_scores]  # Tránh chia cho 0
                parent1, parent2 = random.choices(population, weights=weights, k=2)
                
                # Lai ghép (order crossover)
                if random.random() < 0.8:  # Tỷ lệ lai ghép
                    size = len(parent1)
                    start, end = sorted(random.sample(range(size), 2))
                    child = [None] * size
                    
                    # Sao chép đoạn giữa từ parent1
                    child[start:end] = parent1[start:end]
                    
                    # Điền các số còn lại từ parent2
                    ptr = 0
                    for i in range(size):
                        if child[i] is None:
                            while parent2[ptr] in child:
                                ptr += 1
                            child[i] = parent2[ptr]
                            ptr += 1
                else:
                    child = parent1.copy()
                
                # Đột biến (hoán đổi 2 gen)
                if random.random() < mutation_rate:
                    idx1, idx2 = random.sample(range(len(child)), 2)
                    child[idx1], child[idx2] = child[idx2], child[idx1]
                
                new_population.append(child)
            
            population = new_population
        
        # Tạo lời giải từ cá thể tốt nhất
        if best_individual is not None:
            # Tạo bảng từ cá thể
            board = [[0]*3 for _ in range(3)]
            idx = 0
            for i in range(3):
                for j in range(3):
                    if goal_state.board[i][j] != 0:  # Bỏ qua ô trống
                        board[i][j] = best_individual[idx]
                        idx += 1
                    else:
                        board[i][j] = 0
            
            # Sử dụng A* để tìm đường đi từ trạng thái ban đầu đến trạng thái tốt nhất
            target_state = PuzzleState(board, None, "", 0, 0)
            return PuzzleSolver.a_star(initial_state, target_state)
        
        return None
    

    @staticmethod  
    def _generate_random_solvable_state(goal_state, steps=30):
        """Tạo một trạng thái ngẫu nhiên có thể giải được"""
        current = goal_state
        for _ in range(steps):
            possible_moves = current.get_possible_moves()
            if not possible_moves:
                break
            board, move = random.choice(possible_moves)
            current = PuzzleState(board, current, move, 0, 0)
        return current

    @staticmethod
    def beam_search(initial_state, goal_state, beam_width=100, max_steps=1000):
        """Tìm kiếm chùm tia cải tiến với beam width lớn hơn"""
        # Hàng đợi ưu tiên cho beam search
        # Lưu trữ (f_score, state, path) và sử dụng f_score để so sánh
        current_beam = [(0 + initial_state.manhattan_distance(goal_state), 0, initial_state, [])]
        visited = set()
        
        for step in range(max_steps):
            next_beam = []
            
            for f_score, g_score, state, path in current_beam:
                state_key = str(state.board)
                if state_key in visited:
                    continue
                visited.add(state_key)
                
                if state.is_goal(goal_state):
                    return path
                    
                # Tạo các trạng thái kế tiếp
                for board, move in state.get_possible_moves():
                    new_state = PuzzleState(board, state, move, 0, 0)
                    new_h = new_state.manhattan_distance(goal_state)
                    new_g = g_score + 1  # Chi phí thực tế
                    new_f = new_g + new_h  # f(n) = g(n) + h(n)
                    new_path = path + [(move, [row[:] for row in board])]  # Tạo bản sao của board
                    
                    next_beam.append((new_f, new_g, new_state, new_path))
            
            if not next_beam:
                break
                
            # Sắp xếp dựa trên f_score (phần tử đầu tiên của tuple)
            next_beam.sort()
            # Giới hạn kích thước beam
            current_beam = next_beam[:beam_width]
        
        # Nếu không tìm thấy lời giải, thử với beam width lớn hơn
        if beam_width < 500:  # Giới hạn beam width tối đa
            return PuzzleSolver.beam_search(initial_state, goal_state, beam_width * 2, max_steps)
            
        # Nếu vẫn không tìm thấy, trả về đường đi tốt nhất đã tìm thấy
        if current_beam:
            return current_beam[0][3]  # Trả về path của phần tử tốt nhất
            
        return None
    

    @staticmethod
    def solve(initial_state, goal_state, method='bfs', **kwargs):
        method = method.lower()
        if method == 'bfs':
            return PuzzleSolver.bfs(initial_state, goal_state, **kwargs)
        elif method == 'dfs':
            return PuzzleSolver.dfs(initial_state, goal_state, **kwargs)
        elif method == 'ucs':
            return PuzzleSolver.ucs(initial_state, goal_state, **kwargs)
        elif method == 'ids':
            return PuzzleSolver.ids(initial_state, goal_state, **kwargs)
        elif method == 'greedy':
            return PuzzleSolver.greedy(initial_state, goal_state, **kwargs)
        elif method == 'a_star':
            return PuzzleSolver.a_star(initial_state, goal_state, **kwargs)
        elif method == 'ida_star':
            return PuzzleSolver.ida_star(initial_state, goal_state, **kwargs)
        
        elif method == 'hill_climb' or method == 'simple_hill_climb':
            return PuzzleSolver.simple_hill_climbing(initial_state, goal_state, **kwargs)
        elif method == 'stochastic_hill_climb':
            return PuzzleSolver.stochastic_hill_climbing(
                initial_state, 
                goal_state,
                kwargs.get('max_restarts', 10),
                kwargs.get('max_steps', 1000)
            )
        elif method == 'steepest_hill_climb':
            return PuzzleSolver.steepest_ascent_hill_climbing(
                initial_state,
                goal_state,
                kwargs.get('max_restarts', 5),
                kwargs.get('max_steps', 1000)
            )
        elif method == 'simulated_annealing':
            return PuzzleSolver.simulated_annealing(initial_state, goal_state, **kwargs)
        elif method == 'genetic' or method == 'genetic_algorithm':
            return PuzzleSolver.genetic_algorithm(initial_state, goal_state, **kwargs)
        elif method == 'beam_search':
            return PuzzleSolver.beam_search(
                initial_state,
                goal_state,
                kwargs.get('beam_width', 100),
                kwargs.get('max_steps', 1000)
            )
        else:
            raise ValueError(f"Unknown method: {method}")
       

    @staticmethod
    def and_or_search(initial_state, goal_state, max_depth=20, max_memory=1000000):
        """Cải tiến AND-OR search với giới hạn bộ nhớ và heuristic tốt hơn"""
        memory_usage = 0
        memo = {}
        
        def get_state_key(state):
            return tuple(tuple(row) for row in state.board)
        
        def search(state, depth, path=None):
            nonlocal memory_usage
            
            # Kiểm tra bộ nhớ
            memory_usage += 1
            if memory_usage > max_memory:
                raise MemoryError("Vượt quá giới hạn bộ nhớ")
                
            # Kiểm tra đích
            if state.is_goal(goal_state):
                return []
                
            # Kiểm tra độ sâu
            if depth <= 0:
                return None
                
            # Kiểm tra bảng ghi nhớ
            state_key = get_state_key(state)
            if state_key in memo:
                return memo[state_key]
                
            # Lấy các nước đi có thể và sắp xếp theo heuristic
            possible_moves = []
            for board, move in state.get_possible_moves():
                new_state = PuzzleState(board, state, move, state.depth + 1, 0)
                # Sử dụng Manhattan distance làm heuristic
                score = new_state.manhattan_distance(goal_state)
                possible_moves.append((score, move, new_state))
            
            # Sắp xếp theo heuristic tốt nhất
            possible_moves.sort()
            
            # Thử từng nước đi
            for score, move, new_state in possible_moves:
                result = search(new_state, depth - 1, path + [move] if path else [move])
                if result is not None:
                    # Lưu kết quả vào bảng ghi nhớ
                    solution = [move] + result
                    memo[state_key] = solution
                    return solution
                    
            memo[state_key] = None
            return None
        
        # Thực hiện tìm kiếm với độ sâu tăng dần
        try:
            for depth in range(1, max_depth + 1, 2):  # Tăng độ sâu từ từ
                result = search(initial_state, depth, [])
                if result is not None:
                    return result
        except MemoryError:
            print("Cảnh báo: Đạt đến giới hạn bộ nhớ")
        
        print("Không tìm thấy lời giải trong giới hạn đã cho")
        return None

    
    @staticmethod
    def advanced_search(initial_state, goal_state, method='and_or', **kwargs):
        """Giao diện thống nhất cho các thuật toán nhóm 4"""
        method = method.lower()
        
        if method == 'and_or':
            max_depth = kwargs.get('max_depth', 30)
            return PuzzleSolver.and_or_search(initial_state, goal_state, max_depth=max_depth)
        
        elif method == 'partial_observation':
            max_steps = kwargs.get('max_steps', 1000)
            pop = PartiallyObservablePuzzle(initial_state)
            return PuzzleSolver._solve_with_partial_observation(pop, goal_state, max_steps=max_steps)
        
        elif method == 'dynamic_env':
            max_steps = kwargs.get('max_steps', 1000)
            change_probability = kwargs.get('change_probability', 0.1)
            env = DynamicPuzzleEnvironment(initial_state, change_probability=change_probability)
            return PuzzleSolver._solve_in_dynamic_environment(env, goal_state, max_steps=max_steps)
        
        else:
            raise ValueError(f"Unknown advanced method: {method}")

    @staticmethod
    def _solve_with_partial_observation(pop, goal_state, max_steps=1000):
        """Giải quyết bài toán với thông tin một phần"""
        path = []
        
        for _ in range(max_steps):
            # Kiểm tra nếu tất cả các trạng thái trong belief đều là goal
            if all(state.is_goal(goal_state) for state in pop.belief_states):
                return path
            
            # Chọn trạng thái có heuristic tốt nhất trong tập belief
            best_state = min(
                pop.belief_states, 
                key=lambda s: s.manhattan_distance(goal_state)
            )
            
            # Sử dụng A* để tìm đường đi từ trạng thái tốt nhất
            solution = PuzzleSolver.a_star(best_state, goal_state)
            
            if solution:
                # Thực hiện các bước di chuyển
                for move, _ in solution:
                    pop.update_belief(move)
                    path.append((move, None))  # Không lưu board vì không chắc chắn
                    
                    # Kiểm tra xem đã đích chưa
                    if all(s.is_goal(goal_state) for s in pop.belief_states):
                        return path
            else:
                # Nếu không tìm thấy đường đi, làm mới belief states
                pop.belief_states = {PuzzleState(s.board, None, "", 0, 0) for s in pop.belief_states}
        
        return path

    @staticmethod
    def _solve_in_dynamic_environment(env, goal_state, max_steps=1000, **kwargs):
        """Giải quyết bài toán trong môi trường động"""
        current_state = env.initial_state
        path = []
        change_probability = kwargs.get('change_probability', 0.1)
        
        # Hàm kiểm tra tính hợp lệ của bảng
        def is_valid_board(board):
            try:
                if len(board) != 3 or any(len(row) != 3 for row in board):
                    return False
                numbers = [num for row in board for num in row]
                return sorted(numbers) == list(range(9))
            except:
                return False
        
        for step in range(max_steps):
            # Kiểm tra nếu đã đến đích
            if current_state.is_goal(goal_state):
                return path
                
            # Lấy các nước đi có thể
            moves = []
            for board, move in current_state.get_possible_moves():
                if is_valid_board(board):  # Chỉ thêm nếu board hợp lệ
                    moves.append((board, move))
            
            if not moves:
                break
                
            # Chọn nước đi tốt nhất
            best_move = None
            best_score = float('inf')
            best_board = None
            
            for board, move in moves:
                if not is_valid_board(board):
                    continue
                    
                # Tạo trạng thái mới
                new_state = PuzzleState(board, current_state, move, 0, 0)
                score = new_state.manhattan_distance(goal_state)
                
                if score < best_score:
                    best_score = score
                    best_move = move
                    best_board = board
            
            # Nếu không tìm được nước đi tốt, chọn ngẫu nhiên
            if best_move is None and moves:
                best_board, best_move = random.choice(moves)
            
            if best_move is not None and best_board is not None:
                # Lưu lại trạng thái hiện tại
                path.append((best_move, [row[:] for row in best_board]))
                
                # Áp dụng nước đi
                current_state = PuzzleState(best_board, current_state, best_move, 0, 0)
                
                # Thay đổi ngẫu nhiên môi trường
                if random.random() < change_probability:
                    try:
                        # Tìm tất cả cặp ô có thể đổi chỗ
                        possible_swaps = []
                        for i in range(3):
                            for j in range(3):
                                if best_board[i][j] != 0:  # Không đổi chỗ ô trống
                                    for di, dj in [(0,1), (1,0)]:
                                        ni, nj = i + di, j + dj
                                        if (0 <= ni < 3 and 0 <= nj < 3 and 
                                            best_board[ni][nj] != 0):  # Không đổi chỗ với ô trống
                                            possible_swaps.append(((i,j), (ni,nj)))
                        
                        if possible_swaps:
                            (i,j), (ni,nj) = random.choice(possible_swaps)
                            # Tạo bảng mới với hai ô đổi chỗ
                            new_board = [row[:] for row in best_board]
                            new_board[i][j], new_board[ni][nj] = new_board[ni][nj], new_board[i][j]
                            
                            if is_valid_board(new_board):
                                # Tạo trạng thái mới sau khi thay đổi môi trường
                                current_state = PuzzleState(new_board, current_state, "env_change", 0, 0)
                                path.append(("env_change", [row[:] for row in new_board]))
                                
                    except Exception as e:
                        print(f"Lỗi khi thay đổi môi trường: {e}")
        
        return path

    @staticmethod
    def solve_with_csp(initial_state, goal_state, method='backtracking'):
        """
        Giải bài toán bằng các thuật toán CSP
        Args:
            initial_state: Trạng thái ban đầu (PuzzleState)
            goal_state: Trạng thái đích (PuzzleState)
            method: Phương pháp giải ('backtracking', 'forward_checking', 'ac3')
        Returns:
            Danh sách các bước di chuyển (list) hoặc None nếu không tìm thấy lời giải
        """
        try:
            class CSPSolver:
                def __init__(self, initial_state, goal_state):
                    self.initial_state = initial_state
                    self.goal_state = goal_state
                    self.N = 3
                    self.variables = [(i, j) for i in range(self.N) for j in range(self.N)]
                    self.domains = {var: list(range(self.N*self.N)) for var in self.variables}
                    self.goal_positions = {}
                    for i in range(self.N):
                        for j in range(self.N):
                            self.goal_positions[goal_state.board[i][j]] = (i, j)
                def is_consistent(self, var, value, assignment):
                    for v in assignment:
                        if assignment[v] == value:
                            return False
                    return True
                def select_unassigned_variable(self, assignment):
                    for var in self.variables:
                        if var not in assignment:
                            return var
                    return None
                def solve_backtracking(self):
                    def backtrack(assignment):
                        if len(assignment) == len(self.variables):
                            # Chỉ nhận assignment nếu đúng goal_state
                            for (i, j), value in assignment.items():
                                if value != self.goal_state.board[i][j]:
                                    return None
                            return assignment
                        var = self.select_unassigned_variable(assignment)
                        for value in self.domains[var]:
                            if self.is_consistent(var, value, assignment):
                                assignment[var] = value
                                result = backtrack(assignment)
                                if result:
                                    return result
                                del assignment[var]
                        return None
                    return backtrack({})
                def solve_forward_checking(self):
                    def forward_check(assignment, domains):
                        if len(assignment) == len(self.variables):
                            # Chỉ nhận assignment nếu đúng goal_state
                            for (i, j), value in assignment.items():
                                if value != self.goal_state.board[i][j]:
                                    return None
                            return assignment
                        var = self.select_unassigned_variable(assignment)
                        for value in domains[var]:
                            if self.is_consistent(var, value, assignment):
                                assignment[var] = value
                                local_domains = copy.deepcopy(domains)
                                for v in self.variables:
                                    if v != var and value in local_domains[v]:
                                        local_domains[v].remove(value)
                                result = forward_check(assignment, local_domains)
                                if result:
                                    return result
                                del assignment[var]
                        return None
                    return forward_check({}, copy.deepcopy(self.domains))
                def solve_ac3(self):
                    queue = [(xi, xj) for xi in self.variables for xj in self.variables if xi != xj]
                    domains = copy.deepcopy(self.domains)
                    def revise(xi, xj):
                        revised = False
                        for x in domains[xi][:]:
                            if not any(x != y for y in domains[xj]):
                                domains[xi].remove(x)
                                revised = True
                        return revised
                    while queue:
                        xi, xj = queue.pop(0)
                        if revise(xi, xj):
                            if not domains[xi]:
                                return None
                            for xk in self.variables:
                                if xk != xi and xk != xj:
                                    queue.append((xk, xi))
                    def backtrack(assignment):
                        if len(assignment) == len(self.variables):
                            # Chỉ nhận assignment nếu đúng goal_state
                            for (i, j), value in assignment.items():
                                if value != self.goal_state.board[i][j]:
                                    return None
                            return assignment
                        var = self.select_unassigned_variable(assignment)
                        for value in domains[var]:
                            if self.is_consistent(var, value, assignment):
                                assignment[var] = value
                                result = backtrack(assignment)
                                if result:
                                    return result
                                del assignment[var]
                        return None
                    return backtrack({})
            csp_solver = CSPSolver(initial_state, goal_state)
            if method == 'backtracking':
                assignment = csp_solver.solve_backtracking()
            elif method == 'forward_checking':
                assignment = csp_solver.solve_forward_checking()
            elif method == 'ac3':
                assignment = csp_solver.solve_ac3()
            else:
                raise ValueError('Unknown CSP method')
            if assignment:
                # Tạo trạng thái đích từ assignment
                board = [[0 for _ in range(3)] for _ in range(3)]
                for (i, j), value in assignment.items():
                    board[i][j] = value
                target_state = PuzzleState(board)
                # Nếu trạng thái đích không hợp lệ hoặc không giải được thì trả về None
                if not target_state._is_valid_board(board):
                    return None
                # Tìm đường đi thật sự từ initial_state đến target_state bằng A*
                path = PuzzleSolver.a_star(initial_state, target_state)
                return path

            return None
        except Exception as e:
            print(f'Lỗi trong solve_with_csp: {e}')
            return None

class PartiallyObservablePuzzle:
    def __init__(self, initial_state):
        """Khởi tạo môi trường chỉ nhìn thấy một phần"""
        self.initial_state = initial_state
        self.belief_states = {initial_state}  # Tập các trạng thái có thể
        self.observed_positions = set()      # Các vị trí đã quan sát
        self.observation_history = []        # Lịch sử quan sát
        self.current_state = initial_state   # Trạng thái hiện tại
        self._update_observed_positions()    # Cập nhật các vị trí quan sát được
    
    def _update_observed_positions(self):
        """Cập nhật tập các vị trí đã quan sát được"""
        self.observed_positions = set()
        
        # Với mỗi trạng thái trong belief_states
        for state in self.belief_states:
            # Tìm vị trí ô trống
            blank_pos = state.find_blank()
            if blank_pos:
                i, j = blank_pos
                # Thêm ô trống và các ô xung quanh vào tập quan sát
                for di in [-1, 0, 1]:
                    for dj in [-1, 0, 1]:
                        ni, nj = i + di, j + dj
                        if 0 <= ni < 3 and 0 <= nj < 3:
                            self.observed_positions.add((ni, nj))
    
    def update_belief(self, move):
        """Cập nhật belief states và trả về True nếu thành công"""
        new_beliefs = set()
        move_applied = False
        
        for state in self.belief_states:
            for new_board, m in state.get_possible_moves():
                if m == move:
                    new_state = PuzzleState(
                        new_board, 
                        state, 
                        m, 
                        state.depth + 1, 
                        0
                    )
                    new_beliefs.add(new_state)
                    move_applied = True
        
        if move_applied:
            self.belief_states = new_beliefs
            # Cập nhật current_state (chọn state đầu tiên trong tập belief_states)
            self.current_state = next(iter(self.belief_states)) if self.belief_states else None
            self._update_observed_positions()
            return True
        return False
    
    # Thêm alias để tương thích với code cũ
    apply_move = update_belief
    
    def get_observed_board(self, state):
        """Trả về bảng đã được quan sát, với các ô chưa quan sát được thay bằng None"""
        observed_board = [[None for _ in range(3)] for _ in range(3)]
        
        # Điền giá trị cho các ô đã quan sát được
        for i in range(3):
            for j in range(3):
                if (i, j) in self.observed_positions:
                    observed_board[i][j] = state.board[i][j]
        
        return observed_board
    

class DynamicPuzzleEnvironment:
    def __init__(self, initial_state, change_probability=0.1):
        """Khởi tạo môi trường động"""
        self.initial_state = initial_state
        self.current_state = initial_state
        self.change_probability = change_probability
        self.change_history = []
    
    def get_possible_moves(self, state=None):
        """Lấy các nước đi có thể, có thêm nhiễu ngẫu nhiên"""
        if state is None:
            state = self.current_state
            
        moves = state.get_possible_moves()
        
        # Thêm nhiễu vào các nước đi với xác suất nhất định
        if random.random() < self.change_probability:
            # Tìm các cặp ô có thể đổi chỗ
            swappable = []
            for i in range(3):
                for j in range(3):
                    if state.board[i][j] != 0:  # Không đổi chỗ ô trống
                        # Kiểm tra các ô lân cận
                        for di, dj in [(0,1), (1,0), (0,-1), (-1,0)]:
                            ni, nj = i + di, j + dj
                            if 0 <= ni < 3 and 0 <= nj < 3 and state.board[ni][nj] != 0:
                                swappable.append(((i,j), (ni,nj)))
            
            if swappable:
                # Chọn ngẫu nhiên một cặp để đổi chỗ
                (i,j), (k,l) = random.choice(swappable)
                new_board = [row[:] for row in state.board]
                new_board[i][j], new_board[k][l] = new_board[k][l], new_board[i][j]
                moves.append(('random_swap', new_board))
                self.change_history.append((i,j,k,l))
        
        return moves
    
    def apply_move(self, move):
        """Áp dụng một nước đi và trả về trạng thái mới"""
        if move[0] == 'random_swap':
            # Nếu là nhiễu ngẫu nhiên, cập nhật trạng thái hiện tại
            self.current_state = PuzzleState(move[1], self.current_state, "env_change", 0, 0)
        else:
            # Ngược lại, thực hiện nước đi bình thường
            for board, m in self.current_state.get_possible_moves():
                if m == move:
                    self.current_state = PuzzleState(board, self.current_state, m, 0, 0)
                    break
        
        return self.current_state