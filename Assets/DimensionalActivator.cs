using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionalActivator : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeBoxActivity();
        }
    }

    void ChangeBoxActivity()
    {
        if(gameManager.isAnotherDimension)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
