using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "ArtConfig", menuName = "Configs/ArtConfig")]
    public class ArtConfig : ScriptableObject
    {
        [SerializeField] 
        private Sprite _idleSprite;
    }
}