using System;
using Configs;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DialogueOptionButtonUI : UIBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _text;

        public event Action OnSelect;
        
        public void Initialize(DialogueConfig.DialogueChoice choice, PlayerDataBehavior playerData)
        {
            _text.text = choice.Dialogue.GetLocalizedString();
            OnSelect += () =>
            {
                playerData.UpdateValues(choice.StatusChange, choice.SuspicionChange);
            };
        }

        public void OnButtonPress()
        {
            OnSelect?.Invoke();
        }
        
    }
}