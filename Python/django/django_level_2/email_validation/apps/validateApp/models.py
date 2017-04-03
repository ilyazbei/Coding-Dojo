from __future__ import unicode_literals

from django.db import models
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


#our manager(s)!
class UserManager(models.Manager):
    def register(self, postData):
        #store the possible failed validations
        errors = []

        #do the validations
        if not len(postData['email']):
            errors.append('Email field is required!')
        if not EMAIL_REGEX.match(postData['email']):
            errors.append('Email is not valid!')

        user = self.filter(email = postData['email'])

        if user:
            errors.append('Email must be unique!')

        #create a dictionary for response to models
        modelResponse = {}

        #if failed validations
        if errors:
            #send to views
            modelResponse['status'] = False
            modelResponse['errors'] = errors
        #else (passed validations check)
        else:
            user = self.create(email = postData['email'])
            modelResponse['status'] = True
            modelResponse['user'] = user

        return modelResponse

# Create your models here.
class User(models.Model):
    email = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    objects = UserManager()
