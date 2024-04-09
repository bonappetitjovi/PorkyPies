using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour
{
    public GameObject[] scene1Objects; // Array to hold objects in Scene 1
    public Button[] buttons; // Array to hold buttons

    private int equip = 0; // Variable to hold current equipment value

    void Start()
    {
        // Disable all objects in Scene 1 initially
        foreach (GameObject obj in scene1Objects)
        {
            obj.SetActive(false);
        }

        // Add button click listeners
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i + 1; // Buttons are named from 1 to 7
            buttons[i].onClick.AddListener(() => ChangeEquip(buttonIndex));
        }
    }

    void ChangeEquip(int newEquip)
    {
        equip = newEquip;

        // Activate corresponding object based on equip value
        for (int i = 0; i < scene1Objects.Length; i++)
        {
            if (i == equip - 1) // Adjust index to match equip value
            {
                scene1Objects[i].SetActive(true);
            }
            else
            {
                scene1Objects[i].SetActive(false);
            }
        }
    }
}
