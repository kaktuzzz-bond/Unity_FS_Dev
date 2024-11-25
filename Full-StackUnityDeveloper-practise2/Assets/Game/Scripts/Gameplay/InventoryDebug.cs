using Modules.Inventories;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SampleGame
{
    //Нельзя менять!
    public sealed class InventoryDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector, HideInEditorMode]
        private Inventory inventory;

        [Inject]
        [ShowInInspector, HideInEditorMode]
        private InventoryItemConsumer itemConsumer;

        private void OnEnable()
        {
            this.itemConsumer.OnItemConsumed += this.OnItemConsumed;
        }

        private void OnDisable()
        {
            this.itemConsumer.OnItemConsumed -= this.OnItemConsumed;
        }

        private void OnItemConsumed(InventoryItem item)
        {
            Debug.Log($"<color=green>{item.Title}</color> activated!");
        }
    }
}