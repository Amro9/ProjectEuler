#By listing the first six prime numbers: 2,3,5,7,11, and 13, we can see that the 6th prime is 13.What is the 10001st prime number?

import math

def is_prime(n):
    if n <= 1:
        return False
    if n <= 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False
    i = 5
    while i * i <= n:
        if n % i == 0 or n % (i + 2) == 0:
            return False
        i += 6
    return True

def find_nth_prime(n):
    count = 0
    candidate = 1
    while count < n:
        candidate += 1
        if is_prime(candidate):
            count += 1
    return candidate


prime_10001 = find_nth_prime(10001)
print(prime_10001)
