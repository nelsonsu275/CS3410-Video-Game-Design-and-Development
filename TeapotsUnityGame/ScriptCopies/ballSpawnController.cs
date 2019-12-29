/* Script by Nelson Su. Created on 11/30/2018
* This script will follow the Cannon game object's position in order
* to position the cannons that it shoots out.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawnController : MonoBehaviour {

    public GameObject Cannon;
    private Vector3 offset;

    void Start () {
        offset = transform.position - Cannon.transform.position;
    }
	
	void LateUpdate () {
        transform.position = Cannon.transform.position + offset;
    }
}
