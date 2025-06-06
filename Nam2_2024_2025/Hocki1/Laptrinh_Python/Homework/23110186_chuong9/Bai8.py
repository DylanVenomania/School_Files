import numpy as np

def combine_room(room1 , room2):
    final_lst = []

    for r1, r2 in zip(room1, room2):
        if r1 > 0 : 
            final_lst.append(r1)
        elif r2 > 0:
            final_lst.append(r2)
        else:
            final_lst.append(None)

    return final_lst

def input_room(room_name):
    while True:
        try:
            print(f"Nhập danh sách thí sinh cho {room_name} (cách nhau bởi ',' ): ")
            room_input = input().strip()

            room_input = np.array( [int(x) for x in room_input.split(",")] )

            if len(room_input) != 7 :
                raise ValueError("Phòng thi có 7 thí sinh !")
            return room_input
        
        except ValueError :
            print("Lỗi nhập dữ liệu, vui lòng nhập lại !")

room1 = input_room("room1")
room2 = input_room("room2")

ketqua = combine_room(room1, room2)
ketqua = [ int(x) if x is not None else None for x in ketqua]

print(f"\nDanh sách thí sinh cuối cùng : \n{ketqua}")
