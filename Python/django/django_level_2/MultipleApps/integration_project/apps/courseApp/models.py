from __future__ import unicode_literals

from django.db import models
from ..loginApp.models import User

# Create your models here.
class Course(models.Model):
    name = models.CharField(max_length=255)
    description = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    course_creator = models.ManyToManyField(User)

class Post(models.Model):
    course_id = models.ForeignKey(Course)
    course_name = models.CharField(max_length=255)
    description = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
