from django.shortcuts import render, redirect, HttpResponse
import random, string
# Create your views here.
def check_init(request):
    if 'numAttempt' in request.session:
        print 'True'
    else:
        request.session['numAttempt'] = 0
        numAttempt = 0
        randomWord = ""
        print 'False'
def index(request):
    return render(request, "randomWordGenerator/index.html")

def calculate(request):
    if request.method == "POST":
        request.session['numAttempt'] = request.session['numAttempt'] + 1
        request.session['randomWord'] = ''.join([random.choice(string.ascii_letters + string.digits) for n in xrange(14)])
        return redirect("/")
    else:
        return redirect("/")
