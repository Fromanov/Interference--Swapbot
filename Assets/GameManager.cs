using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float dimesionTransitionTimer = 0.5f;
    public bool isAnotherDimension = false;

    [Header("Tile set")]
    public GameObject tilesetOurDimension;
    public GameObject tilesetAnotherDimension;
    public GameObject backgroundOurDimension;
    public GameObject backgroundAnotherDimension;

    [Header("Level set")]
    public GameObject playerPrefab;
    public GameObject spawnPoint;
    public GameObject endLevel;

    public Animator playerAnimator;

    private void Awake()
    {
        PlayerRespawn();
    }

    private void Start()
    {
        playerAnimator = GameObject.Find("Player(Clone)").GetComponentInChildren<Animator>();
        ChangeTileSet();
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
        tilesetOurDimension.SetActive(!isAnotherDimension);
        tilesetAnotherDimension.SetActive(isAnotherDimension);

        backgroundOurDimension.SetActive(!isAnotherDimension);
        backgroundAnotherDimension.SetActive(isAnotherDimension);

        playerAnimator.SetBool("isAnotherDim", isAnotherDimension);
    }

    public void PlayerRespawn()
    {
        Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    public void ChangeLevel(int sceneNumber)
    {
        string sceneName = (SceneManager.GetActiveScene().name); 
        sceneName = sceneName.Substring(0, sceneName.Length - 1); 

        SceneManager.LoadScene(sceneName + sceneNumber.ToString());
    }
}
