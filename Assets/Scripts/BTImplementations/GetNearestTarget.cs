using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearestTarget : Task {

    public override bool Execute()
    {
        Debug.Log("GetNearestTarget :: Execute");

        GameController gameController = FindObjectOfType<GameController>();

        if (GetComponent<ActorController>().IsTagged)
        {
            int nearestPlayerIndex = 0;

            float currentDistance = 0;
            float nearestDistance = 0;

            for (int i = 0; i < gameController.players.Count; i++)
            {
                if (gameController.players[i] != GetComponent<ActorController>())
                {
                    currentDistance = Vector3.Distance(transform.position, gameController.players[i].transform.position);

                    if (currentDistance < nearestDistance)
                    {
                        nearestDistance = currentDistance;

                        nearestPlayerIndex = i;
                    }
                }
            }
        }

        return base.Execute();
    }
}
