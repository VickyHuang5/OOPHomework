using MyBackupCandidate;
using System;
using System.IO;
using System.Security.Cryptography;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 加密處理器
    /// </summary>
    public class EncodeHandler : AbstractHandler
    {
        /// <summary>
        /// 覆寫執行
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);
            if (target != null)
            {
                result = this.EncodeData(candidate, target);
            }

            return result;
        }

        /// <summary>
        /// 加密資料
        /// </summary>
        /// 參考資料https://ithelp.ithome.com.tw/articles/10188765
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        private byte[] EncodeData(Candidate candidate, byte[] target)
        {
            string key = this.GetKey();
            SymmetricAlgorithm symmetricAlgorithm = this.GetSymmetricAlgorithm(key);

            // 建立對稱加密物件
            ICryptoTransform cryptoTransform = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(target, 0, target.Length);
                    cryptoStream.FlushFinalBlock();
                    cryptoStream.Close();
                    return memoryStream.ToArray();
                }
            }
        }

        /// <summary>
        /// 取得Symmetric演算
        /// </summary>
        /// <param name="key">金鑰字串</param>
        /// <returns>Symmetric演算</returns>
        private SymmetricAlgorithm GetSymmetricAlgorithm(string key)
        {
            SymmetricAlgorithm symmetricAlgorithm = new DESCryptoServiceProvider
            {
                // 設定金鑰
                Key = this.HexToByte(key),

                // 加密工作模式:CBC
                Mode = CipherMode.CBC,

                // 補充字元方式:0
                Padding = PaddingMode.Zeros,

                // 初始向量IV = 0
                IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }
            };
            return symmetricAlgorithm;
        }

        /// <summary>
        /// 取得加密Key
        /// </summary>
        /// <returns>加密Key字串</returns>
        private string GetKey()
        {
            return "vickyhuabg016417";
        }

        /// <summary>
        /// 字串轉Byte
        /// </summary>
        /// <param name="hexString">要轉換的字串</param>
        /// <returns>byte陣列</returns>
        private byte[] HexToByte(string hexString)
        {
            // 運算後的位元組長度:16進位數字字串長/2
            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2)
            {
                // 每2位16進位數字轉換為一個10進位整數
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return byteOUT;
        }
    }
}