using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;

namespace Currency_Info.ViewModels
{
    class ErrorServer: ViewModelBase
    {
        string error = "Сервер не обновляет базу данных! Попробуйте позже!";
        public string ErrorServ
        {
            get 
            {
                return error;
            }
            set 
            {
                error = value;
                OnPropertyChanged();
            }
        }

    }
}
