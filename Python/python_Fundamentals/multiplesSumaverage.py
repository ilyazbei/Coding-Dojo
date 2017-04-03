# Multiples: Part 1
for oddNum in range(1, 1000): # this for loop going trouh range of numbers from 1 to 1000
    if oddNum % 2 != 0: #this if statement tells us if the number is odd
        print oddNum # then print all odd numbers


# Multiples: Part 2
for element in range(5, 1000000):
   if element % 5 == 0:
       print element



# Sum list
a = [1, 2, 5, 10, 255, 3]
sum = 0
for val in a:
    sum += val
print(sum)

#Average list
a = [1, 2, 5, 10, 255, 3]
sum = 0
for val in a:
    sum += val
average = sum / len(a)
print(average)
