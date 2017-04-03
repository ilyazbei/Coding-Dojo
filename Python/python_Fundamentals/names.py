# Part 1:
def studentsPrint(student):
    for data in student:
        print data['first_name'], data['last_name']


students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
]
studentsPrint(students)

#  Part 2:
def usersPrint(user):
    for key, data in user.items():
        print key
        counter = 0
        for value in data:
            counter+=1
            lengthofName = value['first_name'] + value['last_name']
            print counter, '-', value['first_name'], value['last_name'], '-', len(lengthofName)





users = {
    'Students': [
        {'first_name':  'Michael', 'last_name' : 'Jordan'},
        {'first_name' : 'John', 'last_name' : 'Rosales'},
        {'first_name' : 'Mark', 'last_name' : 'Guillen'},
        {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ],
    'Instructors': [
        {'first_name' : 'Michael', 'last_name' : 'Choi'},
        {'first_name' : 'Martin', 'last_name' : 'Puryear'}
    ]
}

usersPrint(users)
