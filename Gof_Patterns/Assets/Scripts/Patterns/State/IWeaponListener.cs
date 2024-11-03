namespace Patterns.State
{
    public interface IWeaponListener
    {
        void OnWeaponChanged(WeaponType weaponType);
    }
}