Task1: Используя конструкции блокировки, создайте метод, который будет в цикле for (допустим, на 10
       итераций) увеличивать счетчик на единицу и выводить на экран счетчик и текущий поток.
       Метод запускается в трех потоках. Каждый поток должен выполниться поочередно, т.е. в
       результате на экран должны выводиться числа (значения счетчика) с 1 до 30 по порядку, а не в
       произвольном порядке.

 Results:
--------------------------------------
Counter: 1, threadID: 3;
Counter: 2, threadID: 3;
Counter: 3, threadID: 3;
Counter: 4, threadID: 3;
Counter: 5, threadID: 3;
Counter: 6, threadID: 3;
Counter: 7, threadID: 3;
Counter: 8, threadID: 3;
Counter: 9, threadID: 3;
Counter: 10, threadID: 3;

Counter: 11, threadID: 4;
Counter: 12, threadID: 4;
Counter: 13, threadID: 4;
Counter: 14, threadID: 4;
Counter: 15, threadID: 4;
Counter: 16, threadID: 4;
Counter: 17, threadID: 4;
Counter: 18, threadID: 4;
Counter: 19, threadID: 4;
Counter: 20, threadID: 4;

Counter: 21, threadID: 5;
Counter: 22, threadID: 5;
Counter: 23, threadID: 5;
Counter: 24, threadID: 5;
Counter: 25, threadID: 5;
Counter: 26, threadID: 5;
Counter: 27, threadID: 5;
Counter: 28, threadID: 5;
Counter: 29, threadID: 5;
Counter: 30, threadID: 5;
