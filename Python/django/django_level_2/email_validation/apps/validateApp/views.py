from django.shortcuts import render, redirect
from .models import User
import datetime
from django.contrib import messages
# Create your views here.
def index(request):

    return render(request, "validateApp/index.html")

def register(request):
    print request.POST
    response_from_models = User.objects.register(request.POST)


    #check to see the status from the models
    if response_from_models['status']:
        #created a user, send to success page
        request.session['user_id'] = response_from_models['user'].id
        return redirect('users:success')


    else:
        for error in response_from_models['errors']:
            messages.error(request, error)
        return redirect('users:index')


def success(request):
    context = {
        "success" : User.objects.all(),
        "curEmail" : User.objects.get(id =request.session['user_id'])
    }
    return render(request, 'validateApp/success.html', context)

def delete(request, id):
    userDataBase = User.objects.get(id=int(id))
    context = {
        "email" : userDataBase.email,
        "user_id" : userDataBase.id
    }
    return render(request, "validateApp/delete.html", context)

def deleteUser(request):
    context = {
    "success" : User.objects.all(),
    }
    if request.POST['Button'] == 'Yes! I want to delete this':
        userDataBase = User.objects.get(id = request.POST['user_id'])
        userDataBase.delete()
    return render(request, 'validateApp/currEmailList.html', context)
