from __future__ import unicode_literals
from django.db import models
import re

class ProductManager(models.Manager):
    def newPost(self, postData):
        Product.objects.create(name = postData["name"], description = postData["description"], price = postData["price"])

    def remove(request, id):
        Product.objects.get(id=id).delete()

    def update(request, postData, id):
        product = Product.objects.get(id=id)
        product.name = postData["name"]
        product.description = postData["description"]
        product.price = postData["price"]
        product.save()

# Create your models here.
class Product(models.Model):
    name = models.CharField(max_length=255)
    description = models.TextField(max_length= 100)
    price = models.DecimalField(max_digits=10, decimal_places=2)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = ProductManager()
