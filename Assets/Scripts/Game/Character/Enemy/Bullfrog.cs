using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullfrog : Enemy
{
    private float moveSeconds = 1.17f;
    private float seconds = 0;
    private Coroutine moveCoroutine;

    public override void Move()
    {
        if (attackRange.Attackable == false)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    public virtual void OnMoveAnimation()
    {
        moveCoroutine = StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        Vector3 origin = transform.position;
        Vector3 dest = origin + (Vector3.left * moveSpeed * moveSeconds);

        seconds = 0;
        while (seconds < moveSeconds)
        {
            seconds = Mathf.Min(seconds + Time.smoothDeltaTime, moveSeconds);
            float ratio = EaseOutCubic(seconds / moveSeconds);
            transform.position = new Vector3(Mathf.Lerp(origin.x, dest.x, ratio), transform.position.y, transform.position.z);
            yield return null;
        }
    }

    private float EaseOutCubic(float ratio)
    {
        return 1 - Mathf.Pow(1 - ratio, 3);
    }
}
