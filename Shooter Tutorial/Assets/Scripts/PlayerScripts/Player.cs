using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Movment_vars
    [SerializeField]
    [Tooltip("How fast player moves")]
    private float move_speed;
    private Vector2 currdir;
    private Vector3 mousepos;
    private Vector2 looking;
    private float x_input;
    private float y_input;
    #endregion

    #region Unity_vars
    Rigidbody2D PlayerRB;

    #endregion

    #region Unity_funcs
    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        x_input = Input.GetAxisRaw("Horizontal");
        y_input = Input.GetAxisRaw("Vertical");
        move();
        pointing();

        //we will check for attacking here
        //use getbuttondown(look it up if you don't know it) and use the keyword:Fire1
        //call Attack
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

    }
    #endregion

    #region Attackfuncs
    private void Attack()
    {
        //you need to make a bullet before you make attack ideally
        //set the bulets velocity
        //look up instantaite
    }
    #endregion
}
