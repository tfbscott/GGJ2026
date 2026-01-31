using Configs;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "NPCConfig", menuName = "Configs/NPCConfig")]
    public class NPCConfig : ScriptableObject
    {
        [SerializeField] 
        private DialogueConfig _dialogueConfig;
        public DialogueConfig DialogueConfig => _dialogueConfig;

        [SerializeField] 
        private ArtConfig _artConfig;

        [SerializeField] 
        private int _requiredStatus;

        [SerializeField] 
        private Color _npcColor;

        public Sprite GetNPCSprite()
        {
            return _artConfig.IdleSprite;
        }
    }
}
