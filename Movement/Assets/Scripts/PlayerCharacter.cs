using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    // Sounds
    // public AudioSource audio;
    public AudioClip pickupSound;

    // Character
    private PlayerCharacter_Base playerCharacterBase;
    private Vector2 movement = Vector2.zero;
    private Vector2 spawnPosition;
    private float frozenTime = 0f;
    private readonly float FREEZE_SECONDS = 2f;

    // Keep track of movement
    private Vector2 lastMoveDir;
    private Rigidbody2D rigidBody;
    private GameObject pickupZone;
    private SpriteRenderer spriteRenderer;
    public GameObject objectToPickUp;
    public GameObject heldObject;
    public DropZone currentDropZone;
    private Animator animator;

    // Base speed
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        pickupZone = transform.Find("PickupZone").gameObject;
        rigidBody = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null)
            {
                return;
            }

            switch (enemy.effect)
            {
                case Effect.Reset:
                    transform.position = spawnPosition;
                    return;
                case Effect.Stun:
                    frozenTime = FREEZE_SECONDS;
                    return;
            }
        }

        if (other.CompareTag("DropZone"))
        {
            currentDropZone = other.GetComponent<DropZone>();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other == currentDropZone)
        {
            currentDropZone = null;
        }
    }

    public void HandleInteract()
    {
        if (!Input.GetKeyDown("space"))
        {
            return;
        }

        Debug.Log("Pickup?");
        Debug.Log(objectToPickUp);
        if (!objectToPickUp)
        {
            return;
        }
            heldObject = objectToPickUp;
            objectToPickUp = null;

            // Meow!
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            heldObject.GetComponent<SpriteRenderer>().enabled = false;
            heldObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void HandleMove()
    {
        if (frozenTime > 0f) {
            movement = Vector2.zero;
            return;
        }

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    public void Update()
    {
        if (frozenTime > 0f)
        {
            frozenTime -= Time.deltaTime;
        }
        HandleInteract();
        HandleMove();

        Vector2 delta = movement * speed;
        rigidBody.MovePosition(rigidBody.position + delta);
        animator.SetFloat("Speed", movement.magnitude);
        if (!heldObject) {
            animator.SetBool("Cat", false);
        } else {
            animator.SetBool("Cat", heldObject.CompareTag("Cat"));
        }
        if (delta.magnitude > 0f && delta.x > 0f)
        {
            spriteRenderer.flipX = true;
        }
        if (delta.magnitude > 0f && delta.x < 0f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
