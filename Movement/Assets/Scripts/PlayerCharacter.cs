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
    public float stunTime = 0f;
    private readonly float FREEZE_SECONDS = 1f;
    private float iframes = 1.2f;
    private float nextvulnerabletime=0f;

    public GameObject EventSystem1;
    public PlayerStats Scoreboard;

    // Keep track of movement
    private Vector2 lastMoveDir;
    private Rigidbody2D rigidBody;
    private GameObject pickupZone;
    private SpriteRenderer spriteRenderer;
    public GameObject objectToPickUp;
    public GameObject heldObject;
    public DropZone currentDropZone;
    private Animator animator;

    private CatController heldCat;

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
        EventSystem1 = GameObject.Find("EventSystem");
        Scoreboard = EventSystem1.GetComponent(typeof(PlayerStats)) as PlayerStats;
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
        if (other.CompareTag("Enemy") && Time.time > nextvulnerabletime)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy == null)
            {
                return;
            }

            nextvulnerabletime = Time.time + iframes;

            if (heldObject != null)
            {
                DropCat();
            }

            switch (enemy.effect)
            {
                case Effect.Reset:
                    transform.position = spawnPosition;
                    return;
                case Effect.Stun:
                    stunTime = FREEZE_SECONDS;
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

    private void DropCat()
    {
        heldObject.transform.position = this.transform.position;
        heldObject.GetComponent<SpriteRenderer>().enabled = true;
        heldObject.GetComponent<BoxCollider2D>().enabled = true;

        heldCat.velocity = heldCat.velocityRun;

        heldCat.target = new Vector2(0, 0);

        if (currentDropZone != null)
        {
            if (currentDropZone.name == "BlueZone" && heldCat.color == CatColor.Blue)
            {
                heldCat.target = new Vector2(-9.3f, 11.27f);
                heldCat.catMode = CatMode.SprintToHouse;
                Scoreboard.catsReturned++;
            }
            if (currentDropZone.name == "RedZone" && heldCat.color == CatColor.Pink)
            {
                heldCat.target = new Vector2(-9.4f, 18f);
                heldCat.catMode = CatMode.SprintToHouse;
                Scoreboard.catsReturned++;
            }
            if (currentDropZone.name == "GreenZone" && heldCat.color == CatColor.Green)
            {
                heldCat.target = new Vector2(-9.43f, 14.8f);
                heldCat.catMode = CatMode.SprintToHouse;
                Scoreboard.catsReturned++;
            }
        }

        heldObject = null;
    }

    public void HandleInteract()
    {
        if (!Input.GetKeyDown("space"))
        {
            return;
        }

        if (heldObject != null)
        {
            DropCat();
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
            heldCat = heldObject.GetComponent(typeof(CatController)) as CatController;
    }

    public void HandleMove()
    {
        if (stunTime > 0f) {
            movement = Vector2.zero;
            return;
        }

        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    public void Update()
    {
        if (stunTime > 0f)
        {
            stunTime -= Time.deltaTime;
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
        animator.SetBool("Stunned", stunTime > 0f);
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
