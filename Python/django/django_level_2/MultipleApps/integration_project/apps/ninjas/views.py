from django.shortcuts import render

# Create your views here.
def index(request):
    return render(request, "ninjas/index.html")

def ninjas(request, colors):
    if colors == "":
        picture = "ninjas/images/ninjas.png"

    elif colors == "blue":
        picture = "ninjas/images/leonardo.jpg"

    elif colors == "orange":
        picture = "ninjas/images/michelangelo.jpg"

    elif colors == "red":
        picture = "ninjas/images/raphael.jpg"

    elif colors == "purple":
        picture = "ninjas/images/donatello.jpg"

    else:
        picture = "ninjas/images/meganFox.jpg"

    context = {
        "picture" : picture
    }

    return render(request, "ninjas/ninjas.html", context)
