using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public float dimesionTransitionTimer = 0.5f;
    public bool isAnotherDimension = false;

    public GameObject tilesetOurDimension;
    public GameObject tilesetAnotherDimension;

    public GameObject backgroundOurDimension;
    public GameObject backgroundAnotherDimension;

    public GameObject spawnPoint;
    public GameObject endLevel;

    public Animator playerAnimator;

    private void Start()
    {
        tilesetOurDimension.SetActive(true);
        tilesetAnotherDimension.SetActive(false);

        backgroundOurDimension.SetActive(true);
        backgroundAnotherDimension.SetActive(false);

        playerAnimator.SetBool("isAnotherDim", false);
    }
    void Update()
    {
        if (dimesionTransitionTimer > 0)
            dimesionTransitionTimer -= Time.deltaTime;


        if (dimesionTransitionTimer <= 0 && Input.GetKeyDown(KeyCode.Q))
        {
            dimesionTransitionTimer = 0.25f;
            isAnotherDimension = !isAnotherDimension;
            ChangeTileSet();
        }        
    }

    void ChangeTileSet() 
    {
        if(isAnotherDimension)
        {
            tilesetOurDimension.SetActive(true);
            tilesetAnotherDimension.SetActive(false);

            backgroundOurDimension.SetActive(true);
            backgroundAnotherDimension.SetActive(false);

            playerAnimator.SetBool("isAnotherDim", false);
            Debug.Log("Super");
        }
        else 
        {
            tilesetOurDimension.SetActive(false);
            tilesetAnotherDimension.SetActive(true);

            backgroundOurDimension.SetActive(false);
            backgroundAnotherDimension.SetActive(true);

            playerAnimator.SetBool("isAnotherDim", true);
            Debug.Log("Zaluper");
        }
    }
}
