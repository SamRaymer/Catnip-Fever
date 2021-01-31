using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // Character
    private PlayerCharacter_Base playerCharacterBase;

    // Keep track of movement
    private Vector3 lastMoveDir;
    private GameObject pickupZone;
    public GameObject objectToPickUp;

    // Base speed
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        pickupZone = transform.Find("PickupZone").gameObject;
    }

    private void Awake()
    {
        // Assign character
        playerCharacterBase = gameObject.GetComponent<PlayerCharacter_Base>();
    }

    /**
     * Only triggered when the box collider is
     * selected as trigger - probably useless
     */
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Cat"))
        {
            Debug.Log("Touched a cat");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        handleMovement();
        handleInteract();

    }

    private void handleInteract()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Pickup?");

            // What are we touching?
            Debug.Log(objectToPickUp);
        }
    }

    private void handleMovement()
    {

        // Normalize movement direction
        float moveX = 0f;
        float moveY = 0f;

        /**
         * Move multiple directions
         * (Introduce else for one at a time)
         */
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        // NOT moving
        bool isIdle = moveX == 0 && moveY == 0;

        // Rig in idle animations for later (if needed)
        if (isIdle)
        {
            playerCharacterBase.PlayIdleAnimation(lastMoveDir);
        }
        else
        {
            // Vectors are (x, y)

            // (`normalized` to prevent diagonal acceleration)
            Vector3 moveDirection = new Vector3(moveX, moveY).normalized;

            // Save last movement
            lastMoveDir = moveDirection;

            // Animate walking
            playerCharacterBase.PlayWalkingAnimation(moveDirection);

            // Predict where moving for hitboxes
            Vector3 targetMovePosition = transform.position + moveDirection * speed * Time.deltaTime;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDirection, speed * Time.deltaTime);

            // Move, no collision
            if (raycastHit.collider == null)
            {
                transform.position = targetMovePosition;
            }
            else
            {
                Vector3 testMoveDir = moveDirection.normalized;

                // We're GOING to be here
                targetMovePosition = transform.position + testMoveDir * speed * Time.deltaTime;

                lastMoveDir = testMoveDir;
                playerCharacterBase.PlayWalkingAnimation(moveDirection);
                transform.position = targetMovePosition;

                // Idle
                playerCharacterBase.PlayIdleAnimation(lastMoveDir);
            }



        }

    }
}
