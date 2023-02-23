using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    //might not need this tho
    //}
    public Rigidbody2D rigidbody;
    public float JumpDistance;
    public float XmoveVel;
    public float directionX;
    public SpriteRenderer sprite;
    public bool ManualOverRide;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (!ManualOverRide)
        {
            var DefaultInstance = new DefaultVal(); //works only with the local instance
            JumpDistance = DefaultInstance.getY_vel();
            XmoveVel = DefaultInstance.getX_vel();
        }

        //null check
        if (rigidbody == null)
        {
            //GameObject go = GameObject.Find("Player");
            rigidbody = GetComponent<Rigidbody2D>(); //get component from gameobject in Playmode Test
            if (rigidbody == null)
            {
                Debug.Log("Rigidbody still not referenced!");
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
        Debug.Log("Up arrow pressed!");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpDistance);
        }
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    Debug.Log("Left arrow pressed!");
        //    rigidbody.velocity = new Vector2(-XmoveVel, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    Debug.Log("Right arrow pressed!");
        //    rigidbody.velocity = new Vector2(XmoveVel, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //    Debug.Log("Down arrow pressed!");

        directionX = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(directionX * XmoveVel, rigidbody.velocity.y);


        //Don't do this if orientation test in not included in Playmode Test
        if (animator != null)
        {
            //check if orientation is correct
            if (rigidbody.velocity.x < 0f)
            {
                sprite.flipX = true;
                animator.SetBool("running", true);
            }
            else if (rigidbody.velocity.x == 0f)
            {
                //idling
                animator.SetBool("running", false);
            }
            else
            {
                sprite.flipX = false;
                animator.SetBool("running", true);
            }
        }
    }
}
