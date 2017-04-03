from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^products/$', views.index, name="index"),
    url(r'^products/new/$', views.new, name='new'),
    url(r'^newPost$', views.newPost, name='newPost'),
    url(r'^show/(?P<id>\d+)$', views.show, name ='show'),
    url(r'^edit/(?P<id>\d+)$', views.edit, name ='edit'),
    url(r'^(?P<id>\d+)$', views.remove, name ='remove'),
    url(r'^update/(?P<id>\d+)$', views.update, name='update')
]
