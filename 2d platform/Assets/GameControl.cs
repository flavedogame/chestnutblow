using UnityEngine;
using System.Collections;

//MainGame GameController
public class GameControl : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public UIFunction uiFunction;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

       
    }

    void Update()
    {
        
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                int hazardType = Random.Range(0, hazards.Length);
                GameObject hazard = hazards[hazardType];

                if (hazardType == 0)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), -spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    //make a pool
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }
                else //bird 
                {
                    Vector3 spawnPosition = new Vector3(-spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    //make a pool
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }

                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        uiFunction.updateScore(score);
    }

    public void GameOver()
    {
        uiFunction.gameOver();
        gameOver = true;
    }
}
