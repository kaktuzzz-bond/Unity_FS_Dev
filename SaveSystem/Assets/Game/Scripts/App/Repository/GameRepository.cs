using System.Collections.Generic;
using System.IO;
using System.Text;
using Modules.Ecryption;
using Newtonsoft.Json;

namespace Game.App
{
    public class GameRepository : IGameRepository
    {
        private readonly string _filePath;
        private readonly string _aesPassword;
        private readonly byte[] _aesSalt;

        //for debug purposes
        private readonly bool _useEncryption = false;

        public GameRepository(string filePath, string aesPassword, byte[] aesSalt)
        {
            _filePath = filePath;
            _aesPassword = aesPassword;
            _aesSalt = aesSalt;
        }

        public Dictionary<string, string> GetState()
        {
            if (!File.Exists(_filePath)) return new Dictionary<string, string>();

            var byteArray = File.ReadAllBytes(_filePath);

            var bytes = _useEncryption ? Encrypt(byteArray) : byteArray;

            var json = Encoding.UTF8.GetString(bytes);

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return result ?? new Dictionary<string, string>();
        }

        public void SetState(Dictionary<string, string> gameState)
        {
            var json = JsonConvert.SerializeObject(gameState);

            var byteArray = Encoding.UTF8.GetBytes(json);

            var bytes = _useEncryption ? Decrypt(byteArray) : byteArray;
            File.WriteAllBytes(_filePath, bytes);
        }

        private byte[] Encrypt(byte[] source) => AesEncryptor.Encrypt(source, _aesPassword, _aesSalt);

        private byte[] Decrypt(byte[] source) => AesEncryptor.Decrypt(source, _aesPassword, _aesSalt);
    }
}