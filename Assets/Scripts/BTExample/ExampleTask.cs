using UnityEngine;

public class ExampleTask : Task
{
    [SerializeField]
    private bool testSucceeded;

    public override bool Execute()
    {
        Debug.Log("ExampleTask :: Execute");

        return testSucceeded;
    }
}