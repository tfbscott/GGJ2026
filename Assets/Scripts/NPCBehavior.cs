using System;
using Configs;
using UnityEngine;


public class NPCBehavior : MonoBehaviour
{
    [SerializeField] 
    private NPCConfig _config;

    [SerializeField] 
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer.sprite = _config.GetNPCSprite();
    }
}
