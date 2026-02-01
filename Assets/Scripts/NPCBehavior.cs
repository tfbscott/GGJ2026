using System;
using System.Collections;
using Configs;
using UI;
using UnityEngine;


public class NPCBehavior : MonoBehaviour
{
    [SerializeField] 
    private NPCConfig _config;
    public NPCConfig Config => _config;

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
        _dialogueUI.Initialize(this);
    }

    public void CloseDialogueInterface()
    {
        _dialogueUI.CloseUI();
    }

    public void FinishTalkingTo()
    {
        _hasBeenTalkedTo = true;
    }

    public int GetRep()
    {
        return _config.GetStatus();
    }
}
