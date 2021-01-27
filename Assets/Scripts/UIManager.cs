using System.Collections.Generic;
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
    [SerializeField]
    private Transform lifeParent;
    [SerializeField]
    private GameObject lifePrefab;

    private Stack<GameObject> lives = new Stack<GameObject>();
    
    public void AddApple()
    {
        _appleCount++;
        appleText.text = _appleCount.ToString();
    }

    public void AddLife(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            lives.Push(Instantiate(lifePrefab, lifeParent));
        }
    }

    public void RemoveLife()
    {
        Destroy(lives.Pop());
    }
}
