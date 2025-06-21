using Sirenix.OdinInspector;

namespace Game.App
{
    public class ValueProvider
    {
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public int Value1 { get; set; }
        
        [ShowInInspector, ReadOnly, HideInEditorMode]
        public string Value2 { get; set; }

        [Button]
        private void SetValue1(int value = 333) => Value1 = value;
        
        [Button]
        private void SetValue2(string value = "abcde") => Value2 = value;
    }
}