using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class Player : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent navMeshAgent;
    public ThirdPersonCharacter character;

    private Vector3 destinationPoint;

    private void Start()
    {
        navMeshAgent.updateRotation = false;
    }

    private void Update() {
        if(Input.GetMouseButton(0)){
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
                destinationPoint = hit.point;
            }
        }

        if (navMeshAgent.remainingDistance > .25f)
        {
            character.Move(navMeshAgent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
