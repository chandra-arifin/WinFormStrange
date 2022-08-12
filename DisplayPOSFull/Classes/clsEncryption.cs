using System.Collections.Generic;
using System.Security.Cryptography;
using System;
using System.Text;

namespace ZFame
{
	namespace Security
	{
        /// <summary>
        /// Generic PBKDF2 implementation.
        /// </summary>
        /// <example>This sample shows how to initialize class with SHA-256 HMAC.
        /// <code>
        /// using (var hmac = new HMACSHA256()) {
        ///     var df = new Pbkdf2(hmac, "password", "salt");
        ///     var bytes = df.GetBytes();
        /// }
        /// </code>
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pbkdf", Justification = "Spelling is correct.")]
        public class Pbkdf2
        {

            /// <summary>
            /// Creates new instance.
            /// </summary>
            /// <param name="algorithm">HMAC algorithm to use.</param>
            /// <param name="password">The password used to derive the key.</param>
            /// <param name="salt">The key salt used to derive the key.</param>
            /// <param name="iterations">The number of iterations for the operation.</param>
            /// <exception cref="System.ArgumentNullException">Algorithm cannot be null - Password cannot be null. -or- Salt cannot be null.</exception>
            public Pbkdf2(HMAC algorithm, Byte[] password, Byte[] salt, Int32 iterations)
            {
                if (algorithm == null) { throw new ArgumentNullException("algorithm", "Algorithm cannot be null."); }
                if (salt == null) { throw new ArgumentNullException("salt", "Salt cannot be null."); }
                if (password == null) { throw new ArgumentNullException("password", "Password cannot be null."); }
                this.Algorithm = algorithm;
                this.Algorithm.Key = password;
                this.Salt = salt;
                this.IterationCount = iterations;
                this.BlockSize = this.Algorithm.HashSize / 8;
                this.BufferBytes = new byte[this.BlockSize];
            }

            /// <summary>
            /// Creates new instance.
            /// </summary>
            /// <param name="algorithm">HMAC algorithm to use.</param>
            /// <param name="password">The password used to derive the key.</param>
            /// <param name="salt">The key salt used to derive the key.</param>
            /// <exception cref="System.ArgumentNullException">Algorithm cannot be null - Password cannot be null. -or- Salt cannot be null.</exception>
            public Pbkdf2(HMAC algorithm, Byte[] password, Byte[] salt)
                : this(algorithm, password, salt, 1000)
            {
            }

            /// <summary>
            /// Creates new instance.
            /// </summary>
            /// <param name="algorithm">HMAC algorithm to use.</param>
            /// <param name="password">The password used to derive the key.</param>
            /// <param name="salt">The key salt used to derive the key.</param>
            /// <param name="iterations">The number of iterations for the operation.</param>
            /// <exception cref="System.ArgumentNullException">Algorithm cannot be null - Password cannot be null. -or- Salt cannot be null.</exception>
            public Pbkdf2(HMAC algorithm, String password, String salt, Int32 iterations) :
                this(algorithm, UTF8Encoding.UTF8.GetBytes(password), UTF8Encoding.UTF8.GetBytes(salt), iterations)
            {
            }

            /// <summary>
            /// Creates new instance.
            /// </summary>
            /// <param name="algorithm">HMAC algorithm to use.</param>
            /// <param name="password">The password used to derive the key.</param>
            /// <param name="salt">The key salt used to derive the key.</param>
            /// <exception cref="System.ArgumentNullException">Algorithm cannot be null - Password cannot be null. -or- Salt cannot be null.</exception>
            public Pbkdf2(HMAC algorithm, String password, String salt) :
                this(algorithm, password, salt, 1000)
            {
            }


            private readonly int BlockSize;
            private uint BlockIndex = 1;

            private byte[] BufferBytes;
            private int BufferStartIndex = 0;
            private int BufferEndIndex = 0;


            /// <summary>
            /// Gets algorithm used for generating key.
            /// </summary>
            public HMAC Algorithm { get; private set; }

            /// <summary>
            /// Gets salt bytes.
            /// </summary>
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Byte array is proper return value in this case.")]
            public Byte[] Salt { get; private set; }

            /// <summary>
            /// Gets iteration count.
            /// </summary>
            public Int32 IterationCount { get; private set; }


            /// <summary>
            /// Returns a pseudo-random key from a password, salt and iteration count.
            /// </summary>
            /// <param name="count">Number of bytes to return.</param>
            /// <returns>Byte array.</returns>
            public Byte[] GetBytes(int count)
            {
                byte[] result = new byte[count];
                int resultOffset = 0;
                int bufferCount = this.BufferEndIndex - this.BufferStartIndex;

                if (bufferCount > 0)
                { //if there is some data in buffer
                    if (count < bufferCount)
                    { //if there is enough data in buffer
                        Buffer.BlockCopy(this.BufferBytes, this.BufferStartIndex, result, 0, count);
                        this.BufferStartIndex += count;
                        return result;
                    }
                    Buffer.BlockCopy(this.BufferBytes, this.BufferStartIndex, result, 0, bufferCount);
                    this.BufferStartIndex = this.BufferEndIndex = 0;
                    resultOffset += bufferCount;
                }

                while (resultOffset < count)
                {
                    int needCount = count - resultOffset;
                    this.BufferBytes = this.Func();
                    if (needCount > this.BlockSize)
                    { //we one (or more) additional passes
                        Buffer.BlockCopy(this.BufferBytes, 0, result, resultOffset, this.BlockSize);
                        resultOffset += this.BlockSize;
                    }
                    else
                    {
                        Buffer.BlockCopy(this.BufferBytes, 0, result, resultOffset, needCount);
                        this.BufferStartIndex = needCount;
                        this.BufferEndIndex = this.BlockSize;
                        return result;
                    }
                }
                return result;
            }

            private byte[] Func()
            {
                var hash1Input = new byte[this.Salt.Length + 4];
                Buffer.BlockCopy(this.Salt, 0, hash1Input, 0, this.Salt.Length);
                Buffer.BlockCopy(GetBytesFromInt(this.BlockIndex), 0, hash1Input, this.Salt.Length, 4);
                var hash1 = this.Algorithm.ComputeHash(hash1Input);

                byte[] finalHash = hash1;
                for (int i = 2; i <= this.IterationCount; i++)
                {
                    hash1 = this.Algorithm.ComputeHash(hash1, 0, hash1.Length);
                    for (int j = 0; j < this.BlockSize; j++)
                    {
                        finalHash[j] = (byte)(finalHash[j] ^ hash1[j]);
                    }
                }
                if (this.BlockIndex == uint.MaxValue) { throw new InvalidOperationException("Derived key too long."); }
                this.BlockIndex += 1;

                return finalHash;
            }

            private static byte[] GetBytesFromInt(uint i)
            {
                var bytes = BitConverter.GetBytes(i);
                if (BitConverter.IsLittleEndian)
                {
                    return new byte[] { bytes[3], bytes[2], bytes[1], bytes[0] };
                }
                else
                {
                    return bytes;
                }
            }
        }



        /* 
         * Password Hashing With PBKDF2 (http://crackstation.net/hashing-security.htm).
         * Copyright (c) 2013, Taylor Hornby
         * All rights reserved.
         *
         * Redistribution and use in source and binary forms, with or without 
         * modification, are permitted provided that the following conditions are met:
         *
         * 1. Redistributions of source code must retain the above copyright notice, 
         * this list of conditions and the following disclaimer.
         *
         * 2. Redistributions in binary form must reproduce the above copyright notice,
         * this list of conditions and the following disclaimer in the documentation 
         * and/or other materials provided with the distribution.
         *
         * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
         * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
         * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
         * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE 
         * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
         * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
         * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
         * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
         * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
         * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
         * POSSIBILITY OF SUCH DAMAGE.
         */

        /// <summary>
        /// Salted password hashing with PBKDF2-SHA1.
        /// Author: havoc AT defuse.ca
        /// www: http://crackstation.net/hashing-security.htm
        /// Compatibility: .NET 3.0 and later.
        /// </summary>
        public class PasswordHash
        {
            // The following constants may be changed without breaking existing hashes.
            public const int SALT_BYTE_SIZE = 24;
            //output BYTE
            public const int HASH_BYTE_SIZE = 24;
            public const int PBKDF2_ITERATIONS = 8479;

            public const int ITERATION_INDEX = 0;
            public const int SALT_INDEX = 1;
            public const int PBKDF2_INDEX = 2;

            /// <summary>
            /// Creates a salted PBKDF2 hash of the password.
            /// </summary>
            /// <param name="password">The password to hash.</param>
            /// <returns>The hash of the password.</returns>
            public static string CreateHash(string password)
            {
                byte[] salt = new byte[SALT_BYTE_SIZE];

                // Generate a random salt
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }

                // Hash the password and encode the parameters
                byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
                return PBKDF2_ITERATIONS + ":" +
                    Convert.ToBase64String(salt) + ":" +
                    Convert.ToBase64String(hash);
            }

            /// <summary>
            /// Validates a password given a hash of the correct one.
            /// </summary>
            /// <param name="password">The password to check.</param>
            /// <param name="correctHash">A hash of the correct password.</param>
            /// <returns>True if the password is correct. False otherwise.</returns>
            public static bool ValidatePassword(string password, string correctHash)
            {
                // Extract the parameters from the hash
                char[] delimiter = { ':' };
                try
                {
                    string[] split = correctHash.Split(delimiter);
                    int iterations = Int32.Parse(split[ITERATION_INDEX]);
                    byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
                    byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

                    byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
                    return SlowEquals(hash, testHash);
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// Compares two byte arrays in length-constant time. This comparison
            /// method is used so that password hashes cannot be extracted from
            /// on-line systems using a timing attack and then attacked off-line.
            /// </summary>
            /// <param name="a">The first byte array.</param>
            /// <param name="b">The second byte array.</param>
            /// <returns>True if both byte arrays are equal. False otherwise.</returns>
            private static bool SlowEquals(byte[] a, byte[] b)
            {
                uint diff = (uint)a.Length ^ (uint)b.Length;
                for (int i = 0; i < a.Length && i < b.Length; i++)
                    diff |= (uint)(a[i] ^ b[i]);
                return diff == 0;
            }

            /// <summary>
            /// Computes the PBKDF2-SHA1 hash of a password.
            /// </summary>
            /// <param name="password">The password to hash.</param>
            /// <param name="salt">The salt.</param>
            /// <param name="iterations">The PBKDF2 iteration count.</param>
            /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
            /// <returns>A hash of the password.</returns>
            private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
            {
                using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt))
                {
                    pbkdf2.IterationCount = iterations;
                    return pbkdf2.GetBytes(outputBytes);
                }
            }
        }

		public class Encryption
		{
			#region Constructor
			public Encryption()
			{
			}
			#endregion

			#region Methods
            public string sha256(string password)
            {
                SHA256Managed crypt = new SHA256Managed();
                string hash = String.Empty;
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                foreach (byte bit in crypto)
                {
                    hash += bit.ToString("x2");
                }
                return hash;
            }


            public bool DecryptRegisterKeys(string ValidationKey, out System.DateTime regDate)
            {
                regDate = System.DateTime.Now;
                System.Text.StringBuilder strDecrypt = new System.Text.StringBuilder();
                string strMyKeys;
                char myCodeDecrypt;
                int[] SecretCode = new int[] { 7, 10, 5, 14, 20, 3, 11, 9, 25 };
                string STR_CNN_FILE = "ZFKey.key";
                string strTgl = "00000000", strDecryptedValidationKey = string.Empty;
                bool retVal = false;
                
                try
                {
                    using (System.IO.FileStream file = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + @"\" + STR_CNN_FILE, System.IO.FileMode.Open))
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
                        {
                            strMyKeys = reader.ReadLine();
                            reader.Close();
                            file.Close();

                            for (int i = 0, idxPjg = strTgl.Length, idxCode = 0, pjgIdxCode = 9; i < idxPjg; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyKeys[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            strTgl = strDecrypt.ToString();

                            try
                            {
                                int iYear, iMonth, iDate;

                                iYear = int.Parse(strTgl.Substring(0, 4));
                                iMonth = int.Parse(strTgl.Substring(4, 2));
                                iDate = int.Parse(strTgl.Substring(6, 2));

                                regDate = new System.DateTime(iYear, iMonth, iDate);
                            }
                            catch
                            {
                                regDate = System.DateTime.Now;
                            }

                            strDecrypt = null;
                            strDecrypt = new System.Text.StringBuilder();
                            for (int i = strTgl.Length, idxPjg = strMyKeys.Length, idxCode = 0, pjgIdxCode = 9; i < idxPjg; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyKeys[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            strDecryptedValidationKey = strDecrypt.ToString();
                        }
                    }
                    retVal = (strDecryptedValidationKey == ValidationKey);
                }
                catch
                {
                    retVal = false;
                }

                strDecrypt = null;
                SecretCode = null;
                return retVal; 
            }

            public bool DecryptConnString(out string Title, out string ConnectionString, out string KdCabang, out string warehousePenjualan, out string PrinterName, out string sqlServiceName)
            {
                ConnectionString = Title = KdCabang = warehousePenjualan = PrinterName = sqlServiceName = string.Empty;
                System.Text.StringBuilder strDecrypt = new System.Text.StringBuilder();
                string strMyConnString;
                char myCodeDecrypt;
                int[] SecretCode = new int[] { 20, 8, 18, 6, 16, 4 };
                string STR_CNN_FILE = "CnnString.cnn";

                try
                {
                    using (System.IO.FileStream file = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + @"\" + STR_CNN_FILE, System.IO.FileMode.Open))
                    {
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
                        {
                            strMyConnString = reader.ReadLine();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            Title = strDecrypt.ToString();

                            #region Connection String
                            strDecrypt = new System.Text.StringBuilder();
                            strMyConnString = reader.ReadLine();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            ConnectionString = strDecrypt.ToString();
                            #endregion

                            #region Kode Cabang
                            strDecrypt = new System.Text.StringBuilder();
                            strMyConnString = reader.ReadLine();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            KdCabang = strDecrypt.ToString();
                            #endregion

                            #region Warehouse Penjualan Default
                            strDecrypt = new System.Text.StringBuilder();
                            strMyConnString = reader.ReadLine();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            warehousePenjualan = strDecrypt.ToString();
                            #endregion

                            #region Printer Name
                            strDecrypt = new System.Text.StringBuilder();
                            strMyConnString = reader.ReadLine();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            PrinterName = strDecrypt.ToString();
                            #endregion

                            #region SQL Server Service Name
                            strDecrypt = new System.Text.StringBuilder();
                            strMyConnString = reader.ReadLine();
                            reader.Close();
                            file.Close();

                            for (int i = 0, pjgConnString = strMyConnString.Length, idxCode = 0, pjgIdxCode = 6; i < pjgConnString; i++)
                            {
                                myCodeDecrypt = (char)((int)((char)strMyConnString[i]) - SecretCode[idxCode++]);
                                if (idxCode >= pjgIdxCode)
                                    idxCode = 0;
                                strDecrypt.Append(myCodeDecrypt);
                            }
                            sqlServiceName = strDecrypt.ToString();
                            #endregion
                        }
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    strDecrypt = null;
                    SecretCode = null;
                }

                return true;
            }

			public string Encrypt(string userID, string password)
			{
				if(userID.Trim().Length == 0 || password.Trim().Length == 0)
					throw new System.ArgumentNullException("paramNULL", "Invalid User ID or password!");
				int encryptor = userID.Length + password.Length;
				string passwordResult = string.Empty;
				System.Text.StringBuilder passwordBuilder = new System.Text.StringBuilder();
				byte tempBit = 0;
				System.Text.UTF8Encoding encode = new System.Text.UTF8Encoding();
			
				byte[] byteEncode = encode.GetBytes(password);
			
				for(int bitEncode=byteEncode.Length-1; bitEncode>0; bitEncode--)
				{
					tempBit = (byte)(byteEncode[bitEncode] - encryptor - bitEncode);
					passwordBuilder.AppendFormat(tempBit.ToString());
					passwordBuilder.AppendFormat(" ");
				}
				tempBit = (byte)(byteEncode[0] - encryptor);
				passwordBuilder.AppendFormat(tempBit.ToString());

				passwordResult = passwordBuilder.ToString();

                passwordBuilder = null;
                encode = null;
                byteEncode = null;

                return passwordResult;
			}

			public string Decrypt(string userID, string password)
			{
				if(userID.Trim().Length == 0 || password.Trim().Length == 0)
					throw new System.ArgumentNullException("paramNULL", "Invalid User ID or password!");
				int decryptor = userID.Length + password.Length;
                List<byte> arrList = new List<byte>();
				string passwordResult = string.Empty;
				System.Text.StringBuilder passwordBuilder = new System.Text.StringBuilder();
				byte tempBit = 0, counter=0;
				System.Text.UTF8Encoding encode = new System.Text.UTF8Encoding();
			
				string[] temppassword = password.Split(' ');
			
				for(int str=temppassword.Length-1; str>=0; str--)
				{
					tempBit = (byte)(byte.Parse( temppassword[str] ) + decryptor + counter++);
					arrList.Add(tempBit);
				}

                byte[] byteDecode = arrList.ToArray();
                    //(byte[]) arrList.ToArray(typeof(byte));
				passwordResult = encode.GetString(byteDecode);

                arrList = null;
                passwordBuilder = null;
                encode = null;
                temppassword = null;
                byteDecode = null;

				return passwordResult;
			}
			#endregion
		}
	}
}
