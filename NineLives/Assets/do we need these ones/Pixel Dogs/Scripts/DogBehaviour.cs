using UnityEngine;
using System.Collections;

public class DogBehaviour : MonoBehaviour
{
    ObsticleDetection detectionScript;

    [Header("Movement")]
    public float walkSpeed = 0.8f;
    public float runSpeed = 2.4f;
    [Header("Personality")]
    public string mood;
    public Personality personality;
    [Header("Actions")]
    public string objective;
    public bool busy;
    public bool canBark;
    public bool isSniffing;
    public bool isLooking;
    public GameObject ball;

    public GameObject heldItem;

    public SpriteRenderer mySprite;
    State state;

    Animator animator;

    enum State
    {
        STANDING,
        SLEEPING,
        SITTING,
        LAYING,
        WALKING,
        RUNNING
    }

    private void Awake()
    {
        personality = new Personality();
        mySprite = GetComponent<SpriteRenderer>();
        detectionScript = GetComponent<ObsticleDetection>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        state = State.STANDING;
    }

    public Vector3 FacingDirection3D()
    {
        return mySprite.flipX ? transform.right : -transform.right;
    }

    public Vector3 FacingDirection2D()
    {
        return new Vector2(FacingDirection3D().x, FacingDirection3D().y);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!busy)
        {
            busy = true;
            PlayFetch();
        }

        Vector3 direction = FacingDirection3D();

        if (state == State.WALKING)
        {
            transform.position += direction * walkSpeed * Time.deltaTime;
        }

        if (state == State.RUNNING)
        {
            transform.position += direction * runSpeed * Time.deltaTime;
        }
    }

    public Vector2 Flip()
    {
        mySprite.flipX = !mySprite.flipX;

        if (mySprite.flipX == false)
        {
            detectionScript.xOffset = -0.45f;
            return new Vector2(-1, 0);
        }
        else
        {
            detectionScript.xOffset = 0.45f;
            return new Vector2(1, 0);
        }
    }

    public void ProcessFindings(GameObject findings)
    {
        switch (findings.name)
        {
            case "Ball":
                ReturnBall(findings);
                break;
            default:
                break;
        }
    }

    // ADVANCED ACTIONS
    public void FindTreasure()
    {
        detectionScript.ToggleSniffing(true, "Treasure");
        StartWalking();
    }

    public void PlayFetch()
    {
        detectionScript.ToggleLooking(true, "FetchMachine");
        objective = "PlayFetch";
        StartWalking();
    }

    public void ReturnBall(GameObject ball)
    {
        PickUpBall(ball);
        StartWalking();
        float ballTime = Random.Range(1, 10);
        Wait(ballTime);
        if(ballTime > 4f)
        {
            StartRunning();
        }
        objective = "ReturnBall";
        detectionScript.ToggleLooking(true, "FetchMachine");
    }

    // BASIC ACTIONS
    public void StartWalking()
    {
        state = State.WALKING;
        ResetAnimator();
        animator.SetBool("isWalking", true);
    }

    public void StartRunning()
    {
        state = State.RUNNING;
        ResetAnimator();
        animator.SetBool("isRunning", true);
    }

    public void Stand()
    {
        state = State.STANDING;
        ResetAnimator();
        animator.SetBool("isStanding", true);
    }

    public void Sit()
    {
        state = State.SITTING;
        ResetAnimator();
        animator.SetBool("isSitting", true);
    }

    public void Sleep()
    {
        ResetAnimator();
        state = State.SLEEPING;
        animator.SetBool("isSleeping", true);
        StartCoroutine(Wait(Random.Range(20, 60)));
    }

    public void Laydown()
    {
        ResetAnimator();
        state = State.LAYING;
        animator.SetBool("isLaying", true);
        StartCoroutine(Wait(Random.Range(10, 40)));
    }

    public void Bark()
    {
        canBark = false;
        animator.SetTrigger("Bark");
    }

    public void PickUpBall(GameObject ball)
    {
        Debug.Log(this.name + " got the ball!");
        animator.SetLayerWeight(1, 1);
        heldItem = ball;
        ball.SetActive(false);
    }

    public void DropBall()
    {
        float x = transform.position.x + detectionScript.xOffset;

        if (heldItem)
        {
            heldItem.transform.position = new Vector3(x, transform.position.y, 0f);
            heldItem.SetActive(true);
            heldItem.GetComponent<Ball>().used = true;
            heldItem = null;
            animator.SetLayerWeight(1, 0);
            Wait(0.5f);
            busy = false;
        }
    }

    public IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void ResetAnimator()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isStanding", false);
        animator.SetBool("isSitting", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isLaying", false);
        animator.SetBool("isSleeping", false);
    }
}
