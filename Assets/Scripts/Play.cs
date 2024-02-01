using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public string scene="Main";
    public string scene2="Walletscan";
    // You can attach this method to the button's OnClick event in the Unity Editor
    public void ChangeSceneOnClick()
    {
        // Change scene to "Main"
        SceneManager.LoadScene(scene);
    }
    public void ChangeSceneOnClick2()
    {
        // Change scene to "Main"
        SceneManager.LoadScene(scene2);
    }
}