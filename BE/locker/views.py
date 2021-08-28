import re
from django.db.models import Q, manager

from user.models import *
from django.http.response import HttpResponse
from rest_framework.response import Response
from rest_framework.decorators import api_view

from .serializers import *
import json
## 가져오는..

@api_view(['POST'])
def get_occupiedLockerS_lockerIdxS(request):
    # input
    # - stationName (required)
    print(request.data)
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        try:
            input = json.loads(request.data.get('_content')) 
        except:
            input = request.data.get('_content')
        
        print(input)
    else:
        input = request.data
    # 데이터는 ['1','2',"3",'4',"5"]의 형태로 들어와야 합니다.
    lockerIdxS = input['lockerIdxS'].replace(' ','').split(",")
    for idx, lockerIdx in enumerate(lockerIdxS):
        lockerIdxS[idx] = int(lockerIdx)
    print(lockerIdxS)
    print(len(lockerIdxS))
    print(type(lockerIdxS))
    print(type(lockerIdxS[0]))
    occupiedLockerS = list(
        OccupiedLocker.objects.filter(lockerIdx__in = lockerIdxS)
        #.order_by('lockerIdx')
    )

    serializer = OccupiedLockerSerializer(occupiedLockerS, many = True)
    print("VACANT LOCKER IN :"+lockerIdxS+" => ")
    print(serializer.data)
    return Response(serializer.data)
@api_view(['POST'])
def create_occupiedLocker(request):
    # input
    # - lockerIdx (required)
    # - password (required)
    # - title (required)
    # - info (required)
    # - isOpen (required)
    # - trusterId (required)
    print(request.data)
    print(type(request.data))
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    # userS = list(User.objects.filter(userId = input['trusterId']))
    # user = userS[0]
    # autoPayment = user.autoPayment
    else:
        input = request.data

    occupiedLockerS = OccupiedLocker.objects.create(
        lockerIdx = input['lockerIdx'],
        password = input['password'],
        title = input['title'],
        info = input['info'],
        trusterId = input['trusterId'],
        isPaid = False # 수종하기
    )
    serializer = OccupiedLockerSerializer(occupiedLockerS, many = True)
    return Response(serializers.data)
@api_view(['POST'])
def update_occupiedLocker(request):
    # input
    # - idx (required)
    # - password
    # - title
    # - info
    # - isOpen
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = input['idx']))
    occupiedLocker = occupiedLockerS[0]


    if 'password' in input:
        occupiedLocker.password = input['password']
    if 'title' in input:
        occupiedLocker.title = input['title']
    if 'info' in input:
        occupiedLocker.info = input['info']
    if 'isOpen' in input:
        occupiedLocker.title = input['isOpen']
    if 'isPaid' in input:
        occupiedLocker.isPaid = input['isPaid']

    return HttpResponse('UPDATE LOCKER USING')
@api_view(['POST'])
def delete_occupiedLocker(request):
    # input
    # - idx (required)
    if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
        #<class 'django.http.request.QueryDict'>
        input = json.loads(request.data.get('_content')) 
        print(input)
    occupiedLockerS = list(OccupiedLocker.objects.filter(idx = input['idx']))
    occupiedLocker = occupiedLockerS[0]
    serializer = serializers.OccupiedLockerSerializer(occupiedLocker)
    occupiedLocker.delete()
    return Response(serializer.data)
# @api_view(['POST'])
# def get_all_lockerS_onStation(request):
#     if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
#         #<class 'django.http.request.QueryDict'>
#         input = json.loads(request.data.get('_content')) 
#         print(input)
#     lockerS = Locker.objects.filter(stationUUID = input['stationUUID'])
#     serializer = serializers.LockerSerializer(lockerS)
#     return Response(serializer.data)
# @api_view(['POST'])
# def get_occupiedLockerS_onStation(request):
#     if(str(type(request.data)) == '<class \'django.http.request.QueryDict\'>'):
#         #<class 'django.http.request.QueryDict'>
#         input = json.loads(request.data.get('_content')) 
#         print(input)
#     occupiedLockerS = OccupiedLocker.objects.filter(lockerId__in = input['lockerIdS'])
#     serializer = serializers.OcupiedLockerSerializer(occupiedLockerS)
#     return Response(serializer.data)
