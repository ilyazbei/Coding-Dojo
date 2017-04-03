from django.shortcuts import render, redirect
from .models import User
import datetime
from django.contrib import messages

# Create your views here.
def index(request):
    return render(request,'loginApp/index.html')

def register(request):
    # send request.POST to the model for validations
    response_from_models = User.objects.register(request.POST)

    # check to see the status from the models
    if response_from_models['status']:
        # created a user, send to success page
        request.session['user_id'] = response_from_models['user'].id
        request.session['user_name'] = response_from_models['user'].name
        request.session['user_email'] = response_from_models['user'].email
        return redirect('appointments:index')
    # failed validations send messages to client
    else:
        for error in response_from_models['errors']:
            messages.error(request, error)
        return redirect('users:index')




def login(request):
    # send request.POST to the model for validations
    response_from_models = User.objects.login(request.POST)

    if response_from_models['status']:
        # created a user, send to success page
        request.session['user_id'] = response_from_models['user'].id
        request.session['user_name'] = response_from_models['user'].name
        request.session['user_email'] = response_from_models['user'].email
        return redirect('appointments:index')
    # failed validations send messages to client
    else:
        for error in response_from_models['errors']:
            messages.error(request, error)
        return redirect('users:index')



def logout(request):
    request.session.clear()
    return redirect('users:index')
