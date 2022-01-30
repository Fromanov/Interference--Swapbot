using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public SpriteRenderer boxR;
    public Sprite spriteD;
    public Sprite spriteAnotherDimension;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeSpriteSet();
        }
    }

    void ChangeSpriteSet()
    {
        if(gameManager.isAnotherDimension)
        {
            boxR.sprite = spriteD;
        }
        else
        {
            boxR.sprite = spriteAnotherDimension;
        }
    }
}
