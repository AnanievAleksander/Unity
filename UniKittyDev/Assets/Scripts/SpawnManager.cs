using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

    
{

    // [SerializeField]
    // private GameObject _unikitty;
    private GameManager _gameManager;
    [SerializeField]
    private GameObject[] _enemyRight;
    [SerializeField]
    private GameObject[] _enemyLeft;
    [SerializeField]
    private GameObject[] _powerUps;
   
   
    // Start is called before the first frame update
    void Start()
    {




            _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
            //Instantiate(_unikitty, transform.position = new Vector3(0, -3.39f, 0), Quaternion.identity);
            StartCoroutine(EnemySpawnFromLeftroutine());
            StartCoroutine(EnemyFromRightRoutine());
            StartCoroutine(PoweUpsSpawnRoutine());
      
        
       
    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemyFromRightRoutine());
        StartCoroutine(EnemySpawnFromLeftroutine());
        StartCoroutine(PoweUpsSpawnRoutine());
    }

    IEnumerator EnemySpawnFromLeftroutine()
    {
        while(_gameManager.gameOver == false)
        {
            
            int randomEnemy = Random.Range(0, 2);
            Instantiate(_enemyLeft[randomEnemy], new Vector3(-10f, -4.18f, 0),Quaternion.Euler(0,180,0));
            yield return new WaitForSeconds(Random.Range(1f,3f));
           
        }
    }
    IEnumerator EnemyFromRightRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomEnemy = Random.Range(0, 2);
            Instantiate(_enemyRight[randomEnemy], new Vector3(10f, -4.18f, 0), Quaternion.Euler(0,0,0));
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
   
    IEnumerator PoweUpsSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPower = Random.Range(0,2);
            Instantiate(_powerUps[randomPower], new Vector3(Random.Range(-8.3f, 8.3f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
       
    }

    
   

}
