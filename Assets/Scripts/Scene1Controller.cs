using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour
{
    public static Scene1Controller instance; // Singleton instance

    public GameObject[] scene1Objects; // Array to hold objects in Scene 1
    public Button[] buttons; // Array to hold buttons

    private int equip = 0; // Variable to hold current equipment value

    void Awake()
    {
        // Singleton pattern initialization
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Load equip value from PlayerPrefs
        equip = PlayerPrefs.GetInt("Equip", 0);
        ChangeEquip(equip);
    }

    void Start()
    {
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

        // Save equip value to PlayerPrefs
        PlayerPrefs.SetInt("Equip", equip);
        PlayerPrefs.Save();

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

    public int GetEquipValue()
    {
        return equip;
    }
}
