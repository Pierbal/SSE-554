using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_SSE554
{
     class user
    {
        string usrName, password, email;
        int code;
        DateTime birthday;
       public user(string userNameTemp, string passwordTemp, string emailTemp, int codeTemp, DateTime birthdayTemp)
        {
            usrName = userNameTemp;
            password = passwordTemp;
            email = emailTemp;
            code = codeTemp;
            birthday = birthdayTemp;
        }
       public string getUsrName()
        {
            return usrName;
        }
       public string getPass()
        {
            return password;
        }
       public string getEmail()
        {
            return email;
        }
       public int getCode()
        {
            return code;
        }
       public DateTime getBday()
        {
            return birthday;
        }        
    }
}
