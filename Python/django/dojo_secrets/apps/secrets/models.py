from __future__ import unicode_literals
from ..loginApp.models import User

from django.db import models

# Create your models here.
class Secret(models.Model):
    post = models.TextField(max_length= 200)
    likes = models.ManyToManyField(User, related_name = 'user_likes')
    user = models.ForeignKey(User, related_name = 'secret_creator')
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
