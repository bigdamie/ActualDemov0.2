using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Integer Value", fileName = "New Integer Value")]
public class IntegerValue : ScriptableObject
{
    public int value;
    [SerializeField] private int defaultValue;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
