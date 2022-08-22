using System;

namespace The3BlackBro.WebQueue.Domain.Entities.ObjectValues {
    public class Email {

        public Email(string email) {
            E_mail = email;
        }
        public string E_mail {
            get { return E_mail; }
            set {
                if (ValidateEmail(value))
                    E_mail = value;
                else
                    throw new ArgumentException("Email fora do formato esperado.");
            }
        }

        public bool ValidateEmail(string email) {
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".com");
        }
    }
}
