using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy1 : MonoBehaviour
{
    #region physics_vars
    [SerializeField]
    [Tooltip("Speed of enemy")]
    private float move_speed;
    private Rigidbody2D enemyRB;
    private Player player;
    #endregion

    #region Heath_vars

    //add a max health variable and a current health variabel
    //should probably be floats
    #endregion

    #region attack_vars
    // something to hold our enemies damage

    // an attack timer: should be floats since time in unity can get down to fractoins of a second

    //expected attack delay var/. should also be a float to allow variable interactions between the timer and delay


    #endregion

    #region Movment_var
    // speed of the enemy should be a float since numbers in velocity should be floats

    Vector2 direction;
    // ignore this
    public float nextWaypointDistance = 5f;
    Path path;
    int currWaypoint;
    bool reachedEndofPath = false;

    Seeker seeker;
    #endregion
    

    #region Unity_funcs
    private void Awake()
    {
        // We need to get our RigidBody and seeker Components
        enemyRB = GetComponent<Rigidbody2D>();
        //set our max health
        
    }
    private void Start()
    {
        
        // We need to find the player so we can move toward them
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        

        if(path == null)
        {
            return;
        }

        Move();

        look();
    }
    #endregion

    #region move_func

    void UpdatePath()
    {

        if (seeker.IsDone()) {
            seeker.StartPath(enemyRB.position, player.transform.position, OnPathComplete);
        }
    }

    private void look()
    {
        
        if((Vector2) transform.up != direction)
        {
            transform.up = direction;
        }
        
    } 

    private void Move()
    {
        if(currWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
        } else
        {
            reachedEndofPath = false;
        }

        direction = ((Vector2)path.vectorPath[currWaypoint] - enemyRB.position).normalized;
        // use direction to influence the enemies velocity


        float distance = Vector2.Distance(enemyRB.position, path.vectorPath[currWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currWaypoint++;
        }

    }
    #endregion

    #region attack_func

    // we want to "attack" or wait to attack as long as we are in contact with a player

    private void Attack()
    {
        //When attacking we can increase our timer, We will also use something called a coroutine for animations and so we don't attack every frame
        //Ignore the coroutine for now and simply have the player take damage

    }
    #endregion

    #region AI_funcs
    void OnPathComplete(Path P)
    {
        Debug.Log("Line 88");
        if (!P.error)
        {
            path = P;
            currWaypoint = 0;
        }
    }
    #endregion

    #region Helth_funcs
    public void TakeDamage(int dmg)
    {
        //called on by enemie to take damage
        //modify the health var you added
    }
    #endregion
}
