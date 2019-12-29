/* Script by Nelson Su on 11/30/2018
 * This script follows the position of the cannon player. It allows
 * the player to view in first person without seeing the actual cannon
 * game object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Cannon;      
    private Vector3 offset;    

    void Start()
    {
        offset = transform.position - Cannon.transform.position;
    }
    void LateUpdate()
    {
        transform.position = Cannon.transform.position + offset;
    }
}
