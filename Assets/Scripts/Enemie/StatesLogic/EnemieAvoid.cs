using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAvoid : MonoBehaviour
{
    private bool Avoiding;

    private Vector3 whereToMove;

    private EnemieStats enemieStats;
    private EnemiesMain enemiesMain;
    private void Awake()
    {
        enemiesMain = GetComponent<EnemiesMain>();

    }
    // Start is called before the first frame update
    void Start()
    {
        enemieStats= GetComponent<EnemieStats>();
        enemiesMain.onEnemieStateChanger += CheckIfShouldAvoid;
        enemiesMain.onEnemieDirectionChange += CheckWhereToMove;
    }
    private void CheckIfShouldAvoid(EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.avoid))
        {
            Avoiding = true;
            Physics2D.IgnoreLayerCollision(8, 8);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 8,false);
            Avoiding = false;
        }
    }
    private void CheckWhereToMove(EnemiesMain.EnemieDirection direction)
    {
        if (direction.Equals(EnemiesMain.EnemieDirection.right))
        {
            whereToMove = transform.right;
        }
        else
        {
            whereToMove = -transform.right;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Avoid(Avoiding);
    }
   
    private void Avoid(bool shouldIkeepGoing)
    {
       if (shouldIkeepGoing)
        {
            float speed = enemieStats.speed * Time.deltaTime;
            Vector2 targetPosition = transform.position + whereToMove;
            enemieStats.enemiesRigidBody.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
        }

       
    }
}
