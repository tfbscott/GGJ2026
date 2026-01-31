using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DialogueOptionButtonUI : UIBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _text;
        
        public void Initialize(DialogueConfig.DialogueChoice choice)
        {
            _text.text = choice.Dialogue.GetLocalizedString();
        }
    }
}