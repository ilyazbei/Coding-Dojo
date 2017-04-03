from django.shortcuts import render, redirect, HttpResponse
from django import forms


# Create your views here.
def index(request):
    return render(request, "form/index.html")

def process(request):
    if request.method == "POST":
        request.session['name'] = request.POST['name']
        request.session['location'] = request.POST['location']
        request.session['language'] = request.POST['language']
        request.session['comment'] = request.POST['comment']
        return redirect('/success')

def result(request):
    return render(request, "form/result.html")
