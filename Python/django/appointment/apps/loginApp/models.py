from __future__ import unicode_literals

from django.db import models
from datetime import datetime
import re, bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')





# Create your models here.
class UserManager(models.Manager):
    def register(self, postData):
        # store the possible failed validations
        errors = []


        #do validations
        if len(postData['name']) < 3:
            errors.append('First name must be at least 3 characters long!')
        if not len(postData['email']):
            errors.append('Email field is required!')
        if not EMAIL_REGEX.match(postData['email']):
            errors.append('Email must be valid!')

        if len(postData['password']) < 8:
            errors.append('Password must be at least 8 characters long!')
        if not postData['password'] == postData['confirm_password']:
            errors.append('Password must match!')

        if len(postData['date']) < 1:
            errors.append('Date field must be selcted!')
        else:
            dateOfBirth = datetime.strptime(postData['date'], '%Y-%m-%d')
            if dateOfBirth > datetime.now():
                errors.append('Date of birth can not be in the future!')

        user = self.filter(email = postData['email'])

        if user:
            errors.append('Email must be unique!')

        # create a dictionary for response to models
        modelResponse = {}

        # if failed validations
        if errors:
            # send them to the views
            modelResponse['status'] = False
            modelResponse['errors'] = errors

        # else (passed validations check)
        else:
            # use bcrypt to hash password
            hashed_password = bcrypt.hashpw(postData['password'].encode(), bcrypt.gensalt())
            # create the user
            user = self.create(name = postData['name'], email = postData['email'], password = hashed_password)
            # send user back to views
            modelResponse['status'] = True
            modelResponse['user'] = user

        return modelResponse


    def login(self, postData):
        # check to see if user is in DB
        user = self.filter(email = postData['email'])

        modelResponse = {}

        # if user exist
        if user:
            # check for matching passwords
            if bcrypt.checkpw(postData['password'].encode(), user[0].password.encode()):
                # send success to views
                modelResponse['status'] = True
                modelResponse['user'] = user[0]
            # fail match password
            else:
                # send error message to views
                modelResponse['status'] = False
                modelResponse['errors'] = 'Invalid email/ password combination!'
        # else
        else:
            # send message to views
            modelResponse['status'] = False
            modelResponse['errors'] = 'Invalid email!'

        return modelResponse

class User(models.Model):
    name = models.CharField(max_length = 45)
    email = models.CharField(max_length = 255)
    password = models.CharField(max_length = 255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()
