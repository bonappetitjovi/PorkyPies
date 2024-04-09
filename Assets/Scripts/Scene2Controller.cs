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
    }

    public void ActivateScene2Object(char objectIdentifier)
    {
        // Activate corresponding object based on object identifier
        char objectChar = char.ToUpper(objectIdentifier);
        int index = objectChar - 'A'; // Convert char to index (A: 0, B: 1, ..., G: 6)

        // Activate the corresponding object
        if (index >= 0 && index < scene2Objects.Length)
        {
            scene2Objects[index].SetActive(true);
        }
    }
}
