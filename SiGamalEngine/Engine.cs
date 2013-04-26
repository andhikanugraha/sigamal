using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiGamalEngine
{
    class Engine
    {
        /// <summary>
        /// Verify the authenticity and integrity of a string which contains a message
        /// along with its signature.
        /// </summary>
        /// <param name="signedMessage">A string containing a message and its signature</param>
        /// <returns>True if the signature matches, false if it doesn't.</returns>
        public bool VerifySignedMessage(string signedMessage)
        {
            return true;
        }

        /// <summary>
        /// Sign an unsigned message.
        /// </summary>
        /// <param name="unsignedMessage"></param>
        /// <returns></returns>
        public string SignMessage(string unsignedMessage, Key.PrivateKey privateKey)
        {
            return unsignedMessage;
        }
    }
}
