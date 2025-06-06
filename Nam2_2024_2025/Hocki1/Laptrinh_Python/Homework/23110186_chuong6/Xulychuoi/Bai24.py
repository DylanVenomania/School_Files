def solan_xuathien(xaukitu):
    xaukitu = xaukitu.lower()

    word_lst = xaukitu.split()
    word_count = {}
    for word in word_lst:
        word = word.strip(" ,.-'\" ")
    
        if word != "":
            if word in word_count:
                word_count[word] += 1  
            else:
                word_count[word] = 1  

    return word_count

def main():
    xaukitu = input("Nhập một xâu kí tự : ")
    count = solan_xuathien(xaukitu)

    print("Số lần xuất hiện của các từ : ")
    for word, count in count.items():
        print(f"Từ '{word}' xuất hiện {count} lần !")

if __name__ == "__main__":
    main()