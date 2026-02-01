using System.Collections.Generic;
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

        private bool _isActive = false;

        private readonly List<DialogueOptionButtonUI> _currentOptions = new List<DialogueOptionButtonUI>();

        public void Initialize(NPCBehavior npc)
        {
            //If we are currently active, do nothing
            if (_isActive)
            {
                return;
            }
            
            //Clear the existing options
            foreach (var option in _currentOptions)
            {
                Destroy(option.gameObject);
            }
            _currentOptions.Clear();
            
            gameObject.SetActive(true);
            _isActive = true;
            foreach (var dialogueChoice in npc.Config.DialogueConfig.DialogueChoices)
            {
                var button = Instantiate(_buttonPrefab, _buttonParent);
                _currentOptions.Add(button);
                button.Initialize(dialogueChoice, _playerData);
                button.OnSelect += CloseUI;
                button.OnSelect += npc.FinishTalkingTo;
            }
        }

        public void CloseUI()
        {
            gameObject.SetActive(false);
            _isActive = false;
        }
    }
}