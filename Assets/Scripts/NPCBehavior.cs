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

    private void Start()
    {
        _renderer.sprite = _config.GetNPCSprite();

        StartCoroutine(DebugTest());
    }


    public void DisplayGossip()
    {
        
    }
    
    public void DisplayDialogueInterface()
    {
        _dialogueUI.gameObject.SetActive(true);
        _dialogueUI.Initialize(_config.DialogueConfig);
    }

    private IEnumerator DebugTest()
    {
        yield return new WaitForSeconds(1.5f);
        DisplayGossip();
        yield return new WaitForSeconds(1.5f);
        DisplayDialogueInterface();
    }
}
