from django.conf.urls import url, include
from . import views



urlpatterns = [
    url(r'^$', views.index, name = 'randIndex'),
    url(r'^randomWord$', views.calculate, name = 'randomWord1')
]
