using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class CreateUserException:Exception 
    {
        public CreateUserException():base("Kullanıcı kayıt edilirken hata oluştu")
        {

        }


    }
}
