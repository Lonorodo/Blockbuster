using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusController : MonoBehaviour
{

    [Range(0.1f,10)][SerializeField] float speed;
    [SerializeField] int numberOfPointsPerBlock = 10;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scorefield;
    
    
    //Ich habe heute wochenende
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatusController>().Length;
        if (gameStatusCount > 1)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {

            DontDestroyOnLoad(gameObject);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scorefield.text = score.ToString();
         
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed;
        
    }

    public void ScoreCalculator()
    {

        score += numberOfPointsPerBlock;
      
        speed = speed + 0.1f;
        scorefield.text = score.ToString();

    }
}
