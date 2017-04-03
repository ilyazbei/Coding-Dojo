from __future__ import unicode_literals
from ..loginApp.models import User
from django.db import models
from datetime import datetime
import re

class ApptManager(models.Manager):
    def addAppt(self, postData, user):
        errors = []

        if len(postData['date']) < 1:
            errors.append('Date must be selected!')

        if len(postData['time']) < 1:
            errors.append('Time must have input!')


        if len(postData['task']) < 1:
            errors.append('You must enter a task!')
        elif len(postData['task']) < 2:
            errors.append('Item must be at least 2 characters long!')

        print postData['date'], postData['time']

        if len(errors) == 0:

            dateOfAppt = datetime.strptime(postData['date'] + postData['time'], '%Y-%m-%d%H:%M')
            if dateOfAppt < datetime.now():
                errors.append('Please select current or future dates/time!')


        userAPT = self.filter(time = postData['time'], date = postData['date'])

        if userAPT:
            errors.append('This task already exists!')
        # if len(errors) == 0:
        #     timeOfAppt = datetime.strptime(postData['time'], '%H:%M')
        #     if timeOfAppt < datetime.now():
        #         errors.append('Please select future time!')



        modelResponse = {}

        if errors:
            # send them to the views
            modelResponse['status'] = False
            modelResponse['errors'] = errors

        # else (passed validations check)
        else:
            # create

            Appt.objects.create(task = postData['task'], date = postData['date'], time = postData['time'], status = postData['status'], creator=user)



            # send back to views
            modelResponse['status'] = True


        return modelResponse


# Create your models here.
class Appt(models.Model):
    creator = models.ForeignKey(User, related_name = 'created_appts')
    date = models.DateField()
    time = models.TimeField()
    task = models.CharField(max_length=255)
    status = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = ApptManager()
