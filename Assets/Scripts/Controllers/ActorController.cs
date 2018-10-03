using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class ActorController : MonoBehaviour
{
    protected NavMeshAgent agent;

    [SerializeField]
    protected Color baseColor = Color.blue;
    [SerializeField]
    protected Color taggedColor = Color.red;

    protected MeshRenderer renderer;

    public delegate void OnActorTagged(bool val);

    public OnActorTagged onActorTagged;

    public bool IsTagged { get; protected set; }

    public int taggedCount
    {
        get; private set;
    }

    private void Awake()
    {
        FindObjectOfType<GameController>().onGameEnd += Stop;
    }

    // Use this for initialization
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<MeshRenderer>();

        SetTagged(false);

        onActorTagged += SetTagged;
    }

    protected abstract Vector3 GetTargetLocation();

    protected void MoveActor()
    {
        agent.SetDestination(GetTargetLocation());
    }

    protected void OnCollisionEnter(Collision collision)
    {
        ActorController otherActor = collision.gameObject.GetComponent<ActorController>();

        if (otherActor != null)
        {
            print("collided!");

            otherActor.onActorTagged(true);
            onActorTagged(false);
        }
    }

    protected virtual void OnDestroy()
    {
        agent = null;
        renderer = null;
        onActorTagged -= SetTagged;
    }

    private void SetTagged(bool val)
    {
        IsTagged = val;

        if (IsTagged)
        {
            taggedCount++;

            FindObjectOfType<GameController>().SetCurrentPlayerTagged(this);
        }

        if (renderer)
        {
            print(string.Format("Changing color to {0}", gameObject.name));

            renderer.material.color = val ? taggedColor : baseColor;
        }
    }

    private void Stop()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        if (agent != null)
            agent.enabled = false;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
            rigidbody.isKinematic = true;

        // TODO Time scale 0 ???
    }
}