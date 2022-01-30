using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAndPullScript : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;

    public Vector2 side;

    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        side = Vector2.right;
    }

    void Start()
    {

    }

    void Update()
    {
        if (!gameManager.isAnotherDimension)
        {
            if (Input.GetKeyDown(KeyCode.E))
                side = gameManager.playerAnimator.gameObject.GetComponent<SpriteRenderer>().flipX ? Vector2.left : Vector2.right;

            Physics2D.queriesStartInColliders = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, side * transform.localScale.x, distance, boxMask);

            if (hit.collider != null && hit.collider.gameObject.tag == "Items" && Input.GetKeyDown(KeyCode.E))
            {
                box = hit.collider.gameObject;
                box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<BoxPull>().beingPushed = true;
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                box.GetComponent<FixedJoint2D>().enabled = false;
                box.GetComponent<BoxPull>().beingPushed = false;
            }
        }
        else if (box != null)
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            side = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            side = Vector2.right;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + side * transform.localScale.x * distance);
    }    
}
