using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }

    private int _appleCount;

    [SerializeField]
    private TMP_Text appleText;

    public void AddApple()
    {
        _appleCount++;
        appleText.text = _appleCount.ToString();
    }
}
