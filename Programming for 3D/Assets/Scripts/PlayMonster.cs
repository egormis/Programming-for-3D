using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMonster : MonoBehaviour
{
    [SerializeField] private Animator monster = null;
    public void SetMonsterActive(bool activate) {
        if (activate) {
            monster.Play("Scene 2", 0, 0.0f);
        }
    }
}
