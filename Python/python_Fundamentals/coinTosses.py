import random
def coinFlipper():
    print 'Staring the program...'
    numHeads = 0
    numTails = 0
    for i in range (1, 5001):
        x = int(random.randint(0,1))
        if x > 0:
            print 'Attempt #', i, ": Throwing a coin... It's a head! ... Got ", numHeads, ' head(s) so far and ', numTails, ' tail(s) so far'
            numHeads+=1

        else:
            print 'Attempt #', i, ": Throwing a coin... It's a tail! ... Got ", numHeads, ' head(s) so far and ', numTails, ' tail(s) so far'
            numTails+=1
    print 'Ending the program, thank you!'


coinFlipper()
