using UnityEngine;

public class TestBTController : MonoBehaviour
{
    [SerializeField]
    private Root root;

    [SerializeField]
    private bool repeatInvoke = false;

    [SerializeField]
    private float rootInvokeTime = 2F;

    // Use this for initialization
    private void Start()
    {
        if (root != null)
        {
            if (repeatInvoke)
            {
                InvokeRepeating("ExecuteBT", 0.5F, rootInvokeTime);
            }
            else
            {
                ExecuteBT();
            }
        }
    }

    private void ExecuteBT()
    {
        Debug.Log("TestBTController :: ExecuteBT");

        print(string.Format("Executed root with result {0}", root.Execute()));
    }
}