from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'courseIndex'),
    url(r'^courses$', views.courses, name = 'courses2'),
    url(r'^destroy/(?P<id>\d+)$', views.destroy, name = 'destroy1'),
    url(r'^deleteCourse$', views.deleteCourse, name= 'deleteCourse1'),
    url(r'^userCourse$', views.userCourse, name = 'userCourse1'),
    url(r'^addUserToCourse', views.addUserToCourse, name="addUserToCourse")
]
