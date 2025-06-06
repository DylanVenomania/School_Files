import string 

def spell(name):
    new_name = []

    for i in name.split():
        temp_name = i

        if not( temp_name[0].isupper() ):
            temp_name = temp_name[0].upper() + temp_name[1:]

        for j in range(1, len(temp_name)):
            if not( temp_name[j].islower() ):
                temp_name = temp_name[:j] + temp_name[j].lower() + temp_name[ j+1:]

        new_name.append(temp_name)

    return ' '.join(new_name)

def main():
    name = input("Nhập vào tên, không viết liền nhau: ")
    print(name)

    print(spell(name))

if __name__ == "__main__":
    main()

