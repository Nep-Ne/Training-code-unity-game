using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming
    }
    private State state;
    //private Animator animator;
    private EnemyPathfinding enemyPathfinding;
    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
        //animator = GetComponent<Animator>();
    }
    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }
    private IEnumerator RoamingRoutine()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
            enemyPathfinding.StopMoving();
            yield return new WaitForSeconds(2f);
        }
    }
    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}