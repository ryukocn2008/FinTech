using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBitcoin;

namespace ProgrammingBlockchain.Chapters
{
    class Chapter1
    {
        private string pubKeyString;
        public BitcoinSecret paymentSecret;

        /**
         * Generate address and pub key, its hash from a private key.
         */
        public void Lesson1() {
            Console.WriteLine("==========Lesson 1==========");
            Key key = new Key();                    // generate a new private key
            PubKey pubKey = key.PubKey;             // gets the maching public key
            Console.WriteLine("Public Key: {0}", pubKey);

            KeyId hash = pubKey.Hash;               // gets a hash of the public key
            Console.WriteLine("Hashed public Key: {0}", hash);

            BitcoinPubKeyAddress address = pubKey.GetAddress(Network.TestNet);  // retrieves the bitcoin address
            Console.WriteLine("Address: {0}", address);

            Script scriptPubKeyFromAddress = address.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from address:\t {0}", scriptPubKeyFromAddress);

            Script scriptPubKeyFromHash = hash.ScriptPubKey;
            Console.WriteLine("ScriptPubKey from hash:\t\t {0}", scriptPubKeyFromHash);

            pubKeyString = scriptPubKeyFromAddress.ToString();

        }


        /**
         * Generate address from pub key.
         */
        public void Lesson2() {
            Lesson1();
            Console.WriteLine("\n\n\n==========Lesson 2==========");
            Script scriptPubKey = new Script(pubKeyString);
            BitcoinAddress address = scriptPubKey.GetDestinationAddress(Network.TestNet);
            Console.WriteLine("Bitcoin Address: {0}", address);
        }

        /**
         * Generate address from hash
         */
        public void Lesson3() {
            Lesson2();
            Console.WriteLine("\n\n\n==========Lesson 3==========");
            Script scriptPubKey = new Script(pubKeyString);
            KeyId hash = (KeyId)scriptPubKey.GetDestination();
            Console.WriteLine("Public Key Hash: {0}", hash);
            BitcoinAddress address = new BitcoinPubKeyAddress(hash, Network.TestNet);
            Console.WriteLine("Bitcoin Address: {0}", address);
        }

        public void Lesson4() {
            Lesson3();
            Console.WriteLine("\n\n\n==========Lesson 4==========");
            Key key = new Key();
            BitcoinSecret secret = key.GetBitcoinSecret(Network.TestNet);
            Console.WriteLine("Bitcoin Secret: {0}", secret);
            paymentSecret = secret;
        }
    }
}
