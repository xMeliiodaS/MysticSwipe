using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<GameObject> skills = new();


    /// <summary>
    /// Activates a specific skill for a certain duration and then deactivates it.
    /// </summary>
    /// <param name="skillIndex">The index of the skill to activate.</param>
    /// <param name="time">The duration for which the skill remains active.</param>
    public void DoSkill(int skillIndex)
    {
        skills[skillIndex].SetActive(true);
        StartCoroutine(SetSkillDesactive(skillIndex, 2));

        skills[skillIndex].GetComponent<SphereCollider>().enabled = true;
    }


    /// <summary>
    /// Deactivates a skill after a specified duration.
    /// </summary>
    /// <param name="skillIndex">The index of the skill to deactivate.</param>
    /// <param name="time">The duration before the skill is deactivated.</param>
    /// <returns></returns>
    private IEnumerator SetSkillDesactive(int skillIndex, int time)
    {
        yield return new WaitForSeconds(time);
        skills[skillIndex].SetActive(false);

        skills[skillIndex].GetComponent<SphereCollider>().enabled = false;
    }
}
