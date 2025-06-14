using System.Collections.Generic;
using Sirenix.OdinInspector;


namespace Game.App
{
    public class GameSaveLoader
    {
        private readonly IGameRepository _repository;
        private readonly IEnumerable<IGameSerializer> _serializers;

        public GameSaveLoader(IGameRepository repository, IEnumerable<IGameSerializer> serializers)
        {
            _repository = repository;
            _serializers = serializers;
        }

        [Button]
        public void Save()
        {
            var gameState = new Dictionary<string, string>();

            foreach (var serializer in _serializers)
            {
                serializer.Serialize(gameState);
            }

            _repository.SetState(gameState);
        }

        [Button]
        public void Load()
        {
            var gameState = _repository.GetState();

            foreach (var serializer in _serializers)
            {
                serializer.Deserialize(gameState);
            }
        }
    }
}