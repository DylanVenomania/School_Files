def starSaveEnergy(energy):
    if energy < 10 :
        if energy >= 6 :
            return 2
        elif energy >= 4 and energy < 6 :
            return 3
        elif energy >= 2 and energy < 4 :
            return 4
        elif energy < 2 :
            return 5
    else:
        return 1

def saveEnergy(energy):
    if starSaveEnergy(energy) < 3 :
        print("Thiết bị không tiết kiệm điện !")
    else:
        print("Thiết bị tiết kiệm điện !")

def main():
    energy = float(input("Nhập vào điện năng tiêu thụ mỗi ngày của thiết bị (kWh): "))
    saveEnergy(energy)

if __name__ == "__main__":
    main()