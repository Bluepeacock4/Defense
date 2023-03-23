using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackRange : MonoBehaviour
{
    public bool Attackable { get; private set; }

    // TODO Enter�� Exit�� Ȱ���� enemy�� ī��Ʈ�� �ø��� ������ ������� ����� �����ϴ��� �׽�Ʈ �ʿ�
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
