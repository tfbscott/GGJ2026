using System.Collections.Generic;
using Configs;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Localization;

namespace UI
{
    public class NPCDialogueUI : UIBehaviour
    {
        [SerializeField] 
        private LocalizedString _openingLine;

        [SerializeField] 
        private TextMeshProUGUI _openingText;

        [SerializeField] 
        private LocalizedString _npcOpeningLine;
        
        [SerializeField]
        private TextMeshProUGUI _npcOpeningText;

        [SerializeField] 
        private TextMeshProUGUI _npcResponseText;
        
        [SerializeField] 
        private RectTransform _buttonParent;

        [SerializeField] 
        private GameObject _playerLetter;

        [SerializeField] 
        private GameObject _npcLetter;

        [SerializeField] 
        private DialogueOptionButtonUI _buttonPrefab;
        
        [SerializeField]
        private PlayerDataBehavior _playerData;

        private bool _isActive = false;

        private NPCBehavior _currentNPC;
        private bool _preventTalkingTo;

        private readonly List<DialogueOptionButtonUI> _currentOptions = new List<DialogueOptionButtonUI>();

        private PlayerInputActions _inputActions;
        
        protected override void Awake()
        {
            _inputActions = new PlayerInputActions();
        
            _inputActions.Player.Interact.started += OnInteract;
        }

        protected override void OnEnable()
        {
            _inputActions.Player.Enable();
        }
        
        protected override void OnDisable()
        {
            _inputActions.Player.Disable();
        }

        private void OnInteract(InputAction.CallbackContext obj)
        {
            if (_isActive && _npcLetter.activeInHierarchy)
            {
                _currentNPC.FinishTalkingTo(_preventTalkingTo);
                CloseUI();
            }
        }

        public void Initialize(NPCBehavior npc)
        {
            //If we are currently active, do nothing
            if (_isActive)
            {
                return;
            }

            _currentNPC = npc;
            
            _playerLetter.SetActive(true);
            _npcLetter.SetActive(false);

            _openingText.text = _openingLine.GetLocalizedString() + npc.Config.Name;
            _npcOpeningText.text = _npcOpeningLine.GetLocalizedString();
            
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
                button.OnSelect += () =>
                {
                    _npcResponseText.text = dialogueChoice.Response.GetLocalizedString();
                };
                button.OnSelect += ProgressUI;
                //If this is the positive choice dont let them talk again
                button.OnSelect += () => { _preventTalkingTo = dialogueChoice.StatusChange > 0; };
                
            }
        }

        public void ProgressUI()
        {
            _playerLetter.SetActive(false);
            _npcLetter.SetActive(true);
        }

        public void CloseUI()
        {
            gameObject.SetActive(false);
            _isActive = false;
        }
    }
}