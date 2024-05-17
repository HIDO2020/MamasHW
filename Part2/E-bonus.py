import math

def reverse_n_pi_digits(n: int) -> str:
    pi_str: str = str(math.pi)
    pi_str = pi_str[0:n + 1].replace(".", "")[::-1]
    return pi_str

print(reverse_n_pi_digits(8))