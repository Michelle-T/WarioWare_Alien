using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiTrPlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int count;

    private float timer;
    private int wholetime;

    public Text endText;
    public Text winText;

    public float speed;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        endText.text = "";
        SetCountText();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb.AddForce(movement * speed);

        //This does a timer before ending the game after 10 seconds.
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! T-T";
            StartCoroutine(ByeAfterDelay(2));

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            // add a point to the game
            GameLoader.AddScore(1);

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }
    }

    void SetCountText()
    {
        //Check if we've collected all 10 pickups. If we have...
        if (count >= 1)
        {
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));
        }
    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }
}
