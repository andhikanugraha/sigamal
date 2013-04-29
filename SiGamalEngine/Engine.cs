using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SiGamalEngine
{
    public class Engine
    {
        /// <summary>
        /// Verify the authenticity and integrity of a string which contains a message
        /// along with its signature.
        /// </summary>
        /// <param name="signedMessage">A string containing a message and its signature</param>
        /// <returns>True if the signature matches, false if it doesn't.</returns>
        public static bool VerifySignedMessage(string signedMessage, string p, string g, string y)
        {
            string body = signedMessage.Substring(0, signedMessage.IndexOf("\n\n<sign>")).Trim();
            
            string rs = signedMessage.Substring(signedMessage.IndexOf("<sign>"));
            rs = rs.Substring(6);
            rs = rs.Substring(0, rs.IndexOf("<sign>"));

            BigInteger r = BigInteger.Parse("0" + rs.Substring(0, rs.IndexOf('-')), System.Globalization.NumberStyles.HexNumber);
            BigInteger s = BigInteger.Parse("0" + rs.Substring(rs.IndexOf('-') + 1), System.Globalization.NumberStyles.HexNumber);


            System.Diagnostics.Debug.WriteLine(r);

            System.Diagnostics.Debug.WriteLine(s);

            SHA256 sha = new SHA256();

            bool isValid = SiGamalGenerator.verification(r, s, BigInteger.Parse(g), sha.GetMessageDigestToBigInteger(body), BigInteger.Parse(y), BigInteger.Parse(p));

            return isValid;
        }

        /// <summary>
        /// Sign an unsigned message.
        /// </summary>
        /// <param name="unsignedMessage"></param>
        /// <returns></returns>
        public static string SignMessage(string unsignedMessage, string signature)
        {
            unsignedMessage = unsignedMessage.Trim();

            string signedMessage = unsignedMessage + "\n\n<sign>" + signature + "<sign>";

            return signedMessage;
        }

        public static string GetSignature(string unsignedMessage, string p, string g, string x)
        {
            // Trim message
            unsignedMessage = unsignedMessage.Trim();

            var sha = new SHA256();
            BigInteger hash = sha.GetMessageDigestToBigInteger(unsignedMessage);
            string signature = SiGamalGenerator.signature(BigInteger.Parse(p), BigInteger.Parse(g), BigInteger.Parse(x), hash);

            return signature;
        }
    }
}
