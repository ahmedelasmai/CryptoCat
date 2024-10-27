using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button loadSceneButton; // Reference to the specific button

    private void Start()
    {
        // Make sure the button is assigned in the Inspector
        if (loadSceneButton != null)
        {
            loadSceneButton.onClick.AddListener(LoadSampleScene);
        }
        else
        {
            Debug.LogWarning("Load Scene Button is not assigned.");
        }
    }

    private void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
