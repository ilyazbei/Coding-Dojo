from django.db import models

# Create your models here.
class People(models.Model):
    first_name = models.CharField(max_length=38)
    last_name = models.CharField(max_length= 38)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
