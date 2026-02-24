using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    public class ItemConsumer : MonoBehaviour
    {

        private void ConsumeItem(Consummable item)
        {
            Debug.Log("Consumed item: " + item.name);

        }
    }
}