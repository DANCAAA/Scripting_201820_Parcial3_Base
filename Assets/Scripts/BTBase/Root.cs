using UnityEngine;

public class Root : Node
{
    [SerializeField]
    private Node child;

    public override bool Execute()
    {
        Debug.Log("Root :: Execute");

        return child.Execute();
    }

    public override void SetControlledAI(AIController newControlledAI)
    {
        Debug.Log("Root :: SetControlledAI");

        child.SetControlledAI(newControlledAI);
    }
}