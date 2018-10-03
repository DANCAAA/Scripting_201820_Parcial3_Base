using UnityEngine;

public class ExampleSelector : Selector
{
    [SerializeField]
    private bool testSucceeded;

    protected override bool CheckCondition()
    {
        Debug.Log("ExampleSelector :: CheckCondition");

        return testSucceeded;
    }
}