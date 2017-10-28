using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace GX.Common
{
    public static class TextService
    {
        /// <summary>
        /// ������������ת��Ϊ16���ƴ�
        /// </summary>
        /// <param name="buffer">Ҫת���Ļ�����</param>
        /// <param name="offset">��offsetλ�ÿ�ʼת��</param>
        /// <param name="count">��Ҫת���ֽڵĸ���</param>
        /// <param name="bHasDelimitate">˵��Ŀ�괮�ֽڼ��Ƿ���Ҫ�ӿո�</param>
        /// <returns>16�����ֽڴ�</returns>
        private static string BufferToHexStr(byte[] buffer, int offset, int count, bool bHasDelimitate, char delimitate)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (i != 0 && bHasDelimitate)
                {
                    sb.Append(delimitate);
                }
                sb.Append(buffer[i].ToString("X02"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// ������������ת��Ϊ16���ƴ�
        /// </summary>
        /// <param name="buffer">Ҫת���Ļ�����</param>
        /// <param name="offset">��offsetλ�ÿ�ʼת��</param>
        /// <param name="count">��Ҫת���ֽڵĸ���</param>
        /// <returns>16�����ֽڴ�</returns>
        public static string BufferToHexStr(byte[] buffer, int offset, int count)
        {
            return BufferToHexStr(buffer, offset, count, false, ' ');
        }
        /// <summary>
        /// ������������ת��Ϊ16���ƴ�
        /// </summary>
        /// <param name="buffer">Ҫת���Ļ�����</param>
        /// <returns>16�����ֽڴ�</returns>
        public static string BufferToHexStr(byte[] buffer)
        {
            return BufferToHexStr(buffer, 0, buffer.Length);
        }
        /// <summary>
        /// ������������ת��Ϊ16���ƴ����ֽ�֮��ʹ��ָ���ķָ����ֿ�
        /// </summary>
        /// <param name="buffer">Ҫת���Ļ�����</param>
        /// <param name="offset">��offsetλ�ÿ�ʼת��</param>
        /// <param name="count">��Ҫת���ֽڵĸ���</param>
        /// <param name="delimitate">�ֽڼ�ָ���</param>
        /// <returns>16�����ֽڴ�</returns>
        public static string BufferToHexStr(byte[] buffer, int offset, int count, char delimitate)
        {
            return BufferToHexStr(buffer, offset, count, true, delimitate);
        }
        /// <summary>
        /// ������������ת��Ϊ16���ƴ����ֽ�֮��ʹ��ָ���ķָ����ֿ�
        /// </summary>
        /// <param name="buffer">Ҫת���Ļ�����</param>
        /// <param name="delimitate">�ֽڼ�ָ���</param>
        /// <returns>16�����ֽڴ�</returns>
        public static string BufferToHexStr(byte[] buffer, char delimitate)
        {
            return BufferToHexStr(buffer, 0, buffer.Length, delimitate);
        }
        /// <summary>
        /// ��16���ƴ�ת��Ϊ�ֽ�����
        /// </summary>
        /// <param name="hexStr">16���ƴ�</param>
        /// <param name="bHasDelimitate">˵�������ַ����Ƿ��зָ����ţ�Ҫ��ָ�����ֻ��ռһ���ַ�</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] BufferFromHexStr(string hexStr, bool bHasDelimitate)
        {
            byte[] res;
            int byteCount;
            if (bHasDelimitate)
            {
                byteCount = hexStr.Length / 3;
                if((hexStr.Length % 3) != 0)
                {
                    byteCount++;
                }
                res = new byte[byteCount];
                for (int i = 0; i < byteCount; i++)
                {
                    try
                    {
                        string byteStr = hexStr.Substring(i * 3, 2);
                        res[i] = Convert.ToByte(byteStr, 16);
                    }
                    catch
                    {
                        return null;
                    }                    
                }
            }
            else
            {
                if (hexStr.Length % 2 != 0)
                {
                    return null;
                }
                byteCount = hexStr.Length / 2;
                res = new byte[byteCount];
                for (int i = 0; i < byteCount; i++)
                {
                    try
                    {
                        string byteStr = hexStr.Substring(i * 2, 2);
                        res[i] = Convert.ToByte(byteStr, 16);
                    }
                    catch
                    {
                        return null;
                    }                    
                }
            }
            return res;
        }
    }
    /// <summary>
    /// ���ܽ����������Լ���һ���ַ�����Ϣ
    /// ���ܵ���Encrypt������������Decrypt����
    /// </summary>
    public class Cryptor
	{
		static readonly byte[] key = {252,4,19,41,177,46,187,143,94,254,92,98,168,85,192,58};
		static readonly byte[] IV = {150,29,21,56,215,108,57,151};
		static RC2CryptoServiceProvider rc2CSP;
		static Cryptor()
		{
			rc2CSP = new RC2CryptoServiceProvider();
			rc2CSP.Key = key;
			rc2CSP.IV = IV;
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="toEncryptText">�����ܵ��ı�</param>
		/// <returns>�������ܵ��ı�</returns>
		public static string Encrypt(string toEncryptText)
		{
			UnicodeEncoding textConverter = new UnicodeEncoding();
			byte[] encrypted;
			byte[] toEncrypt;
			//Get an encryptor.
			ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);
            
			//Encrypt the data.
			MemoryStream msEncrypt = new MemoryStream();
			CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

			//Convert the data to a byte array.
			toEncrypt = textConverter.GetBytes(toEncryptText);

			//Write all data to the crypto stream and flush it.
			csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
			csEncrypt.FlushFinalBlock();

			//Get encrypted array of bytes.
			encrypted = msEncrypt.ToArray();

			//return textConverter.GetString(encrypted);
            return TextService.BufferToHexStr(encrypted, 0, encrypted.Length);

		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="toDecryptText">�����ܵ��ı�</param>
		/// <returns>���ܵ��ı�</returns>
		public static string Decrypt(string toDecryptText)
		{
			UnicodeEncoding textConverter = new UnicodeEncoding();
			byte[] fromEncrypt;
			byte[] encrypted;
			//Get a decryptor that uses the same key and IV as the encryptor.
			ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

			//encrypted = textConverter.GetBytes(toDecryptText);
            encrypted = TextService.BufferFromHexStr(toDecryptText, false);
            if (encrypted == null)
                return toDecryptText;
			//Now decrypt the previously encrypted message using the decryptor
			// obtained in the above step.
			MemoryStream msDecrypt = new MemoryStream(encrypted);
			CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

			fromEncrypt = new byte[encrypted.Length];			
            try
            {
                //Read the data oGX of the crypto stream.
                int count = csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                //Convert the byte array back into a string.
                return textConverter.GetString(fromEncrypt, 0, count);
            }
            catch
            {
                return toDecryptText;
            }
		}
	}
}
