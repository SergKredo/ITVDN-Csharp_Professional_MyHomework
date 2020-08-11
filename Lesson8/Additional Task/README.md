Task1: Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.
-------------------------------------------------------------------------------------------------------------------------------------------------------
Results:
-------------------------------------------------------------------------------------------------------------------------------------------------------
SERIALIZABLE
--------------------
MyClass object 0:
Name: Elena
Surname: Ivanova
Age: 22
--------------------
--------------------
MyClass object 1:
Name: Petr
Surname: Julai
Age: 13
--------------------
--------------------
MyClass object 2:
Name: Oleg
Surname: Gorobets
Age: 55
--------------------
--------------------
MyClass object 3:
Name: Yana
Surname: Krug
Age: 45
--------------------
--------------------
MyClass object 4:
Name: Igor
Surname: Horoshun
Age: 33
--------------------


DESERIALIZABLE
********************
MyClass object 0:
Name: Elena;
Surname: Ivanova;
Age: 22;
********************
********************
MyClass object 1:
Name: Petr;
Surname: Julai;
Age: 13;
********************
********************
MyClass object 2:
Name: Oleg;
Surname: Gorobets;
Age: 55;
********************
********************
MyClass object 3:
Name: Yana;
Surname: Krug;
Age: 45;
********************
********************
MyClass object 4:
Name: Igor;
Surname: Horoshun;
Age: 33;
********************


XML File:
---------------------------------------------------------------------------------------------------------------------------------------
<?xml version="1.0"?>
<ArrayOfMyClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <MyClass>
    <Name>Elena</Name>
    <Surname>Ivanova</Surname>
    <Age>22</Age>
  </MyClass>
  <MyClass>
    <Name>Petr</Name>
    <Surname>Julai</Surname>
    <Age>13</Age>
  </MyClass>
  <MyClass>
    <Name>Oleg</Name>
    <Surname>Gorobets</Surname>
    <Age>55</Age>
  </MyClass>
  <MyClass>
    <Name>Yana</Name>
    <Surname>Krug</Surname>
    <Age>45</Age>
  </MyClass>
  <MyClass>
    <Name>Igor</Name>
    <Surname>Horoshun</Surname>
    <Age>33</Age>
  </MyClass>
</ArrayOfMyClass>
