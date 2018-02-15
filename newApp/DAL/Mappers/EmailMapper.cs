using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class EmailMapper { }
    public partial class EmailDal
    {
        public EmailModelDC MapToEmailModelDC(Email a)
        {
            return new EmailModelDC()
            {
                emailId = a.EmailId,
                emailAddress = a.EmailAddress,
                isPrimary = a.IsPrimary,
                userId = a.UserId,
                isDeleted = a.IsDeleted

            };
        }
        public Email MapToEmail(EmailModelDC a)
        {
            return new Email()
            {
                EmailId = a.emailId,
                EmailAddress = a.emailAddress,
                IsPrimary = a.isPrimary,
                UserId = a.userId,
                IsDeleted = a.isDeleted
            };
        }

        public EmailModelDC MapAndSaveEmailToEmailModelDC(EmailModelDC a, Email b)
        {
            a.emailId = b.EmailId;
            a.emailAddress = b.EmailAddress;
            a.isPrimary = b.IsPrimary;
            a.userId = b.UserId;
            a.isDeleted = b.IsDeleted;
            return a;
        }

        public Email MapAndSaveEmailModelDCToEmail(Email a, EmailModelDC b)
        {
            a.EmailId = b.emailId;
            a.EmailAddress = b.emailAddress;
            a.IsPrimary = b.isPrimary;
            a.UserId = b.userId;
            a.IsDeleted = b.isDeleted;
            return a;
        }
    }
}
