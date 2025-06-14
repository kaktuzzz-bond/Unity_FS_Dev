using Sirenix.OdinInspector;

namespace Game.App
{
    public class ValueProvider
    {
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public int Value { get; set; }

        [Button]
        private void SetValue(int value = 333) => Value = value;
    }
}