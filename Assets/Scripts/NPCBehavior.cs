using System;
using System.Collections;
using System.Linq;
using Configs;
using TMPro;
using UI;
using UnityEngine;
using Random = System.Random;


public class NPCBehavior : MonoBehaviour
{
    [SerializeField] 
    private NPCConfig _config;
    public NPCConfig Config => _config;

    [SerializeField] 
    private SpriteRenderer _renderer;

    [SerializeField] 
    private NPCMovement _movement;
    
    [SerializeField]
    private NPCDialogueUI _dialogueUI;

    [SerializeField] 
    private GameObject _gossipBubble;
    [SerializeField] 
    private TextMeshPro _gossipText;
    [SerializeField] 
    private int _gossipDelaySecondsMin;
    [SerializeField] 
    private int _gossipDelaySecondsMax;

    private Unity.Mathematics.Random _random;
    
    private bool _hasBeenTalkedTo = false;
    public bool HasBeenTalkedTo => _hasBeenTalkedTo;

    private void Start()
    {
        _hasBeenTalkedTo = false;

        _random = new();
        _random.InitState();

        StartCoroutine(GossipCoroutine());
    }

    

    private IEnumerator GossipCoroutine()
    {
        while (_config.DialogueConfig.GossipDialogues.Any())
        {
            int gossipDelay = _random.NextInt(_gossipDelaySecondsMin, _gossipDelaySecondsMax);
            yield return new WaitForSeconds(gossipDelay);
            
            _gossipText.text = _config.DialogueConfig.GossipDialogues[_random.NextInt(0, _config.DialogueConfig.GossipDialogues.Count)].GetLocalizedString();
            _gossipBubble.SetActive(true);
            
            yield return new WaitForSeconds(5.0f);
            _gossipBubble.SetActive(false);
        }
    }
    
    public void DisplayDialogueInterface()
    {
        _dialogueUI.Initialize(this);
        _movement.StopMoving();
        _movement.enabled = false;
    }

    public void CloseDialogueInterface()
    {
        _dialogueUI.CloseUI();
    }

    public void FinishTalkingTo(bool success)
    {
        _movement.enabled = true;
        _hasBeenTalkedTo = success;
    }

    public int GetRep()
    {
        return _config.GetStatus();
    }
}
