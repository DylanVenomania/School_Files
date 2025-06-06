import numpy as np

def combine_rooms (room_1, room_2):
    if np.all( room_1 > 0):
        return room_1
    student_lst = np.array([], dtype = int)
    
    for thutu in range( 7 ):
        if room_1[ thutu ] >= 0:
            student_lst = np.append(student_lst, room_1[ thutu ])
        elif room_2[ thutu ] >= 0:
                student_lst = np.append(student_lst, room_2[ thutu ])
        else:
            student_lst = np.append(student_lst, None)
    
    return student_lst


def main():
    print("Nhập 7 giá trị tương ứng trạng thái thi (số dương) hay không thi (số âm) cho 7 thí sinh mỗi phòng : ")
    print("Phòng 1:")
    room_1 = np.array( [], dtype = int)
    for thutu in range(7):
        value = int(input())
        room_1 = np.append( room_1, value )
    
    print("Phòng 2:")
    room_2 = np.array( [], dtype = int )
    for thutu in range(7):
        value = int(input())
        room_2 = np.append( room_2, value )

    result = combine_rooms(room_1, room_2)
    if np.array_equal( result, room_1 ): 
        print("Danh sách chốt thí sinh thi là cả danh sách của phòng 1 ! (Không ai phòng 1 xin thôi thi)")
    else:
        print(f"Danh sách chốt thí sinh thi : {combine_rooms(room_1, room_2)}")
    
    return 0 

if __name__=="__main__":
    main()