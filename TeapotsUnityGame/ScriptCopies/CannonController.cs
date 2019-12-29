/* Script by Nelson Su on 11/30/2018.
 * This script controls the movement of the cannon. It also restricts
 * the movement so that the player can't see pass the background image.
 * The script also instantiates ball prefabs and shoots them out of the
 * ballSpawn game object. This is activated using the spacebar. This
 * script also contains text for timer, winning, and game over. A timer
 * will count down and stop when count reaches 11. When timer reaches 0
 * without reaching a count of 11, game result in a loss. Cannon's movement
 * and usage will be disabled.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour {

    public float speed;
    public float ballSpeed;
    public float timer;
    public float xMin, xMax, yMin, yMax;
    public static int count = 0;
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public Text timertext;
    public Text wintext;
    public Text gameovertext;
    private Rigidbody rb;
    private bool victory = false;
    private bool shoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timertext.text = "30";
        wintext.text = "";
        gameovertext.text = "";
}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.velocity = movement * speed;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xMin, xMax),
            Mathf.Clamp(rb.position.y, yMin, yMax), 0.0f
            );

        if (Input.GetKeyDown(KeyCode.Space) && shoot == true)
        {
            var ball = (GameObject)Instantiate(
            ballPrefab,
            ballSpawn.position,
            ballSpawn.rotation);
     
            ball.GetComponent<Rigidbody>().velocity = 
                Quaternion.Euler(340, 0, 0) * ball.transform.forward * ballSpeed;

        }
        if (victory == false)
        {
            timer -= Time.deltaTime;
        }

        if (timer > 0 && count < 11)
        {
            timertext.text = timer.ToString("F0"); 
        }
        else if (timer > 0 && count >= 11)
        {
            Win();
        }
        else if (timer <= 0)
        {
            timertext.text = "0";
            GameOver();
        }

    }
    void Win()
    {
        victory = true;
        wintext.text = "You Win!";
        speed = 0;
        shoot = false;
    }
    void GameOver()
    {
        gameovertext.text = "Game Over";
        timertext.text = "0";
        speed = 0;
        shoot = false;
    }
}
