using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Additional_Task
{
        /*Создайте приложение WindowsForms. На главной форме приложения разместите 3 кнопки с
    названиями: IsComplete, End, Callback. Организуйте обработчики нажатия на кнопки таким
    образом, чтобы они инициировали асинхронное выполнение некоторого метода (метод
    определите сами, можно воспользоваться чем-то вроде Add или более абстрактного Compute).
    Для каждой из кнопок завершение асинхронного метода должно отслеживаться
    соответствующим образом:
        - IsComplete – с использованием значения свойства IsComplete
        - End – просто применяя EndInvoke
        - Callback – с использованием callback метода*/
    public partial class Form1 : Form
    {
        Func<double, double, double> difference;  //Инкапсулирует метод, который имеет два параметра типа double и возвращает значение типа,
                                                  //указанного параметром типа double.
        SynchronizationContext sync;   //Обеспечивает базовую функциональность для распространения контекста синхронизации
                                       // в различных моделях синхронизации.

        public Form1()
        {
            InitializeComponent();
            sync = SynchronizationContext.Current;  // Получает контекст синхронизации для текущего потока
        }

        // Метод для выполнения в отдельном асинхронном потоке.
        private double Difference(double numberOne, double numberTwo)  // Метод для расчета простой операции вычитания двух чисел. Метод сообщенный с делегатом Func<>
        {
            return numberOne - numberTwo;
        }

        private void CallBack(IAsyncResult asyncResult)  // Callback метод для обработки завершения асинхронной операции.
        {
            // Получение экземпляра делегата, на котором была вызвана асинхронная операция.
            difference = asyncResult.AsyncState as Func<double, double, double>;

            // Получение результатов асинхронной операции и присвоение значения объекту textBox из другого потока.
            sync.Post(delegate { this.textBox3.Text = difference.EndInvoke(asyncResult).ToString(); }, null);
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            double numberOne = Convert.ToDouble(this.textBox1.Text);
            double numberTwo = Convert.ToDouble(this.textBox2.Text);
            difference = new Func<double, double, double>(Difference);  // Создаем экземпляр класса-делегата и сообщаем с ним метод Difference
            IAsyncResult asyncResult = difference.BeginInvoke(numberOne, numberTwo, null, null);  // На єкземпляре класса-делегата вызываем метод BeginInvoke и передаем в метод два аргумента. 
            // Возвращаем объект типа AsyncResult, который хранит в себе объект синхронизации ядра операционной системы типа ManualResetEvent
            this.textBox3.Text = difference.EndInvoke(asyncResult).ToString();  // На єкземпляре класса-делегата вызываем метод EndInvoke и передаем в метод значение объекта asyncResult. 
        }

        private void buttonCallback_Click(object sender, EventArgs e)
        {
            double numberOne = Convert.ToDouble(this.textBox1.Text);
            double numberTwo = Convert.ToDouble(this.textBox2.Text);
            difference = new Func<double, double, double>(Difference);
            difference.BeginInvoke(numberOne, numberTwo, CallBack, difference);
        }

        private void buttonIsComplete_Click(object sender, EventArgs e)
        {
            double numberOne = Convert.ToDouble(this.textBox1.Text);
            double numberTwo = Convert.ToDouble(this.textBox2.Text);
            difference = new Func<double, double, double>(Difference);
            IAsyncResult asyncResult = difference.BeginInvoke(numberOne, numberTwo, null, null);

            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(200);
            }
            this.textBox3.Text = difference.EndInvoke(asyncResult).ToString();
        }


    }
}
