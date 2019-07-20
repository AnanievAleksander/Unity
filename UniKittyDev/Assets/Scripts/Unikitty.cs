using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unikitty : MonoBehaviour
{
    public bool isTheShieldenabled = false;
    public bool isPowerUpCollected = false;

    [SerializeField]
    private GameObject candyLeftPrefab;
    [SerializeField]
    private GameObject candyRightPrefab;
    [SerializeField]
    private GameObject candyRightPowerUpPrefab;
    [SerializeField]
    private GameObject candyLeftPowerUpPrefab;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private GameObject _shieldGameObgect;
    [SerializeField]
    private GameObject _deadAnimationPrefab;
    [SerializeField]
    private GameObject _appearingPrefab;


    [SerializeField]
    private float _fireRate = 0.25f;
    
    private float nextFire = 0.0f;


    [SerializeField]
    private float speed = 5f;
    public int lives = 3;
    public static bool facingLeft;
    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -3.39f, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Destroy(Instantiate(_appearingPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity), 0.5f);
        facingLeft = true;
        
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
            _uiManager.UpdateLivesCounter(lives);
        }
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutines();
        }
       
        

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
       // Jump();
        // shoot whit candys with space button to both direction left or right
        if (Input.GetKeyDown(KeyCode.Space) && facingLeft ==true)
        {
            ShootLeft(); 
        }
        else if(Input.GetKeyDown(KeyCode.Space) && facingLeft == !true)
        {
            ShootRight();
        }
        

       
        

    }
    private void ShootLeft()
    {
        if (Time.time > nextFire)
        {
            if (isPowerUpCollected == true)
            {
                Instantiate(candyLeftPowerUpPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                
            }
            else
            {
                Instantiate(candyLeftPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            nextFire = Time.time + _fireRate;
        }
        
    }
    private void ShootRight()
    {
        if (Time.time > nextFire)
        {
            if (isPowerUpCollected == true)
            {
                Instantiate(candyRightPowerUpPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(candyRightPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
            nextFire = Time.time + _fireRate;

        }
    }
    private void Movement()
    {
        //restrict the player movement outside of the game frame borders
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        Flip(horizontalInput);

        if (transform.position.x < -7.34f)
        {
            transform.position = new Vector3(-7.34f, transform.position.y, 0);
        }
        else if (transform.position.x > 7.34f)
        {
            transform.position = new Vector3(7.34f, transform.position.y, 0);
        }
    }
   // private void Jump()
   // {
   //     if (Input.GetKeyDown(KeyCode.UpArrow))
   //     {
   //        transform.position = new Vector3(0, 10, 0);
   //     }
   //}
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingLeft || horizontal > 0 && facingLeft)
        {
            facingLeft = !facingLeft;
            Vector3 theScale = transform.localScale;
            theScale.x*= -1;
            transform.localScale = theScale;
        }
    }

    public void Damage()
    {   if (isTheShieldenabled == false)
        {
            //substract 1 life from the player
            lives--;
            _uiManager.UpdateLives(lives);
            _uiManager.UpdateLivesCounter(lives);
        }
        
        if(lives < 1)
        {
            Destroy(this.gameObject);
            Destroy(Instantiate(explosionPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity), 0.5f);
            Destroy(Instantiate(_deadAnimationPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity), 1f);


            _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
            _gameManager.gameOver = true;
           _uiManager.ShowFinishScreen();
           
            
        }

    }
    public void PresentShieldOn()
    {
        isTheShieldenabled = true;
        _shieldGameObgect.SetActive(true);
        StartCoroutine(ShieldDownRoutine());
    }

    public void CandyPowerOn()
    {
        isPowerUpCollected = true;
        StartCoroutine(PowerDownRoutine());
    }

    public IEnumerator ShieldDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTheShieldenabled = false;
        _shieldGameObgect.SetActive(false);
    }

    public IEnumerator PowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isPowerUpCollected = false;
    }
    
}


    
