using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    [AccessLevel(AccessLevelControl.FullControlforDirector)]   // Пользовательский атрибут декорирует класса Director. 
                                                               //Позиционный параметр атрибута задает полный доступ пользователя к базе данных
    class Director: Human
    {
        public Director(string name, string lastName)
           : base(name, lastName)
        {

        }
    }
}
