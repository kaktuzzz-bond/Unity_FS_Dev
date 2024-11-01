using UnityEngine.TextCore.Text;

namespace Patterns.Builder
{
    public class CharacterBuilder
    {
        private string _name;
        private int _age;
        private GenderType _gender;


        public CharacterBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public CharacterBuilder SetAge(int age)
        {
            _age = age;
            return this;
        }

        public CharacterBuilder SetGender(GenderType gender)
        {
            _gender = gender;
            return this;
        }

        public Character Build()
        {
            return new Character(_name, _age, _gender);
        }
    }

    public class Character
    {
        private string _name;
        private readonly int _age;
        private readonly GenderType _gender;

        public Character(string name, int age, GenderType gender)
        {
            _name = name;
            _age = age;
            _gender = gender;
        }
    }

    public enum GenderType
    {
        Male,
        Female,
        Other
    }
}