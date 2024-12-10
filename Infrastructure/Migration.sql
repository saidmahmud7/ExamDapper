create database SchoolDb


create table parents
(
parentid serial primary key,
parentcode varchar(12),
fullname varchar(50),
email varchar(100) UNIQUE,
phone varchar(20) UNIQUE,
createdat date default current_date,
updateat date default current_date
);

create table studentparent
(
studentparent serial primary key,
studentid int REFERENCES students(studentid),
parentid int REFERENCES parents(parentid),
relationship int
)

create table students
(
studentid serial primary key,
studentcode varchar(12),
fullname varchar(50),
gender varchar(20),
dob date default current_date,
email varchar(100) UNIQUE,
phone varchar(15) UNIQUE,
shoolid int REFERENCES school(schoolid),
stage int,
section varchar(10),
isactive bool default false,
joindate date DEFAULT CURRENT_date,
createdat date default current_date,
updateat date default current_date
);

create table school
(
schoolid serial primary key,
title varchar(50),
levelcount int,
isactive bool default false,
createdat date default current_date,
updateat date default current_date
)


create table subject
(
subjectid serial primary key,
title varchar(100),
schoolid int REFERENCES school(schoolid),
stage int,
carrymark int,
createdat date default current_date,
updateat date default current_date
);

create table classroom
(
classroomid serial primary key,
capacity int,
roomtype int,
description text,
createdat date default current_date,
updateat date default current_date
)

create table teachers
(
teacherid serial primary key,
teachercode varchar(15),
fullname varchar(100),
gender varchar(20),
dob date default current_date,
email varchar(100) UNIQUE,
phone varchar(20) UNIQUE,
isactive bool default false,
joindate date default current_date,
workingdays int,
createdat date default current_date,
updateat date default current_date
)

create table classes
(
classid serial primary key,
name varchar(100),
subjectid int REFERENCES subject(subjectid),
teacherid int references teachers(teacherid),
classroomid int REFERENCES classroom(classroomid),
section varchar(10),
createdat date default current_date,
updateat date default current_date
);

create table class_student
(
class_student serial primary key,
classid int REFERENCES classes(classid),
studentid int references students(studentid)
)