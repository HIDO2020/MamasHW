import matplotlib.pyplot as plt
import numpy as np

def main():
    lst: list = []
    string: str = ""
    num: int = 0
    while True:
        string = input("Enter a number (enter -1 to exit): ")

        if string[0] == "-" and string[1: len(string)]:
            num = int(string[1: len(string)]) * -1
            if num == -1:
                break
            lst.append(num)

        elif string.isdigit():
            num = int(string)
            if num != -1:
                lst.append(num)
        else:
            print("Only enter a number!")

    avg: int = 0
    pos_sum: int = 0
    sorted_lst: list = lst
    sorted_lst.sort()

    for x in range(len(lst)):
        avg += lst[x]

        if lst[x] >= 0:
            pos_sum += 1

    print("the average of these numbers is ", avg / len(lst))
    print("the amount of positive numbers yo entered is ", pos_sum)
    print("your numbers from smallest to the biggest: ", *sorted_lst)



if __name__ == '__main__':
    main()


