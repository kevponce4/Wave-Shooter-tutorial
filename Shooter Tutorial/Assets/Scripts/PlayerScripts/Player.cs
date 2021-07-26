using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // everything here can be googled on your own if you were starting from scratch
    #region Movment_vars
    [SerializeField]
    [Tooltip("How fast player moves")]
    private float move_speed; //private should be used when only this game object is expected to interact with the variable
    private Vector2 currdir;
    private Vector3 mousepos;// already set for you determines the rotation of the player
    private Vector2 looking; // holds the position the mouse is pointing at
    private float x_input;
    private float y_input;
    #endregion

    #region Heath_vars

    //add a max health variable and a current health variabel
    //think about whether this should be private or public
    //look at the health_funcs region and why you might want the player to handel its own damage
    //should probably be floats unless you prefer to work with non decimal number
    #endregion

    #region Attack_vars
    //https://docs.unity3d.com/Manual/Prefabs.html
    //
    //message kevin for how to use bullets
    //needs a float for how often we can shoot
    #endregion

    #region Unity_vars
    Rigidbody2D PlayerRB;

    #endregion

    #region Unity_funcs
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>(); //this will be a usefull function for anything that needs to move
        //should try to set starting health here
    }
    private void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");// gets if pre set buttons are pressrd or not giving a value of 1, 0 or -1 preset as arrow keys and wasd
        y_input = Input.GetAxisRaw("Vertical");// gets if pre set buttons are pressrd or not giving a value of 1, 0 or -1 preset as arrow keys and wasd
        move();
        pointing();

        //we will check for attacking here
        //use getbuttondown(look it up if you don't know it) and use the keyword:Fire1
        // can also use getaxis raw still using the same keyword
        // GetAxisRaw API https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html
        //GetButtonDown API https://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html
        //call Attack if requirments met
    }
    #endregion

    #region lookingfunc
    private void pointing()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        looking = new Vector2((mousepos.x - transform.position.x), (mousepos.y - transform.position.y));
        transform.up = looking;
    }
    #endregion

    #region movefunc
    private void move()
    {
        //based on x and y input decide how the player should move through their velocity
        // you may want to normilize the vector you make
        // Api for rigidbody velocity https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html

    }
    #endregion

    #region Attackfuncs
    private void Attack()
    {
        //usefull documentation for spawning entities https://docs.unity3d.com/ScriptReference/Object.Instantiate.html 
        //recomended to use this version of Instantiate(Object original, Vector3 position, Quaternion rotation);
        //you need to make a bullet before you make attack ideally^^^^^^
        //set the bulets velocity, you can do this through rigidbody here or in a function on the bullet you create
        // Api for rigidbody velocity https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html
        // think about where the bullet/ where the person is looking, should still be normalized

    }
    #endregion

    #region Helth_funcs
    public void TakeDamage(int dmg)//made public so that other objects can call this function when dealing damage
    {
        //called on by enemy to take damage
        //modify the health var you added
    }
    #endregion
}
