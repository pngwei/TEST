using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace GX.Common
{
    public static class TextService
    {
        /// <summary>
        /// 将缓冲区内容转换为16进制串
        /// </summary>
        /// <param name="buffer">要转换的缓冲区</param>
        /// <param name="offset">从offset位置开始转换</param>
        /// <param name="count">需要转换字节的个数</param>
        /// <param name="bHasDelimitate">说明目标串字节间是否需要加空格</param>
        /// <returns>16进制字节串</returns>
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
        /// 将缓冲区内容转换为16进制串
        /// </summary>
        /// <param name="buffer">要转换的缓冲区</param>
        /// <param name="offset">从offset位置开始转换</param>
        /// <param name="count">需要转换字节的个数</param>
        /// <returns>16进制字节串</returns>
        public static string BufferToHexStr(byte[] buffer, int offset, int count)
        {
            return BufferToHexStr(buffer, offset, count, false, ' ');
        }
        /// <summary>
        /// 将缓冲区内容转换为16进制串
        /// </summary>
        /// <param name="buffer">要转换的缓冲区</param>
        /// <returns>16进制字节串</returns>
        public static string BufferToHexStr(byte[] buffer)
        {
            return BufferToHexStr(buffer, 0, buffer.Length);
        }
        /// <summary>
        /// 将缓冲区内容转换为16进制串，字节之间使用指定的分隔符分开
        /// </summary>
        /// <param name="buffer">要转换的缓冲区</param>
        /// <param name="offset">从offset位置开始转换</param>
        /// <param name="count">需要转换字节的个数</param>
        /// <param name="delimitate">字节间分隔符</param>
        /// <returns>16进制字节串</returns>
        public static string BufferToHexStr(byte[] buffer, int offset, int count, char delimitate)
        {
            return BufferToHexStr(buffer, offset, count, true, delimitate);
        }
        /// <summary>
        /// 将缓冲区内容转换为16进制串，字节之间使用指定的分隔符分开
        /// </summary>
        /// <param name="buffer">要转换的缓冲区</param>
        /// <param name="delimitate">字节间分隔符</param>
        /// <returns>16进制字节串</returns>
        public static string BufferToHexStr(byte[] buffer, char delimitate)
        {
            return BufferToHexStr(buffer, 0, buffer.Length, delimitate);
        }
        /// <summary>
        /// 将16进制串转换为字节数组
        /// </summary>
        /// <param name="hexStr">16进制串</param>
        /// <param name="bHasDelimitate">说明串中字符间是否有分隔符号，要求分隔符号只能占一个字符</param>
        /// <returns>字节数组</returns>
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
    /// 加密解密器，可以加密一段字符串信息
    /// 加密调用Encrypt函数，解密用Decrypt函数
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
		/// 加密数据
		/// </summary>
		/// <param name="toEncryptText">待加密的文本</param>
		/// <returns>经过加密的文本</returns>
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
		/// 解密数据
		/// </summary>
		/// <param name="toDecryptText">待解密的文本</param>
		/// <returns>解密的文本</returns>
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
