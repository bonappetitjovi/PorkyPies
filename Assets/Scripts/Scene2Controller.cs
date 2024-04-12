using UnityEngine;

public class Scene2Controller : MonoBehaviour
{
    public GameObject[] scene2Objects; // Array to hold objects in Scene 2

    void Start()
    {
        // Disable all objects in Scene 2 initially
        foreach (GameObject obj in scene2Objects)
        {
            obj.SetActive(false);
        }

        // Activate objects based on equip value from Scene1Controller
        ActivateScene2Object(Scene1Controller.instance.GetEquipValue());
    }

    void ActivateScene2Object(int equip)
    {
        // Activate corresponding object based on equip value
        int index = equip - 1; // Adjust index to match equip value

        // Activate the corresponding object if the index is valid
        if (index >= 0 && index < scene2Objects.Length)
        {
            scene2Objects[index].SetActive(true);
        }
    }
}
