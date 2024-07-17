using Business.Concrate.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.EmailService
{
    public interface IEMailSenderService
    {
        void SendEmailRegister(Message message);
        void SendEmailForgotPassword(Message message);
        void SendContact(Message message);
    }
}
