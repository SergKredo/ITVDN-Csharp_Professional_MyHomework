Task2: Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
    класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
    таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.
-------------------------------------------------------------------------------------------------------------------------------------------------------
 Results:
-----------------------------------------------------------------------------------------------------------------------------------------
Serializing1.
<?xml version="1.0"?>
<ArrayOfMyClass1 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <MyClass1 Name="Igor" Surname="Petrov" Age="45" />
  <MyClass1 Name="Ilia" Surname="Ivanov" Age="48" />
  <MyClass1 Name="Kostantin" Surname="Romanov" Age="12" />
  <MyClass1 Name="Uliayana" Surname="Tubikova" Age="33" />
  <MyClass1 Name="Nina" Surname="Pogrebnaya" Age="40" />
</ArrayOfMyClass1>

****************************************************************************************************************************************
Serializing2.
--------------------------------------------------------------------------------------------------------------------------------------
<?xml version="1.0"?>
<ArrayOfMyClass2 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <MyClass2>
    <Name>Zina</Name>
    <Surname>Zubova</Surname>
    <Age>65</Age>
  </MyClass2>
  <MyClass2>
    <Name>Yurii</Name>
    <Surname>Lipskiy</Surname>
    <Age>30</Age>
  </MyClass2>
  <MyClass2>
    <Name>Ruslan</Name>
    <Surname>Reznikov</Surname>
    <Age>12</Age>
  </MyClass2>
  <MyClass2>
    <Name>Sergey</Name>
    <Surname>Frolov</Surname>
    <Age>72</Age>
  </MyClass2>
  <MyClass2>
    <Name>Konstantin</Name>
    <Surname>Poltko</Surname>
    <Age>66</Age>
  </MyClass2>
</ArrayOfMyClass2>