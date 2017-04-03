from django.shortcuts import render, redirect
from .models import Product


# Create your views here.
def index(request):
    context = {
        "products" : Product.objects.all()
    }
    return render(request, "semiRestfulApp/index.html", context)

def new(request):
    return render(request, "semiRestfulApp/new.html")

def newPost(request):
    if request.method == "POST":
        Product.objects.newPost(request.POST)
    return redirect("semiRestfulApp:index")

def show(request, id):
    context = {
        "product": Product.objects.get(id=id)
    }
    return render(request, "semiRestfulApp/show.html", context)

def edit(request, id):
    context = {
        "product": Product.objects.get(id=id)
    }
    return render(request, "semiRestfulApp/edit.html", context)

def remove(request, id):
    if request.method == "POST":
        Product.objects.remove(id)
    return redirect("semiRestfulApp:index")

def update(request, id):
    if request.method == "POST":
        Product.objects.update(request.POST, id)
    return redirect("semiRestfulApp:index")
