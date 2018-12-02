using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiTrAlienMovement : MonoBehaviour {

    public float speed;

    //public GameObject.tag isGround;

    public Transform wallHitBox;

    private bool wallHit = false;

    public float wallHitHeight;
    public float wallHitWidth;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		//transform.Position(new Vector3())
	}

    void FixedUpdate()
    {

        transform.Translate(speed * Time.deltaTime, 0, 0);

        //wallHit is a bool similar to the ground one in the player code.
        //Physics2D.OverlapBox is similar to Physics2D.OverlapCircle but uses a box
        //The next is a Vector 2 with the box's Width and Height which are floats that I made public so I could edit them in the editor. 
        //The zero is the z value we don't need.
        //isGround is a LayerMask of everything that is ground.
        //wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);

        /*if (wallHit == true)
        {
            speed = speed * -1;
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            speed = speed * -1;
            Debug.Log("I loved living");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
