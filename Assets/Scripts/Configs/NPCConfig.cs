using Configs;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(fileName = "NPCConfig", menuName = "Configs/NPCConfig")]
    public class NPCConfig : ScriptableObject
    {
        [SerializeField] 
        private LocalizedString _npcName;
        public string Name => _npcName.GetLocalizedString();
        
        [SerializeField] 
        private DialogueConfig _dialogueConfig;
        public DialogueConfig DialogueConfig => _dialogueConfig;

        [SerializeField] 
        private int _minimumStatus;

        [SerializeField] 
        private Color _npcColor;

        public int GetStatus()
        {
            return _minimumStatus;
        }
    }
}
