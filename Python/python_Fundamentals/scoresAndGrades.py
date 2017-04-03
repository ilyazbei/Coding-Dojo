import random
def grades():
    print 'Scores and grades'
    for i in range (10):
        x = int(random.random() * 41 + 60)
        if x < 70:
            print 'Score: '+str(x)+'; Your grade is D'
        elif x < 80:
            print 'Score: '+str(x)+'; Your grade is C'
        elif x <90:
            print 'Score: '+str(x)+'; Your grade is B'
        elif x <101:
            print 'Score: '+str(x)+'; Your grade is A'
    print 'End of the program. Bye!'
    return
grades()
