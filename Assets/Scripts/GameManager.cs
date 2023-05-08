using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Canvas")]
    [SerializeField] private GameObject cvGameOver;
    [SerializeField] private GameObject cvFinish;
    [SerializeField] private GameObject cvStart;
    [Header ("Etiquetas")]
    [SerializeField] private TextMeshProUGUI lblTimer;
    [SerializeField] private TextMeshProUGUI lblLoseMsg;
    [Header("DefaultPositions")]
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform NPC1Position;
    [SerializeField] private Transform NPC2Position;
    [SerializeField] private Transform NPC3Position;
    [SerializeField] private Transform NPC4Position;
    [Header("Objects")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject NPC1;
    [SerializeField] private GameObject NPC2;
    [SerializeField] private GameObject NPC3;
    [SerializeField] private GameObject NPC4;
    [Header ("Esencial")]
    [SerializeField] private float time = 30f;
    private float saveDefaultTime;

    private void Start()
    {
        saveDefaultTime = time;
        Time.timeScale = 0f;
        cvFinish.SetActive (false);
        cvGameOver.SetActive(false);
        cvStart.SetActive (true);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        lblTimer.text = Mathf.Round(time).ToString() + "s";
        if(time <= 0f)
        {
            Finish();
        }
    }

    private void Finish()
    {
        Time.timeScale = 0f;
        lblTimer.gameObject.SetActive(false);
        cvFinish.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        cvGameOver.SetActive(true);
        lblLoseMsg.text = "Una pena, te quedaban " + Mathf.Round(time).ToString() + "s para ganar";
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        cvFinish.SetActive(false);
        cvGameOver.SetActive(false);
        cvStart.SetActive(false);
        time = saveDefaultTime;

        //Ponemos cada elemento en su sitio cada vez que iniciamos partida
        player.transform.position = playerPosition.position;
        NPC1.transform.position = NPC1Position.position;
        NPC2.transform.position = NPC2Position.position;
        NPC3.transform.position = NPC3Position.position;
        NPC4.transform.position = NPC4Position.position;
    }
}
