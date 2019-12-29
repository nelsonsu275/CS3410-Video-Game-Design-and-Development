/* Script by Nelson Su on 11/30/2018
 * This script controls the teapot prefabs. The teapots will rotate
 * until they are hit by a ball or another teapot. Teapots will despawn
 * when they reach a certain position below the background image by
 * destroying itself. When the teapot collides with an object of
 * the "ball" or "teapot" tag, this teapot's gravity will be enabled.
 * The static count variable from the CannonController.cs script
 * will also be incremented each time a teapot gets hit.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeapotController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private bool spin = true;
    private bool hit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (spin == true)
        {
            Rotate();
        }
        if (transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" || other.tag == "teapot")
        {
            if (hit == false)
            {
                hit = true;
                rb.useGravity = true;
                rb.isKinematic = false;
                spin = false;
                CannonController.count += 1;
               
            }
        }
    }
    void Rotate()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
