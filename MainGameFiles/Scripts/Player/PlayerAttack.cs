using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<GameObject> skills = new();

    public void PerformSkill(int skillIndex, int time)
    {
        skills[skillIndex].SetActive(true);
        StartCoroutine(SetSkillDesactive(skillIndex, time));
    }


    private IEnumerator SetSkillDesactive(int skillIndex, int time)
    {
        yield return new WaitForSeconds(time);
        skills[skillIndex].SetActive(false);
    }
}
