using System;
using System.Collections;
using Configs;
using UI;
using UnityEngine;


public class NPCBehavior : MonoBehaviour
{
    [SerializeField] 
    private NPCConfig _config;

    [SerializeField] 
    private SpriteRenderer _renderer;
    
    [SerializeField]
    private NPCDialogueUI _dialogueUI;

    private bool _hasBeenTalkedTo = false;
    public bool HasBeenTalkedTo => _hasBeenTalkedTo;

    private void Start()
    {
        _renderer.sprite = _config.GetNPCSprite();
        _hasBeenTalkedTo = false;
    }


    public void DisplayGossip()
    {
        
    }
    
    public void DisplayDialogueInterface()
    {
        _dialogueUI.Initialize(_config.DialogueConfig);
        _hasBeenTalkedTo = true;
    }

    public void CloseDialogueInterface()
    {
        _dialogueUI.CloseUI();
    }

    public int GetRep()
    {
        return _config.GetStatus();
    }
}
