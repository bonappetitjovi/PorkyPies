using UnityEngine;
using UnityEngine.SceneManagement;

public class back2menu : MonoBehaviour
{
    public string scene="ztest";
    // You can attach this method to the button's OnClick event in the Unity Editor
    public void ChangeSceneOnClick()
    {
        // Change scene to "Main"
        SceneManager.LoadScene(scene);
    }
}