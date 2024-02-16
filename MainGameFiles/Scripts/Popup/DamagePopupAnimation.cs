using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopupAnimation : MonoBehaviour
{
    public AnimationCurve opacityCurve;
    public AnimationCurve scaleCurve;
    public AnimationCurve hieghtCurve;

    private TextMeshPro tmp;
    private float time = 0;

    private Vector3 origin;
    private void Awake()
    {
        tmp = transform.GetComponent<TextMeshPro>();
        origin = transform.position;
    }

    private void Update()
    {
        tmp.color = new Color(1, 1, 1, opacityCurve.Evaluate(time));
        transform.localScale = Vector3.one * scaleCurve.Evaluate(time);
        transform.position = origin + new Vector3(0, 1 + hieghtCurve.Evaluate(time), 0);
        time += Time.deltaTime;
    }
}
