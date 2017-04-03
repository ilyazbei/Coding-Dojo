from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^appointments$', views.index, name = 'index'),
    url(r'^addAppt$', views.addAppt, name = 'addAppt'),
    url(r'^delete/(?P<id>\d+)$', views.delete, name='delete'),
    url(r'^appointments/(?P<id>\d+)$', views.edit, name ='edit'),
]
