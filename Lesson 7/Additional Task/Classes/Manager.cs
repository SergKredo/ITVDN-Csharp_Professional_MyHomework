using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    [AccessLevel(AccessLevelControl.MiddleControlforManager)]  // Пользовательский атрибут декорирует класса Manager. 
                                                               //Позиционный параметр атрибута задает частичный доступ пользователя к базе данных компании
    class Manager : Human
    {
        public Manager(string name, string lastName)
            : base(name, lastName)
        { 
        
        }
    }
}
