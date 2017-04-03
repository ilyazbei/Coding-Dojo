from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'index'),
    url(r'^register$', views.register, name = 'register'),
    url(r'^success$', views.success, name ='success'),
    url(r'^delete/(?P<id>\d+)$', views.delete, name = 'delete'),
    url(r'^deleteUser$', views.deleteUser, name = 'deleteUser'),
]
