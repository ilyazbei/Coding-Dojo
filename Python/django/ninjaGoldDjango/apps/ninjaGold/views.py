from django.shortcuts import render, redirect, HttpResponse
import datetime
import random
# Create your views here.

def index(request):
    if 'curGold' not in request.session:
        request.session['curGold'] = 0
    if 'activities' not in request.session:
        request.session['activities'] = []
    return render(request, "ninjaGold/index.html")

def process(request):
    now = '({:%Y/%m/%d %H:%M %p})'.format(datetime.datetime.now())
    buildings = {
        'farm': random.randint(10, 20),
        'cave': random.randint(5, 10),
        'house': random.randint(2, 5),
        'casino': random.randint(-50, 50),
    }
    if request.POST['building'] == 'casino':
        result = buildings[request.POST['building']]
        request.session['curGold'] += result
        result_dict = {
            'class': "green" if result >= 0 else "red",
            'activity': 'Entered a casino and {} {} golds.. {}\
            {}'.format(('lost', 'gained')[result >= 0], result,
                       ('Ouch...', '')[result >=1], now)
        }
    else:
        result = buildings[request.POST['building']]
        request.session['curGold'] += result
        result_dict = {
        'class': 'green',
        'activity': ' Earned {} golds from the {}!\
        {}'.format(result,request.POST['building'], now)
        }

    request.session['activities'].append(result_dict)
    return redirect("/")

def reset(request):
    request.session.clear()
    return redirect('/')
