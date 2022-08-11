using UnityEngine.UI;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private Text interactMSG;

    private void Start()
    {
        this.interactMSG = GameObject.FindGameObjectWithTag("InteractMSG").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.interactMSG.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.interactMSG.enabled = false;
    }
}
