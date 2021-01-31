using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacter : MonoBehaviour
{

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
    public GameObject objectToPickUp;
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
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Pickup?");
        Debug.Log(objectToPickUp);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (frozenTime > 0f) {
            movement = Vector2.zero;
            return;
        }

        movement = context.ReadValue<Vector2>().normalized;
    }

    public void Update()
    {
        if (frozenTime > 0f)
        {
            frozenTime -= Time.deltaTime;
        }
        Vector2 delta = movement * speed;
        rigidBody.MovePosition(rigidBody.position + delta);
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetBool("Cat", false);
    }
}
