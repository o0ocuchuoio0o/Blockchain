using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            #region // tao 1 block
            Block genesisBlock = new Block("Hi im the first block", "0");
            Console.WriteLine("Hash for block 1 : " + genesisBlock.hash);
            Block secondBlock = new Block("Yo im the second block", genesisBlock.hash);
            Console.WriteLine("Hash for block 2 : " + secondBlock.hash);
            Block thirdBlock = new Block("Hey im the third block", secondBlock.hash);
            Console.WriteLine("Hash for block 3 : " + thirdBlock.hash);
            Console.ReadLine();
            #endregion

        }
    }
    class Block
    {
        public String hash;
        public String previousHash;
        private String data; // Trong ví dụ này chúng ta chỉ lưu data là một thông báo.
        private long timeStamp;

        //Block Constructor.
        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            this.timeStamp = long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"));
            this.hash = CalculateHash();
        }

        public String CalculateHash()
        {
            HashSha256 sha256 = new HashSha256();
            String calculatedhash = sha256.Hash(
                previousHash +
                timeStamp.ToString() + data);
            return calculatedhash;
        }
    }

    class HashSha256
    {
        public string Hash(string strInput)
        {
            try
            {
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(strInput));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
