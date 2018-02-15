using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class EmailDal : IEmailDal
    {
        private APLABDatabaseEntities _db;

        public EmailDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<EmailModelDC> GetEmails()
        {
            List<EmailModelDC> list = new List<EmailModelDC>();
            foreach (Email email in _db.Emails)
            {
                if (email.IsDeleted == false)
                {
                    list.Add(MapToEmailModelDC(email));
                }
            }
            return list;
        }

        public EmailModelDC GetEmailById(int id)
        {
            Email obj = _db.Emails.FirstOrDefault(x => x.EmailId == id);

            if (obj == null)
            {
                throw new ArgumentException(Messages.EmailExceptionGetById);
            }
            else
            {
                return MapToEmailModelDC(obj);
            }
        }

        public void AddEmail(EmailModelDC obj)
        {
            if (obj == null)
                throw new ArgumentException(Messages.EmailExceptionAdd);

            _db.Emails.Add(MapToEmail(obj));
            _db.SaveChanges();
        }

        public void UpdateEmail(int id, EmailModelDC obj)
        {
            Email email = _db.Emails.FirstOrDefault(x => x.EmailId == id);

            if (email == null)
            {
                throw new ArgumentException(Messages.EmailExceptionUpdateById);
            }

            email = MapAndSaveEmailModelDCToEmail(email, obj);
            _db.SaveChanges();
        }

        public void DeleteEmail(int id)
        {
            Email email = _db.Emails.FirstOrDefault(x => x.EmailId == id);

            if (email == null)
            {
                throw new ArgumentException(Messages.EmailExceptionDelete);
            }

            foreach (var i in _db.Emails)
            {
                if (i.EmailId == id)
                {
                    _db.Emails.Remove(i);
                }
            }
            _db.SaveChanges();
        }
    }
}
