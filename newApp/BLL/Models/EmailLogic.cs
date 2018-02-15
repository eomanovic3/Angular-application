using BLL;
using DAL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailLogic : IEmail
    {
        private readonly EmailDal _emails;

        public EmailLogic(EmailDal emails)
        {
           _emails = emails;
        }
        public List<EmailModelDC> GetEmails()
        {
            return _emails.GetEmails();
        }

        public EmailModelDC GetEmailById(int id)
        {
            if(id < 0)
                throw new ArgumentException(Messages.EmailExceptionGetById);
            return _emails.GetEmailById(id);
        }

        public void AddEmail(EmailModelDC obj)
        {
            foreach (EmailModelDC email in _emails.GetEmails())
            {
                if (email.emailId == obj.emailId)
                {
                    throw new ArgumentException(Messages.EmailExceptionAdd);
                }
            }
            this._emails.AddEmail(obj);
        }

        public void UpdateEmail(int id, EmailModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.EmailExceptionUpdateById);

            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            _emails.UpdateEmail(id, obj);
        }

        public void DeleteEmail(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.EmailExceptionDelete);
            foreach (EmailModelDC email in _emails.GetEmails())
            {
                if (email.emailId == id)
                {
                    _emails.DeleteEmail(id);
                }
            }
        }
    }
}
