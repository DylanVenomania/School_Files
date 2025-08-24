import numpy as np

def max_sellday( arr ):
    arr_soluongban = []
    for day in range(7):
        sum = arr[0, day] + arr[1, day]
        arr_soluongban.append(sum)

    max_sell = np.argmax(arr_soluongban)
    if max_sell == 0:
        return "Thứ hai"
    elif max_sell == 1:
        return "Thứ ba"
    elif max_sell == 2:
        return "Thứ tư"
    elif max_sell == 3:
        return "Thứ năm"
    elif max_sell == 4:
        return "Thứ sáu"
    elif max_sell == 5:
        return "Thứ bảy"
    elif max_sell == 6:
        return "Chủ nhật"

def max_sellmoment(arr):
    max = arr[0][0]
    max_day = 0
    max_moment = 0
    for day in range(7):
        for moment in range(2):
            if arr[moment][day] > max :
                max = arr[moment][day]
                max_day = day
                max_moment = moment
    
    arr_day = ["Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật"]
    arr_moment = ["Buổi sáng", "Buổi chiều"]

    return arr_moment[max_moment], arr_day[ max_day ] 

def compare_2moment(arr ):
    morning_higher = 0
    afternoon_higher = 0
    for day in range(7):
        if arr[0][day] > arr[1][day] :
            morning_higher += 1
        elif arr[0][day] < arr[1][day]:
            afternoon_higher += 1
    if morning_higher - afternoon_higher > 1:
        return "Buổi sáng bán được nhiều hơn ! "
    elif afternoon_higher - morning_higher > 1:
        return "Buổi chiều bán được nhiều hơn !"
    else:
        return "Cả 2 buổi bán được tương đương nhau!"



def main():
    while True:
        print("Nhập khoảng giá trị số lượng có thể đạt được khi bán trong ngày : ")
        a = int(input("Số lượng khởi điểm: "))
        b=  int(input("Số lượng tối đa: ") )
        if b > a and b >= 0 and a >= 0:
            break
        else:
            if b <0 or a < 0 :
                print("Số lượng không được nhỏ hơn 0 !")
            elif a >= b:
                print("Số lượng tối đa cần lớn hơn số lượng khởi điểm !")

    soluongban_arr = np.random.randint(a, b, size = (2, 7))
    print(soluongban_arr)

    print(f"Ngày có số lượng bán nhiều nhất trong tuần là : {max_sellday(soluongban_arr)}")

    max_moment, max_day = max_sellmoment(soluongban_arr)
    print(f"{max_moment}, {max_day} có số lượng bán nhiều nhất ! ")
    
    print( compare_2moment(soluongban_arr) )


if __name__=="__main__":
    main()