using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // Character
    private PlayerCharacter_Base playerCharacterBase;
    private Vector2 movement = Vector2.zero;
    private Vector2 spawnPosition;

    // Keep track of movement
    private Vector2 lastMoveDir;
    private Rigidbody2D rigidBody;
    private GameObject pickupZone;
    public GameObject objectToPickUp;

    // Base speed
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        pickupZone = transform.Find("PickupZone").gameObject;
        rigidBody = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
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
        Debug.Log(collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            transform.position = spawnPosition;
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
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate() {
        Vector2 delta = movement * speed;
        rigidBody.MovePosition(rigidBody.position + delta);
    }
}
