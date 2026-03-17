using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float  _fireRate =  0.25f; 
    
    private float _canFire = 0.00f; 
    
    [SerializeField]
    private GameObject laserPrefab;

    [SerializeField]
    public float _speed = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            shoot();   
        }
    }


    private void shoot()
    {
        if(Time.time > _canFire)
        {
            Instantiate(laserPrefab,transform.position + new Vector3(0, 0.88f,0),Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }

    private void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);


        //Limitar los margenes de la nave
        if(transform.position.y > 0)
        {
            transform.position=new Vector3(transform.position.x,0,0);
        }
        else if(transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x,-4.2f,0);
        }

        if(transform.position.x > 9.5f)
        {
            transform.position=new Vector3(-9.5f,transform.position.y,0);
        }
        else if(transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f,transform.position.y,0);
        }

    }
}


