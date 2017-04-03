# Part 1:
def draw_stars(x):
    for i in range(0, len(x)):
        new_stars = ""
        for n in range(0, x[i]):
            new_stars += '*'
        print new_stars

draw_stars([4, 6, 1, 3, 5, 7, 25])


# Part 2
def draw_stars(x):
    for i in range(0, len(x)):
        new_stars = ""
        if isinstance(x[i], str):
            for s in range(0,len(x[i])):
                new_stars += x[i][0].lower()
        else:
            for s in range(0,x[i]):
                new_stars += '*'
        print new_stars

draw_stars([4, "Tom", 1, "Michael", 5, 7, "Jimmy Smith"])
