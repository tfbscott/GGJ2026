using Configs;
using DefaultNamespace;
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
        
        [SerializeField]
        private PlayerDataBehavior _playerData;

        public void Initialize(DialogueConfig config)
        {
            gameObject.SetActive(true);
            foreach (var dialogueChoice in config.DialogueChoices)
            {
                var button = Instantiate(_buttonPrefab, _buttonParent);
                button.Initialize(dialogueChoice, _playerData);
                button.OnSelect += CloseUI;
            }
        }

        public void CloseUI()
        {
            gameObject.SetActive(false);
        }
    }
}