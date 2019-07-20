using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentShield : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject presentShieldEnabledPrefab;
    [SerializeField]
    private GameObject _explodeAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -4.3f )
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
            Destroy(this.gameObject);
            
            Destroy(Instantiate(_explodeAnimation, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity), 1f);
                      
        }
    }
       
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //access the player
            Unikitty unikitty = other.GetComponent<Unikitty>();
            //enable power up
            if (unikitty != null)
            {
                unikitty.PresentShieldOn();
            }

            //destroy orself
            Destroy(this.gameObject);
            Destroy(Instantiate(presentShieldEnabledPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity),0.8f);
            
            
            
        }
    }
}
