using Modules.Layers;
using Modules.Player;
using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay
{
    public sealed class BattleManager : MonoBehaviour
    {
        [SerializeField] private Player player;

        //[SerializeField] private BulletManager bulletManager;
        [SerializeField] private BulletFactory bulletFactory;
        [SerializeField] private SpaceshipFactory spaceshipFactory;

        [SerializeField] private InputListener inputListener;

       
        private float moveDirection;

        private void Awake()
        {
            bulletFactory.Initialize(10);
            player.OnHealthEmpty += _ => Time.timeScale = 0;
        }


        private void OnEnable()
        {
            inputListener.OnFirePressed += OnFirePressedHandler;
            inputListener.OnLeftPressed += OnLeftPressedHandler;
            inputListener.OnRightPressed += OnRightPressedHandler;

            player.OnBulletRequired += SpawnBullet;
        }

        private void OnFirePressedHandler()
        {
            player.Attack();
        }

        private void OnLeftPressedHandler()
        {
            player.Move(Vector2.left);
        }

        private void OnRightPressedHandler()
        {
            player.Move(Vector2.right);
        }


        private void SpawnBullet(Transform firePoint)
        {
            bulletFactory.SpawnPlayerBullet(firePoint.position, firePoint.rotation * Vector3.up * 3, 1);
        }

        private void OnDisable()
        {
            inputListener.OnFirePressed -= OnFirePressedHandler;
            inputListener.OnLeftPressed -= OnLeftPressedHandler;
            inputListener.OnRightPressed -= OnRightPressedHandler;
            
            player.OnBulletRequired -= SpawnBullet;
        }
    }
}