def saveEnergy(energy):
    if energy < 10000:
        return True
    return False


def main():
    flag = True
    while( flag ):
        print("1. Wh")
        print("2. KWh")
        choice = input("Chọn đơn vị điện năng : ")
        energy = float( input("Nhập vào điện năng tiêu thụ mỗi ngày của thiết bị : ") )

        if choice == '2':
            energy = energy *1000
        if(choice == '1' or choice == '2'):
            flag = False
            if saveEnergy(energy):
                print("Thiết bị tiết kiệm điện!")
            else:
                print("Thiết bị không tiết kiệm điện!")
        else:
            print("Vui lòng nhập lại lựa chọn đơn vị!")
   

if __name__ == "__main__":
    main()