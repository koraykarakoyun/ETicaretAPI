using ETicaretAPI.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        public string Menu { get; set; }//Controller ismi

        public ActionType ActionType { get; set; }//Action Tipi(Reading(Get),Writing(Post),Updateing(Put),Deleteing(Delete)
        public string Definiton { get; set; }//Action Açıklama
    }
}
