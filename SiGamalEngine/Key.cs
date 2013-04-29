using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace SiGamalEngine
{
    public class Key
    {
        BigInteger p, g, x;

        public Key(BigInteger _p, BigInteger _g, BigInteger _x)
        {
            p = _p;
            g = _g;
            x = _x;
        }

        public static BigInteger ExpMod(BigInteger value, BigInteger exp, BigInteger mod)
        {
            BigInteger ullResult = 1;
            BigInteger ullValue = value;

            while (exp > 0)
            {
                if (exp % 2 != 0)
                { // odd
                    ullResult *= ullValue;
                    ullResult %= mod;
                }

                ullValue *= ullValue;
                ullValue %= mod;
                exp /= 2;
            }
            return (ullResult);
        }

        static public bool IsMillerRabinPrime(BigInteger prime)
        {
            // randomWitness = witness that the "prime" is NOT composite
            // 1 < randomWitness < prime-1
            long totalWitness = 15;
            BigInteger[] randomWitness = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 51001, 351011 };
            BigInteger primeMinusOne = prime - 1;
            BigInteger oddMultiplier;
            long bitLength;
            long i, j;
            BigInteger result;
            // find oddMultiplier, defined as "prime - 1 = (2^B) * M"
            // get bitLength (B) and find the oddMultiplier (M)

            // init value multiplier
            oddMultiplier = primeMinusOne;

            bitLength = 0; // reset
            while (oddMultiplier % 2 == 0)
            {
                oddMultiplier /= 2;
                bitLength++;
            }
            for (i = 0; i < totalWitness; i++)
            {
                if (randomWitness[i] == prime)
                    return true;

                // init value of result = (randomWitness ^ oddMultiplier) mod prime
                result = ExpMod(randomWitness[i], oddMultiplier, prime);

                // is y = 1 ?
                if (result == 1)
                    continue; // maybe prime

                // is y = prime-1 ?
                if (result == primeMinusOne)
                    continue; // maybe prime

                // loop to get AT LEAST one "result = primeMinusOne"
                for (j = 1; j <= bitLength; j++)
                {
                    // square of result
                    result = ExpMod(result, 2, prime);

                    // is result = primeMinusOne ?
                    if (result == primeMinusOne)
                        break; // maybe prime
                }

                if (result != primeMinusOne)
                    return false; // COMPOSITE
            }

            // it may be pseudoprime/prime
            return true;
        }


        public static Key GenerateRandomKey()
        {
            Key key = null;
            BigInteger p = 10, g, x;
            byte[] bytes;
            var rng = new RNGCryptoServiceProvider();
            while (!IsMillerRabinPrime(p))
            {
                rng = new RNGCryptoServiceProvider();
                bytes = new byte[33];
                rng.GetBytes(bytes);

                p = new BigInteger(bytes);
                if (p < 0)
                {
                    p *= -1;
                }
            }

            rng = new RNGCryptoServiceProvider();
            bytes = new byte[32];
            rng.GetBytes(bytes);

            g = new BigInteger(bytes);

            if (g < 0)
            {
                g *= -1;
            }
            g %= p;
            rng.GetBytes(bytes);

            x = new BigInteger(bytes);

            if (x < 0)
            {
                x *= -1;
            }
            x %= (p - 1);
            key = new Key(p, g, x);

            return key;
        }

        public PublicKey GeneratePublicKey()
        {
            PublicKey key = new PublicKey();
            key.G = g;
            key.P = p;
            key.Y = BigInteger.ModPow(g, x, p);// modular_pow(g, x, p);
            return key;
        }

        public PrivateKey GeneratePrivateKey()
        {
            PrivateKey key = new PrivateKey();
            key.X = x;
            key.G = g;
            key.P = p;
            return key;
        }

        public static void SaveToFile(string fileName, PublicKey key)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            byte[] byte_toWrite = Encoding.ASCII.GetBytes(key.Y.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)',');

            byte_toWrite = Encoding.ASCII.GetBytes(key.G.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)',');

            byte_toWrite = Encoding.ASCII.GetBytes(key.P.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)'\n');
            fs.Close();
        }

        public static PublicKey GeneratePublicKeyFromFile(string fileName)
        {
            PublicKey key = new PublicKey();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            key.Y = GetElement(fs);
            key.G = GetElement(fs);
            key.P = GetElement(fs);

            return key;
        }

        public static void SaveToFile(string fileName, PrivateKey key)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            Console.WriteLine(key.X);
            byte[] byte_toWrite = Encoding.ASCII.GetBytes(key.X.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)',');

            byte_toWrite = Encoding.ASCII.GetBytes(key.G.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)',');

            byte_toWrite = Encoding.ASCII.GetBytes(key.P.ToString()).ToArray();

            fs.Write(byte_toWrite, 0, byte_toWrite.Count());
            fs.WriteByte((byte)'\n');
            fs.Close();
        }

        public void saveToFile(string fileName)
        {

            Key.SaveToFile(fileName + ".pub", this.GeneratePublicKey());
            Key.SaveToFile(fileName + ".pri", this.GeneratePrivateKey());
        }

        public static PrivateKey GeneratePrivateKeyFromFile(string fileName)
        {
            PrivateKey key = new PrivateKey();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            key.X = GetElement(fs);
            key.G = GetElement(fs);
            key.P = GetElement(fs);

            return key;
        }

        private static BigInteger GetElement(FileStream fs)
        {
            List<byte> bytes_toRead = new List<byte>();

            int read = fs.ReadByte();
            while (read != -1 && read != (int)',' && read != (int)'\n')
            {
                bytes_toRead.Add((byte)read);
                read = fs.ReadByte();
            }
            string number_string = Encoding.ASCII.GetString(bytes_toRead.ToArray());

            return BigInteger.Parse(number_string);
        }

        private BigInteger modular_pow(BigInteger _base, BigInteger exp, BigInteger modulus)
        {
            BigInteger c = 1;
            for (int i = 1; i < exp + 1; i++)
            {
                c = (c * _base) % modulus;
            }

            return c;
        }

        #region public key
        public class PublicKey
        {
            private BigInteger g, y, p;

            public PublicKey()
            {

            }

            public BigInteger Y
            {
                get { return y; }
                set { y = value; }
            }

            public BigInteger G
            {
                get { return g; }
                set { g = value; }
            }

            public BigInteger P
            {
                set { p = value; }
                get { return p; }
            }
        }
        #endregion

        #region private key
        public class PrivateKey
        {
            BigInteger x, p, g;

            public PrivateKey()
            {

            }

            public BigInteger X
            {
                set { x = value; }
                get { return x; }
            }

            public BigInteger P
            {
                set { p = value; }
                get { return p; }
            }

            public BigInteger G
            {
                set { g = value; }
                get { return g; }
            }
        }
        #endregion
    }
}
