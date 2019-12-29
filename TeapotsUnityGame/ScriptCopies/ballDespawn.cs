/* Script by Nelson Su on 11/30/2018
 * This script will despawn the ball prefabs that drop down
 * to a certain position below the background image by destroying
 * the game object. This prevents memory waste.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDespawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
    }
}
