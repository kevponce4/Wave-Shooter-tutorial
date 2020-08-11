using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    #region player
    [SerializeField]
    [Tooltip("keeps track of player")]
    private GameObject Player;
    #endregion


    #region Unityfunc
    // Update is called once per frame
    void Update()
    {
        Vector3 moved = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        transform.position = moved;
    }
    #endregion
}
