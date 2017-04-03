from django.shortcuts import render, redirect
from .models import Course, Post
import datetime
from ..loginApp.models import User

# Create your views here.
def index(request):
    context = {
        "courses" : Course.objects.all()
    }
    return render(request, "courseApp/index.html", context)

def courses(request):
    Course.objects.create(name=request.POST['name'], description=request.POST['description'])
    return redirect('course1:courseIndex')

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
    return redirect('course1:courseIndex')


def userCourse(request):
    context = {
        "course1" : Course.objects.all(),
        "usersList1": User.objects.all()

    }
    return render(request, "courseApp/users_courses.html", context)

def addUserToCourse(request):
    print "hi"
    if request.method == 'POST':
        print "add user"
        selected_user = User.objects.get(id=request.POST['user'])

        selected_course = Course.objects.get(id=request.POST['course'])

        selected_course.course_creator.add(selected_user)
        selected_course.save()

    return redirect('course1:userCourse1')
