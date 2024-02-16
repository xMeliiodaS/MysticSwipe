using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private static DamagePopup instance;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        instance = this;
    }


    public static DamagePopup GetInstance()
    {
        return instance;
    }

    public static void SetInstance(DamagePopup value)
    {
        instance = value;
    }


    public void CreatePopup(Vector3 position, string text, Color color)
    {
        var popup = Instantiate(prefab, position, Quaternion.identity);
        var temp = popup.transform.GetComponent<TextMeshPro>();
        temp.text = text;
        temp.faceColor = color;

        // Destroy Timer
        Destroy(popup, 1f);
    }
}
