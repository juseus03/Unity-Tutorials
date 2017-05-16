using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float titlt;

    public float fireRate;
    public GameObject shot;
    public Transform shotSpawn;
    
    private Rigidbody rb;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
        rb.velocity = movement*speed;

        Vector3 position = new Vector3(Mathf.Clamp(rb.position.x,boundary.xMin, boundary.xMax),
                                       0.0f, Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax));
        rb.position = position;

        rb.rotation = Quaternion.Euler(0.0f,0.0f,rb.velocity.x*-titlt);

    }
}
