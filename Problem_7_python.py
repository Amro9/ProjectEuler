# 05.02.2024 
#By listing the first six prime numbers: 2,3,5,7,11, and 13, we can see that the 6th prime is 13.What is the 10001st prime number?

import time

allPrimeNums = 0
num = 2
def DeterminePrime(num):
    for i in range(2,num + 1):
        #if i == num : return True
        if num % i == 0 :
            return False
    return True
        

start_time = time.time()

while(allPrimeNums != 10001):
    if DeterminePrime(num): 
        allPrimeNums += 1
    num += 1
end_time = time.time()
execution_time = end_time - start_time
print("Execution time:", execution_time, "seconds")
print(num)

