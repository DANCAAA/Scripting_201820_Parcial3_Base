using UnityEngine;

public class AIMoveTest : MonoBehaviour
{
    // Singleton!
    public static AIMoveTest Instance { get; private set; }

    public delegate void OnAIMoveIssued();
    public OnAIMoveIssued onAIMoveIssued;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        FindObjectOfType<GameController>().onGameStart += ExecuteOnAIMoveIssued;
    }

    private void ExecuteOnAIMoveIssued()
    {
        if (onAIMoveIssued != null)
        {
            onAIMoveIssued();
        }
    }
}