using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Localization;

namespace Configs
{
    [CreateAssetMenu(fileName = "DialogueConfig", menuName = "Configs/DialogueConfig")]
    public class DialogueConfig : ScriptableObject
    {
        [SerializeField] 
        private List<LocalizedString> _gossipDialogues;
        public List<LocalizedString> GossipDialogues => _gossipDialogues;
        
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
        public List<DialogueChoice> DialogueChoices => _dialogueChoices.OrderBy(i => Guid.NewGuid()).ToList();
    }
}