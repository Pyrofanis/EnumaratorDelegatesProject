using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAvoid : MonoBehaviour
{
    private bool Avoiding;

    private Vector3 whereToMove;

    private EnemieStats enemieStats;
    // Start is called before the first frame update
    void Start()
    {
           enemieStats= GetComponent<EnemieStats>();
        EnemiesMain.onEnemieStateChanger += CheckIfShouldAvoid;
    }
    private void CheckIfShouldAvoid(EnemiesMain.EnemieStates state)
    {
        if (state.Equals(EnemiesMain.EnemieStates.avoid))
        {
            Avoiding = true;
        }
        else
        {
            Avoiding = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Avoid(Avoiding);
        CalculateWhereToMove(Avoiding);
    }
    private void CalculateWhereToMove(bool shouldIkeepGoing)
    {   if (shouldIkeepGoing)
        {
            float playersHorizontalPosition = enemieStats.playerStats.transform.position.x;
            float distanceBettweenPlayerAndEnemie = transform.position.x - playersHorizontalPosition;
            if (distanceBettweenPlayerAndEnemie > 0)
            {
                whereToMove = transform.right;
            }
            else if (distanceBettweenPlayerAndEnemie != 0)
            {
                whereToMove = -transform.right;
            }
        }
      
        
    }
    private void Avoid(bool shouldIkeepGoing)
    {
       if (shouldIkeepGoing)
        {   float speed = enemieStats.speed * Time.deltaTime;
            Vector2 targetPosition = transform.position + whereToMove;
            enemieStats.enemiesRigidBody.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
        }
       
    }
}
