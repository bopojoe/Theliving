using UnityEngine;
using System.Collections;
//------------------------------------------
public class AI_Enemy : MonoBehaviour
{
    //------------------------------------------
    public enum ENEMY_STATE {PATROL, CHASE, ATTACK};
    //------------------------------------------
    public ENEMY_STATE CurrentState
    {
        get{return currentstate;}
 
        set
        {
            //Update current state
            currentstate = value;
 
            //Stop all running coroutines
            StopAllCoroutines();
 
            switch(currentstate)
            {
                case ENEMY_STATE.PATROL:
                    StartCoroutine(AIPatrol());
                break;
 
                case ENEMY_STATE.CHASE:
                    StartCoroutine(AIChase());
                break;
 
                case ENEMY_STATE.ATTACK:
                    StartCoroutine(AIAttack());
                break;
            }
        }
    }
    //------------------------------------------
    [SerializeField]
    private ENEMY_STATE currentstate = ENEMY_STATE.PATROL;
 
    //Reference to line of sight component
    private LineSight ThisLineSight = null;
 
    //Reference to nav mesh agent
    public UnityEngine.AI.NavMeshAgent ThisAgent = null;
 
    //Reference to player health
    private Health PlayerHealth = null;
 
    //Reference to player transform
    private Transform PlayerTransform = null;
 
    //Reference to patrol destination
    public Transform PatrolDestination = null;
 
    //Damage amount per second
    public float MaxDamage = 10f;

    private GameObject player = null;
    //------------------------------------------
    // used here to retrieve connected components for use in this script
    void Awake()
    {
        ThisLineSight = GetComponent<LineSight>();
        ThisAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }
    //------------------------------------------
    void Start()
    {
        //Get random destination
        GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Dest");
        PatrolDestination = Destinations[Random.Range(0, Destinations.Length)].GetComponent<Transform>();
 
        //Configure starting state
        CurrentState = ENEMY_STATE.PATROL;
    }
    //------------------------------------------

    private void Update()
    {
        while (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            PlayerTransform = PlayerHealth.GetComponent<Transform>();
        }
    }

    public IEnumerator AIPatrol()
    {
        //Loop while patrolling
        while (currentstate == ENEMY_STATE.PATROL)
        {
            //Set strict search
            ThisLineSight.Sensitity = LineSight.SightSensitivity.STRICT;
 
            //Chase to patrol position
            ThisAgent.isStopped = false;
            ThisAgent.SetDestination(PatrolDestination.position);
 
            //Wait until path is computed
            while (ThisAgent.pathPending)
                yield return null;
 
            //If we can see the target then start chasing
            if (ThisLineSight.CanSeeTarget)
            {
                ThisAgent.isStopped = true;
                CurrentState = ENEMY_STATE.CHASE;
                yield break;
            }
 
            //Have we arrived at dest, get new dest
            //  debug ->  if (Vector3.Distance(transform.position, PatrolDestination.position) <= ThisAgent.stoppingDistance*1.2f)
            if (Vector3.Distance(transform.position, PatrolDestination.position) <= 3)
                 
            {
                GameObject[] Destinations = GameObject.FindGameObjectsWithTag("Dest");
                PatrolDestination = Destinations[Random.Range(0, Destinations.Length)].GetComponent<Transform>();
            }
        
            //Wait until next frame
            yield return null;
        }
    }
    //------------------------------------------
    public IEnumerator AIChase()
    {
        //Loop while chasing
        while(currentstate == ENEMY_STATE.CHASE)
        {
            //Set loose search
            ThisLineSight.Sensitity = LineSight.SightSensitivity.LOOSE;
 
            //Chase to last known position
            ThisAgent.isStopped = false;
            ThisAgent.SetDestination(ThisLineSight.LastKnowSighting);
 
            //Wait until path is computed
            while(ThisAgent.pathPending)
                yield return null;
 
            //Have we reached destination?
            if(ThisAgent.remainingDistance <= ThisAgent.stoppingDistance)
            {
                //Stop agent
                ThisAgent.isStopped = true;
 
                //Reached destination but cannot see player
                CurrentState = !ThisLineSight.CanSeeTarget ? ENEMY_STATE.PATROL : ENEMY_STATE.ATTACK;
 
                yield break;
            }
 
            //Wait until next frame
            yield return null;
        }
    }
    //------------------------------------------
    public IEnumerator AIAttack()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        PlayerTransform = PlayerHealth.GetComponent<Transform>();
        //Loop while chasing and attacking
        while(currentstate == ENEMY_STATE.ATTACK)
        {
            //Chase to player position
            ThisAgent.isStopped = false;
            ThisAgent.SetDestination(PlayerTransform.position);
 
            //Wait until path is computed
            while(ThisAgent.pathPending)
                yield return null;
 
            //Has player run away?
            if(ThisAgent.remainingDistance > ThisAgent.stoppingDistance)
            {
                //Change back to chase
                CurrentState = ENEMY_STATE.CHASE;
                yield break;
            }
            else
            {
                //Attack
                PlayerHealth.HealthPoints -= MaxDamage * Time.deltaTime;
            }
 
            //Wait until next frame
            yield return null;
        }
 
        yield break;
    }
    //------------------------------------------
}
//------------------------------------------