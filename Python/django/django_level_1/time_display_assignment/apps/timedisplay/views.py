from django.shortcuts import render, HttpResponse

from django.utils import timezone
# import arrow

# Create your views here.
def index(request):
    context = {
        'time': timezone.now()
        # 'time': arrow.utcnow()


    }
    return render(request, 'timedisplay/index.html', context)
