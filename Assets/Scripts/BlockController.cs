using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    LevelController level;
    [SerializeField] GameObject ImpactEffect;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] sprites;
    [SerializeField] int Hits = 0;
    [SerializeField] Sprite[] hitSprites;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Hits = Hits + 1;



        if (tag == "Breakable")
        {

            if (Hits >= maxHits)
                DestroyBlock();
            else
            {
                ShowNextSprite();
            }        }
        

    }

    private void DestroyBlock()
    {
        level.DestroyBlock();
        var gameStatus = FindObjectOfType<GameStatusController>();
        gameStatus.ScoreCalculator();
        Destroy(gameObject);
        TriggerEffect();
    }


    private void ShowNextSprite()
    {

        GetComponent<SpriteRenderer>().sprite = hitSprites[Hits - 1];

    }

    private void TriggerEffect()
    {
        Instantiate(ImpactEffect, transform.position, transform.rotation);
    }

    private void Start()
    {
        level = FindObjectOfType<LevelController>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlock();
        }
        
    }
}

 