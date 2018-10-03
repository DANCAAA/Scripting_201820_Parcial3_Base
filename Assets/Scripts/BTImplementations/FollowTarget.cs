using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Task that instructs ControlledAI to follow its designated 'target'
/// </summary>
public class FollowTarget : Task
{
    public override bool Execute()
    {
        Debug.Log("FollowTarget :: Execute");

        GameController gameController = FindObjectOfType<GameController>();

        if (GetComponent<ActorController>().IsTagged)
        {
            int randomIndex = 0;

            do
            {
                randomIndex = Random.Range(0, gameController.players.Count);

            } while (gameController.players[randomIndex] != GetComponent<ActorController>() &&
                     gameController.players[randomIndex] != gameController.lastPlayerTagged);

            GetComponent<NavMeshAgent>().SetDestination(gameController.players[randomIndex].transform.position);
        }

        return base.Execute();
    }
}