using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IEmailDal
    {
        List<EmailModelDC> GetEmails();

        EmailModelDC GetEmailById(int id);

        void AddEmail(EmailModelDC obj);

        void UpdateEmail(int id, EmailModelDC obj);

        void DeleteEmail(int id);
    }
}
