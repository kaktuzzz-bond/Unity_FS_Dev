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
        private readonly bool _useEncryption;

        public GameRepository(string filePath, string aesPassword, byte[] aesSalt, bool useEncryption)
        {
            _filePath = filePath;
            _aesPassword = aesPassword;
            _aesSalt = aesSalt;
            _useEncryption = useEncryption;
        }

        public void SetState(Dictionary<string, string> gameState)
        {
            var json = JsonConvert.SerializeObject(gameState);

            var byteArray = Encoding.UTF8.GetBytes(json);

            var bytes = _useEncryption
                ? AesEncryptor.Encrypt(byteArray, _aesPassword, _aesSalt)
                : byteArray;

            File.WriteAllBytes(_filePath, bytes);
        }

        public Dictionary<string, string> GetState()
        {
            if (!File.Exists(_filePath)) return new Dictionary<string, string>();

            var byteArray = File.ReadAllBytes(_filePath);

            var bytes = _useEncryption
                ? AesEncryptor.Decrypt(byteArray, _aesPassword, _aesSalt)
                : byteArray;

            var json = Encoding.UTF8.GetString(bytes);

            var result = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return result ?? new Dictionary<string, string>();
        }
    }
}