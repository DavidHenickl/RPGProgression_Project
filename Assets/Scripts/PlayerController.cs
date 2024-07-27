using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public LayerMask interactablesLayer;
    public LayerMask battleLayer;
    public LayerMask ItemLayer;

    private bool isMoving;
    private Vector2 input; 
    private Animator animator;

    [SerializeField] GameObject battleSystem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if(!isMoving) 
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0)
                input.y = 0;
            if (input.y != 0)
                input.x = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var tarPos = transform.position;
                tarPos.x += input.x;
                tarPos.y += input.y;

                if (isWalkable(tarPos))
                {
                    StartCoroutine(Move(tarPos));
                } else
                {
                    CheckGate();
                }
            }
        }
        animator.SetBool("isMoving", isMoving);

        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        /*var Itemcollider = Physics2D.OverlapCircle(transform.position, 0.2f, ItemLayer);

        if (Itemcollider != null)
        {
            Debug.Log("Item found");
            Itemcollider.GetComponent<Item>().InteractItem();
        }*/
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer | interactablesLayer) != null)
        {
            return false;
        } 
        return true;
    }

    private void Interact()
    {
        var facingVec = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var InteractPos = transform.position + facingVec;
        var collider = Physics2D.OverlapCircle(InteractPos, 0.2f, interactablesLayer);

        if (collider != null)
        {
            Debug.Log("NPC found");
            collider.GetComponent<Interactable>().Interact();
        }
    }

    private void CheckGate()
    {
        var facingVec = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var InteractPos = transform.position + facingVec;
        var collider = Physics2D.OverlapCircle(InteractPos, 0.2f, solidObjectLayer);

        if (collider != null)
        {
            if (collider.gameObject.tag == "Gate")
            {
                Debug.Log("Gate found");
                collider.GetComponent<ReputationGate>().CheckGate();
            }
        }
    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.1f, battleLayer) != null)
        {
            if(Random.Range(1, 100) < 10)
            {
                Debug.Log("Battle has started");
                battleSystem.SetActive(true);
                battleSystem.GetComponent<BattleSystem>().StartBattle();
            }
        }
    }

    IEnumerator Move(Vector3 targetPos) 
    {  
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();
    }

}
