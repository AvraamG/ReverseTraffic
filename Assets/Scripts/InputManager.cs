using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode menuKey;
    [SerializeField] private GameManager gm;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(menuKey))
        {
            // Spwan the menu
        }
        float horizontalMotion = Input.GetAxis("Horizontal");
        float verticalMotion = Input.GetAxis("Vertical");

        Vector3 motionVector = new Vector3(horizontalMotion, 0f, verticalMotion);
        motionVector.Normalize();
        player.Move(motionVector);




    }


}
