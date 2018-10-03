using UnityEngine;

public class Sequence : Composite
{
    protected override bool MustAllChildrenSucceed { get { return true; } }

    protected override bool ShouldBreak(bool result)
    {
        Debug.Log("Sequence :: ShouldBreak");

        return !result;
    }
}