using UnityEngine;
using UnityEngine.UI; // Use this if you're using the regular UI Text
// using TMPro; // Uncomment this if you're using TextMeshPro

public class PrincipalReceiver : MonoBehaviour
{
    public Text principalIdText; // For regular UI Text
    // public TMP_Text principalIdText; // Uncomment if you're using TextMeshPro

    void Start()
    {
        // Add an event listener for messages from the JavaScript side
        Application.ExternalEval("window.addEventListener('message', (event) => { unityInstance.SendMessage('PrincipalReceiver', 'ReceivePrincipalId', event.data.principalId); });");
    }

    public void ReceivePrincipalId(string principalId)
    {
        Debug.Log("Received Principal ID: " + principalId);
        // Update the text object with the received Principal ID
        principalIdText.text = "Principal ID: " + principalId; // For regular UI Text
        // principalIdText.text = "Principal ID: " + principalId; // Uncomment for TextMeshPro
    }
}
