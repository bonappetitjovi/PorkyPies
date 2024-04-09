using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement4 : MonoBehaviour
{
    private Transform Player;
    public SwipeControls4 Controls;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    // Jump parameters
    private bool isJumping = false;
    public float jumpSpeed = 5f;
    public float jumpHeight = 2f;
    public float jumpDuration = 0.5f;
    public float jumpTimer = 0f;

    private void Start()
    {
        Player = GetComponent<Transform>();
    }

    private void Update()
    {
        // Jumping logic
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer <= jumpDuration)
            {
                float jumpProgress = jumpTimer / jumpDuration;
                float jumpCurve = Mathf.Sin(jumpProgress * Mathf.PI);
                Player.position += new Vector3(0, jumpCurve * jumpHeight * Time.deltaTime, 0);
            }
            else
            {
                isJumping = false;
                jumpTimer = 0f;
            }
        }

        // Movement logic
        if (Lane3 && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane1 && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }

        // Check for jump input
        if (Controls.swipeup && !isJumping)
        {
            // Trigger jump
            isJumping = true;
        }
        
        // Check for dash input
        if (Controls.swipedown)
        {
            // Dash forward in x-axis
            // Assuming dash power is 10
            Player.position += new Vector3(10f * Time.deltaTime, 0, 0);
        }

        // Change lanes based on swipe inputs
        #region ChangeBools
        if (Controls.swiperight && !Lane3 && Lane1)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (Controls.swipeleft && Lane2 && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (Controls.swiperight && Lane2 && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (Controls.swipeleft && !Lane1 && Lane3)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion
    }
}
