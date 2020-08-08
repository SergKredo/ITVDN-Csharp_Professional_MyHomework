using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    [AccessLevel(AccessLevelControl.AccessIsDenied)]  // Пользовательский атрибут декорирует класса Other. 
                                                      //Позиционный параметр атрибута задает отсутствие доступа пользователя к базе данных компании
    class Other : Human
    {
        public Other(string name, string lastName)
           : base(name, lastName)
        {

        }
    }
}
