using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<GameObject> skills = new();


    /// <summary>
    /// Activates a specific skill using animation's event for a certain duration then deactivates it.
    /// </summary>
    /// <param name="skillIndex">The index of the skill to activate.</param>
    /// <param name="time">The duration for which the skill remains active.</param>
    public void DoSkill(int skillIndex)
    {
        GameObject skill = skills[skillIndex];

        skill.SetActive(true);
        skill.GetComponent<SphereCollider>().enabled = true;

        StartCoroutine(SetSkillDesactive(skillIndex, 1.3f));
    }


    /// <summary>
    /// Deactivates a skill's collider.
    /// </summary>
    /// <param name="skillIndex">The index of the skill to deactivate.</param>
    /// <param name="time">The duration before the skill is deactivated.</param>
    /// <returns></returns>
    public void DisableSkillCollider(int skillIndex)
    {
        skills[skillIndex].GetComponent<SphereCollider>().enabled = false;
    }


    /// <summary>
    /// Deactivates a skill after a specified duration.
    /// </summary>
    /// <param name="skillIndex">The index of the skill to deactivate.</param>
    /// <param name="time">The duration before the skill is deactivated.</param>
    /// <returns></returns>
    private IEnumerator SetSkillDesactive(int skillIndex, float time)
    {
        yield return new WaitForSeconds(time);
        skills[skillIndex].SetActive(false);
    }
}
