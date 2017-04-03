
#
def multiply(a, c):
    b = []
    for i in range(len(a)):
        b.append(a[i] * c)
    return b

def layered_multiples(arr):  # returns arrays of 1s for each multipied value
   new_array = []
   for i in arr:
       i_array = []
       for j in range(i):
           i_array.append(1)
       new_array.append(i_array)
   return new_array


x = layered_multiples(multiply([2, 4, 5], 3))
print x
