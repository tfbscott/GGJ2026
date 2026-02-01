using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Configs
{
    [CreateAssetMenu(fileName = "DialogueConfig", menuName = "Configs/DialogueConfig")]
    public class DialogueConfig : ScriptableObject
    {
        [SerializeField] 
        private List<LocalizedString> _gossipDialogues;
        
        [Serializable]
        public struct DialogueChoice
        {
            public LocalizedString Dialogue;
            public LocalizedString Response;
            public int StatusChange;
            public int SuspicionChange;
        }

        [SerializeField] 
        private List<DialogueChoice> _dialogueChoices;
        public List<DialogueChoice> DialogueChoices => _dialogueChoices;
    }
}