import math

def pythagorean_triplet_by_sum(sum):
    a: int = 0
    b: int = 0
    c: int = 0
    limit: int = int(sum / 2)

    for t in range(1, limit + 1):
        for s in range(t + 1, limit + 1):
            a = s * s - t * t
            b = 2 * s * t
            c = s * s + t * t
            if a + b + c == sum:
                print(a, b, c)

pythagorean_triplet_by_sum(234)