using Modules.Layers;
using Modules.Player;
using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player character;

        [SerializeField] private BulletManager bulletManager;

        [SerializeField] private InputListener inputListener;

       
        private float moveDirection;

        private void Awake()
        {
            this.character.OnHealthEmpty += _ => Time.timeScale = 0;
        }


        private void OnEnable()
        {
            inputListener.OnFirePressed += OnFirePressedHandler;
            inputListener.OnLeftPressed += OnLeftPressedHandler;
            inputListener.OnRightPressed += OnRightPressedHandler;

            character.OnBulletRequired += SpawnBullet;
        }

        private void OnFirePressedHandler()
        {
            character.Fire();
        }

        private void OnLeftPressedHandler()
        {
            character.Move(Vector2.left);
        }

        private void OnRightPressedHandler()
        {
            character.Move(Vector2.right);
        }


        private void SpawnBullet(Transform firePoint)
        {
            bulletManager.SpawnBullet(
                firePoint.position,
                Color.blue,
                (int)PhysicsLayer.PlayerBullet,
                1,
                true,
                firePoint.rotation * Vector3.up * 3
            );
        }

        private void OnDisable()
        {
            inputListener.OnFirePressed -= OnFirePressedHandler;
            inputListener.OnLeftPressed -= OnLeftPressedHandler;
            inputListener.OnRightPressed -= OnRightPressedHandler;
            
            character.OnBulletRequired -= SpawnBullet;
        }
    }
}