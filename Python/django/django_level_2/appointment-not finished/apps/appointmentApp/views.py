from django.shortcuts import render, redirect
from django.contrib import messages
from ..loginApp.models import User
from .models import Appt
from datetime import datetime

# Create your views here.
def index(request):

    if not 'user_id' in request.session:
        messages.error(request, 'Must be logged in to continue!')
        return redirect('users:index')

    user = User.objects.get(id=request.session['user_id'])

    context = {
        "curDate": datetime.now().date(),
        "curTime": datetime.now().time(),
        "todaysAppts": Appt.objects.filter(creator=user).order_by('date_time')
    }

    return render(request, "appointmentApp/index.html", context)

def addAppt(request):
    if request.method == "POST":
        userID = request.session['user_id']
        # send request.POST to the model for validations
        user = User.objects.get(id=userID)
        respFromMod = Appt.objects.addAppt(request.POST, user)


        # check to see the status from the models
        if respFromMod['status']:
            # created a user, send to success page

            return redirect('appointments:index')
        # failed validations send messages to client
        else:
            for error in respFromMod['errors']:
                messages.error(request, error)
            return redirect('appointments:index')

    return redirect('appointments:index')

def delete(request, id):
    if request.method == "POST":
        Appt.objects.get(id=id).delete()
    return redirect("appointments:index")


def edit(request, id):
    context = {
        'curUserAppt': Appt.objects.get(id=id)
    }
    return render(request, 'appointmentApp/edit.html', context)
