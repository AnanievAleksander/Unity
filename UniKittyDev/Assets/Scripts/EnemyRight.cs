using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _rightEnemyBoxExplode;
    private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "CandyShot")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(Instantiate(_explosionPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity),0.5f);
            _uiManager.UpdateScore();
            bool isFliped = Unikitty.facingLeft;
            if (isFliped != true)
            {
                Destroy(Instantiate(_rightEnemyBoxExplode, transform.position + new Vector3(0, 2, 0), Quaternion.identity), 0.7f);
            }
            else
            {
                Destroy(Instantiate(_rightEnemyBoxExplode, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(0, 180, 0)), 0.7f);
            }


        }
        else if (other.tag == "Player")
        {
            Unikitty unikitty = other.GetComponent<Unikitty>();
            if (unikitty != null)
            {
                unikitty.Damage();
            }
            Destroy(this.gameObject);
            Destroy(Instantiate(_explosionPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity),0.5f);
            _uiManager.UpdateScore();
            bool isFliped = Unikitty.facingLeft;
            if (isFliped != true)
            {
                Destroy(Instantiate(_rightEnemyBoxExplode, transform.position + new Vector3(0, 2, 0), Quaternion.identity), 0.7f);
            }
            else
            {
                Destroy(Instantiate(_rightEnemyBoxExplode, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(0,180,0)), 0.7f);
            }
            
           
            

        }
        

    }
}
