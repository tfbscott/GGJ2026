using Configs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class NPCDialogueUI : UIBehaviour
    {
        [SerializeField] 
        private RectTransform _buttonParent;

        [SerializeField] 
        private DialogueOptionButtonUI _buttonPrefab;

        public void Initialize(DialogueConfig config)
        {
            foreach (var dialogueChoice in config.DialogueChoices)
            {
                var button = Instantiate(_buttonPrefab, _buttonParent);
                button.Initialize(dialogueChoice);
            }
        }
    }
}