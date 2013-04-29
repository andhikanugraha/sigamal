using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace SiGamalEngine
{
    class SiGamalGenerator
    {
        // http://en.wikipedia.org/wiki/Extended_Euclidean_algorithm#Iterative_method_2
        public static BigInteger inverse(BigInteger n, BigInteger m)
        {
            BigInteger quotient;
            BigInteger temp1;
            BigInteger temp2;

            BigInteger a = n;
            BigInteger b = m;
            BigInteger x = 0;
            BigInteger y = 1;
            BigInteger _x = 1;
            BigInteger _y = 0;

            for (; b != 0; )
            {
                quotient = a / b;
                temp1 = b;
                temp2 = a % b;
                a = temp1;
                b = temp2;
                temp1 = _x - quotient * x;
                temp2 = x;
                x = temp1;
                _x = temp2;
                temp1 = _y - quotient * y;
                temp2 = y;
                y = temp1;
                _y = temp2;
            }

            if (_x <= 0)
            {
                _x += m;
            }

            return _x;
        }

        // http://en.wikipedia.org/wiki/ElGamal_signature_scheme#Signature_generation
        // k udah dapet dari generator. bisa kalo mau disini, tapi ntar harus disimpen
        // p prima yang udah bisa diambil dari generator
        // g bisa diambil dari kunci publik
        // x kunci privat
        // Hash itu BigInteger dari SHA
        public static string signature(
            BigInteger p,
            BigInteger g,
            BigInteger x,
            BigInteger Hash)
        {
            BigInteger k = 2;
            BigInteger r = 0;
            BigInteger s = 0;
            System.Diagnostics.Debug.WriteLine("DAMN");
            for (; s == 0; )
            {
                // http://stackoverflow.com/questions/2965707/c-sharp-a-random-bigint-generator
                for (; BigInteger.GreatestCommonDivisor(k, (p - 1)) != 1; )
                {
                    System.Diagnostics.Debug.WriteLine("DAMN-1");
                    var rng = new RNGCryptoServiceProvider();
                    byte[] bytes = new byte[32];
                    rng.GetBytes(bytes);
                    k = new BigInteger(bytes);
                    if (k < 0) k *= -1;
                    k %= (p - 1);
                }

                r = BigInteger.ModPow(g, k, p);
                s = ((Hash - x * r) * inverse(k, p - 1)) % (p - 1);
                //System.Windows.Forms.MessageBox.Show(s.ToString());
                if (s < 0)
                    s = (p - 1) + s;

                //System.Windows.Forms.MessageBox.Show(s.ToString());
            }

            return r.ToString("X") + "-" + s.ToString("X"); // r dan s dikembalikan dalam bentuk "X"/hexadesimal
        }

        // http://en.wikipedia.org/wiki/ElGamal_signature_scheme#Verification
        // r dan s itu hasil dari signature, angka yang mau dicek
        //     kalo nerima string abis itu diparsing jadi r dan s, gimana ya?
        // p, g, ama y bisa diambil dari kunci publik
        // Hash itu BigInteger dari SHA
        public static bool verification(
            BigInteger r,
            BigInteger s,
            BigInteger g,
            BigInteger Hash,
            BigInteger y,
            BigInteger p)
        {
            //System.Windows.Forms.MessageBox.Show(BigInteger.ModPow(g, Hash, p) + "\n" + ((BigInteger.ModPow(y, r, p) * BigInteger.ModPow(r, s, p)) % p) + "\n" + "Hash=" + Hash.ToString() + "," + r + "," + s);
            //System.Windows.Forms.MessageBox.Show(BigInteger.ModPow(g, Hash, p).ToString());
            //System.Windows.Forms.MessageBox.Show(((BigInteger.ModPow(y, r, p) * BigInteger.ModPow(r, s, p)) % p).ToString());
            return
                0 < r && r < p &&
                0 < s && s < p - 1 &&
                BigInteger.ModPow(g, Hash, p) == (BigInteger.ModPow(y, r, p) * BigInteger.ModPow(r, s, p)) % p;
        }
    }
}
