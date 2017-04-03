from django.shortcuts import render, redirect, HttpResponse
import random, string

def index(request):
    return render(request, "randomWordGenerator/index.html")

def calculate(request):
    if request.method == "POST":
        if 'numAttempt' in request.session:
            print 'True'
            request.session['numAttempt'] += 1
            request.session['randomWord'] = ''.join([random.choice(string.ascii_letters + string.digits) for n in xrange(14)])
        else:
            request.session['numAttempt'] = 0
            request.session['randomWord'] = ''.join([random.choice(string.ascii_letters + string.digits) for n in xrange(14)])
    return redirect("randomWordGenerator1:randIndex")
