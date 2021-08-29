from .views import *
from django.urls import path,include
from django.contrib import admin

urlpatterns = [
    path('occupied/get/lockerIdxS', get_occupiedLockerS_lockerIdxS),
    path('occupied/get/trusterId', get_occupiedLocker_trusterId),
    path('occupied/create', create_occupiedLocker),
    path('update_occupiedLocker', update_occupiedLocker)
]
