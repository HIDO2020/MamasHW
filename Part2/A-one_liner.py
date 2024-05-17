def num_len(num, count=1):
    while num / 10 > 0: count, num = count + 1, int(num / 10); return count if int(num / 10) == 0 else num_len(num, count)

print(num_len(345320))