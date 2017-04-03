from django.shortcuts import render, redirect
from .models import Course, Post
import datetime

# Create your views here.
def index(request):
    context = {
        "courses" : Course.objects.all()
    }
    return render(request, "courseApp/index.html", context)

def courses(request):
    Course.objects.create(name=request.POST['name'], description=request.POST['description'])
    return redirect('/')

def destroy(request, id):
    courseDB = Course.objects.get(id=int(id))
    context = {
        "name" : courseDB.name,
        "description" : courseDB.description,
        "course_id" : courseDB.id
    }
    return render(request, "courseApp/destroy.html", context)

def deleteCourse(request):
    if request.POST['Button'] == "Yes! I want to delete this":
        courseDB = Course.objects.get(id=request.POST['course_id'])
        courseDB.delete()
    return redirect('/')
