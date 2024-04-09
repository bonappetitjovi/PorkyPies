using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEgge : MonoBehaviour
{
    private Transform Player;
    public SwipeControls4 Controls;
    private Animator animator; // Animator component for handling animations

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private void Start()
    {
        Player = GetComponent<Transform>();
        animator = GetComponent<Animator>(); // Getting Animator component
    }

    private void Update()
    {
        if (Controls.swipeup)
        {
            // Trigger jump animation
            animator.SetTrigger("Dance");
        }
        else if (Controls.swipedown)
        {
            // Trigger roll animation
            animator.SetTrigger("Roll");
        }

        if(Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if(Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if(Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }

        #region ChangeBools
        if (Controls.swiperight == true && Lane3 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (Controls.swipeleft == true && Lane2 == true && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (Controls.swiperight == true && Lane2 == true && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (Controls.swipeleft == true && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion
    }
}
