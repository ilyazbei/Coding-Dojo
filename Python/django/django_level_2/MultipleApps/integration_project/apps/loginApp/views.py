from django.shortcuts import render, redirect
from .models import User
import datetime
from django.contrib import messages

# Create your views here.
def index(request):
    return render(request,'loginApp/index.html')

def register(request):
    print request.POST
    # send request.POST to the model for validations
    response_from_models = User.objects.register(request.POST)

    # check to see the status from the models
    if response_from_models['status']:
        # created a user, send to success page
        request.session['user_id'] = response_from_models['user'].id
        return redirect('users:success')
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
        request.session['first_name'] = response_from_models['user'].first_name
        request.session['last_name'] = response_from_models['user'].last_name
        request.session['email'] = response_from_models['user'].email
        request.session['user_id'] = response_from_models['user'].id
        return redirect('users:success')
    # failed validations send messages to client
    else:
        messages.error(request, response_from_models['error'])
        return redirect('users:index')


def success(request):
    if not 'user_id' in request.session:
        messages.error(request, 'Must be logged in to continue!')
        return redirect('users:index')
    return render(request, 'loginApp/success.html')

def logout(request):
    request.session.clear()
    return redirect('users:index')

def show(request, user_id):
    context = {
        'user': User.objects.get(id = user_id)
    }
    return render(request, 'loginApp/show.html', context)
