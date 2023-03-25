using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackRange : MonoBehaviour
{
    public bool Attackable { get; private set; }

    // TODO Enter와 Exit을 활용해 enemy의 카운트를 올리고 내리는 방식으로 제대로 동작하는지 테스트 필요
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Attackable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Attackable = false;
        }
    }
}
