from django.shortcuts import render, HttpResponse
from .models import User

# Create your views here.
def index(request):
    User.objects.create(first_name="Ilyaz", last_name="Fayzul")
    user = User.objects.all()
    print (user)
    return render(request, "Wall/index.html")
