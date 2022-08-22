using System;
using System.Text;

namespace The3BlackBro.WebQueue.Infra.CrossCutting.Utils
{
    public static class Cryptography {

        /// <summary>
        /// Criptografa a senha em base 64.
        /// </summary>
        /// <param name="passWord">Senha que o usuário digitou.</param>
        /// <returns></returns>
        public static string EncryptingBase64(string passWord) {

            var textBytes = Encoding.UTF8.GetBytes(passWord);
            return Convert.ToBase64String(textBytes);
        }

        /// <summary>
        /// Descriptografa a senha para o tipo string.
        /// </summary>
        /// <param name="encryptedPassWord">Senha recuperada do BD criptografada</param>
        /// <returns></returns>
        public static string DecryptBase64(string encryptedPassWord) {

            var base64EncodedBytes = Convert.FromBase64String(encryptedPassWord);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
