def multiply(a, c):
    b = []
    for i in range(len(a)):
        b.append(a[i] * c)
    return b

a = [2,4,10,16]
b = multiply(a, 5)
print b
