using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCato : MonoBehaviour
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
        if (Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z >= 0.1f)
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

        if (Controls.swipeup)
        {
            StartCoroutine(MoveUp());
        }

        else if (Controls.swipedown)
        {
            // Trigger roll animation
            animator.SetTrigger("Jab");
        }
    }

    private IEnumerator MoveUp()
    {
        float startPosition = Player.position.y;
        float targetPosition = startPosition + 2f;
        float duration = 0.3f;

        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            Player.position = new Vector3(Player.position.x, Mathf.Lerp(startPosition, targetPosition, timeElapsed / duration), Player.position.z);
            yield return null;
        }

        float returnDuration = 0.3f;
        timeElapsed = 0;
        while (timeElapsed < returnDuration)
        {
            timeElapsed += Time.deltaTime;
            Player.position = new Vector3(Player.position.x, Mathf.Lerp(targetPosition, startPosition, timeElapsed / returnDuration), Player.position.z);
            yield return null;
        }

        Player.position = new Vector3(Player.position.x, startPosition, Player.position.z);
    }
}
