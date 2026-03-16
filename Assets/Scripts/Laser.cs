using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }


    private void shoot()
    {
        transform.Translate(Vector3.up * speed  * Time.deltaTime);
        if(transform.position.y > 6)
        {
            Destroy(gameObject);
        }
    }
}
