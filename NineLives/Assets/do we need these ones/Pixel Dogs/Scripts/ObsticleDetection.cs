using UnityEngine;
using System.Collections;

public class ObsticleDetection : MonoBehaviour {

    DogBehaviour behaviourScript;

    [Header("Targets")]
    public string lookTarget;
    public string sniffTarget;
    public Vector2 facingDirection;
    public float xOffset = -0.45f;

    private void Awake()
    {
        behaviourScript = GetComponent<DogBehaviour>();
    }

    void FixedUpdate()
    {
        facingDirection = behaviourScript.FacingDirection2D();

        if (behaviourScript.isSniffing)
        {
            Debug.DrawRay(new Vector2(transform.position.x + xOffset, transform.position.y - 0.15f), new Vector3(0, -0.2f, 0), Color.green, 0.05f);
            RaycastHit2D searchHit = Physics2D.Raycast(new Vector2(transform.position.x + xOffset, transform.position.y - 0.15f), new Vector2(0, -0.2f), 1);
            if (searchHit.collider != null)
            {
                if (searchHit.collider.gameObject.name == sniffTarget)
                {
                    ToggleSniffing(false, "none");
                    behaviourScript.ProcessFindings(searchHit.transform.gameObject);
                }
            }
        }

        if (behaviourScript.isLooking)
        {
            Debug.DrawRay(transform.position, facingDirection, Color.green, 0.05f);
            RaycastHit2D lookHit = Physics2D.Raycast(transform.position, facingDirection, 1);
            if (lookHit.collider != null)
            {
                if (lookHit.collider.tag == "Treasure" && lookTarget == "Treasure")
                {
                    Debug.Log(this.name + " Found Treasure!");
                    Destroy(lookHit.transform.gameObject);
                    ToggleLooking(false, "none");

                    behaviourScript.Laydown();
                    behaviourScript.Bark();
                }
                else if (lookHit.collider.tag == "FetchMachine" && lookTarget == "FetchMachine")
                {
                    Debug.Log(this.name + " Found the Fetch Machine!");
                    ToggleLooking(false, "none");
                    if (behaviourScript.objective == "PlayFetch")
                    {
                        Debug.Log(this.name + " wants to play fetch");
                        behaviourScript.Laydown();
                        behaviourScript.Bark();
                        StartCoroutine(WaitForCannon(lookHit.transform));
                    }
                    else if (behaviourScript.objective == "ReturnBall")
                    {
                        Debug.Log(this.name + " returns the ball!");
                        behaviourScript.DropBall();
                    }
                    
                }
            }   
        }

        //wall detection always on
        facingDirection = behaviourScript.FacingDirection2D();

        Debug.DrawRay(transform.position, facingDirection, Color.green, 0.05f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, 1);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall")
            {
                behaviourScript.Flip();
                return;
            }
        }        
    }

    public void ToggleSniffing(bool mode, string target_m)
    {
        sniffTarget = target_m;
        behaviourScript.isSniffing = mode;
    }

    public void ToggleLooking(bool mode, string target_m)
    {
            lookTarget = target_m;
            behaviourScript.isLooking = mode;
    }

    public IEnumerator WaitForCannon(Transform fetchMachine)
    {
        yield return new WaitForSeconds(2f);
        GameObject ball = fetchMachine.GetChild(0).GetComponent<ItemCannon>().Fire();
        yield return new WaitForSeconds(0.1f);
        if(transform.position.x < ball.transform.position.x)
        {
            if (!behaviourScript.mySprite.flipX)
            {
                behaviourScript.Flip();
            }
        }
        ToggleSniffing(true, "Ball");
        behaviourScript.StartRunning();
        Debug.Log(this.name + " is chasing the ball!");
    }
}