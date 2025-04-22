using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace aspnetMVCProject.logs
{
    public class tool
    {
        /* * CA5350:请勿使用弱加密算法	出于多种原因，现今使用弱加密算法和哈希函数，
         * https://learn.microsoft.com/zh-cn/dotnet/fundamentals/code-analysis/quality-rules/ca5350
         * 但不应使用它们来保证保密性或它们所保护的数据的完整性。
         *当此规则在代码中找到 TripleDES、SHA1、或 RIPEMD160 算法时，此规则将触发。
         *
         *代码检测分析
         *https://learn.microsoft.com/zh-cn/dotnet/fundamentals/code-analysis/overview?tabs=net-9
         *
         *对于 TripleDES 加密，请使用 Aes 加密。
         * 对于 SHA1 或 RIPEMD160 哈希函数，请从 SHA-2 系列（例如 SHA512、SHA384 和 SHA256）中选择使用。
        */
        public static string GenFileName(byte[] indexs, string prefix = null, string suffix = null)
        {
            //var base64String = Convert.ToBase64String(indexs);
            //var base64Bytes = Encoding.UTF8.GetBytes(base64String);
            //HashData(Byte[])	使用 SHA1 算法计算数据的哈希。
            //var sha256 = BitConverter
            //    .ToString(SHA256.HashData(base64Bytes))
            //    .Replace("-", string.Empty);
            //var sb = new StringBuilder();
            //if (!string.IsNullOrEmpty(prefix))
            //{
            //    sb.Append(prefix);
            //}
            //sb.Append(sha256);

            //if (!string.IsNullOrEmpty(suffix))
            //{
            //    sb.Append(suffix);
            //}
            //return sb.ToString();
            return "test";
        }

        /// <summary>
        ///  根据给定的索引、前缀和后缀生成文件名
        /// </summary>
        /// <param name="indexs"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string GenFileName2(byte[] indexs, string prefix = null, string suffix = null)
        {
            {
                // 将索引转换为base64字符串
                var base64String = Convert.ToBase64String(indexs);
                // 将base64字符串转换为字节
                var base64Bytes = Encoding.UTF8.GetBytes(base64String);

                // 创建SHA256类的实例
                using (SHA256 sha256 = SHA256.Create())
                {
                    // 计算base64字节的哈希值
                    var sha256Bytes = sha256.ComputeHash(base64Bytes);
                    // 将哈希字节转换为十六进制字符串
                    var sha256String = BitConverter
                        .ToString(sha256Bytes)
                        .Replace("-", string.Empty);

                    // 创建StringBuilder来构建最终的文件名
                    var sb = new StringBuilder();
                    // 如果前缀不为空或null，则追加前缀
                    if (!string.IsNullOrEmpty(prefix))
                    {
                        sb.Append(prefix);
                    }
                    // 追加SHA256字符串
                    sb.Append(sha256String);
                    // 如果后缀不为空或null，则追加后缀
                    if (!string.IsNullOrEmpty(suffix))
                    {
                        sb.Append(suffix);
                    }
                    // 返回最终的文件名
                    return sb.ToString();
                }
            }
        }

        // 根据给定的索引、前缀和后缀生成文件名
        public static string GenFileName3(byte[] indexs, string prefix = null, string suffix = null)
        {
            // 将索引转换为base64字符串
            var base64String = Convert.ToBase64String(indexs);
            // 将base64字符串转换为字节
            var base64Bytes = Encoding.UTF8.GetBytes(base64String);

            // 创建PBKDF2类的实例
            using (
                var pbkdf2 = new Rfc2898DeriveBytes(
                    base64String,
                    new byte[]
                    {
                        0x49,
                        0x76,
                        0x61,
                        0x6e,
                        0x20,
                        0x4d,
                        0x65,
                        0x64,
                        0x76,
                        0x65,
                        0x64,
                        0x65,
                        0x76,
                    },
                    10000
                )
            )
            {
                // 计算哈希值
                var hashBytes = pbkdf2.GetBytes(32);
                // 将哈希字节转换为十六进制字符串
                var hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // 创建StringBuilder来构建最终的文件名
                var sb = new StringBuilder();
                // 如果前缀不为空或null，则追加前缀
                if (!string.IsNullOrEmpty(prefix))
                {
                    sb.Append(prefix);
                }
                // 追加哈希字符串
                sb.Append(hashString);
                // 如果后缀不为空或null，则追加后缀
                if (!string.IsNullOrEmpty(suffix))
                {
                    sb.Append(suffix);
                }
                // 返回最终的文件名
                return sb.ToString();
            }
        }

        public static string GenFileName4(byte[] indexs, string prefix = null, string suffix = null)
        {
            var base64String = Convert.ToBase64String(indexs);
            var base64Bytes = Encoding.UTF8.GetBytes(base64String);

            // 生成随机盐值
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(base64String, salt, 10000))
            {
                var hashBytes = pbkdf2.GetBytes(32);
                var hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                var sb = new StringBuilder();
                if (!string.IsNullOrEmpty(prefix))
                {
                    sb.Append(prefix);
                }
                sb.Append(hashString);
                if (!string.IsNullOrEmpty(suffix))
                {
                    sb.Append(suffix);
                }
                return sb.ToString();
            }
        }
    }
}
