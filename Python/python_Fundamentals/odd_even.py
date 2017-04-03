def oddEven():

    for odd_even in range(1, 2000):
        if odd_even % 2 != 0:
            print 'Number is ' + str(odd_even) + '. This is an odd number.'
        else:
            print 'Number is ' + str(odd_even) + '. This is an even number.'
oddEven()
