def is_sorted_polyndrom(is_poly: str) -> bool:
    first_num: str = "not init"
    following_num: str = "not init"
    first_str: str = "not init"
    following_str: str = "not init"
    tmp: str

    for i in range(0, int(len(is_poly) / 2)):
        if is_poly[i] != is_poly[len(is_poly) - i - 1]:
            return False

        if is_poly[i].isdigit():
            if first_num == "not init":
                first_num = is_poly[i]
                continue

            elif following_num == "not init":
                following_num = is_poly[i]
                if int(following_num) < int(first_num):
                    return False
                continue

            elif int(following_num) < int(first_num):
                return False

            first_num = following_num
            following_num = is_poly[i]

        else:

            if first_str == "not init":
                first_str = is_poly[i]
                continue

            elif following_str == "not init":
                following_str = is_poly[i]
                if not is_digit_order(first_str, following_str):
                    return False
                continue

            else:
                if not is_digit_order(first_str, following_str):
                    return False

            first_str = following_str
            following_str = is_poly[i]

    return True

def is_digit_order(first_str: str, following_str: str) ->bool:
    dig1: int = ord(first_str)
    dig2: int = ord(following_str)
    if dig1 < 97:
        dig1 += 32
    if dig2 < 97:
        dig2 += 32

    if dig2 < dig2:
        return False

print(is_sorted_polyndrom("C12a34643a21C"))
print(is_sorted_polyndrom("31113"))