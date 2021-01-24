using UnityEngine;

[System.Serializable]
public class PlayerReferences
{
    [SerializeField]
    private GameObject[] _weaponObjects;

    public GameObject[] WeaponObjects
    {
        get => _weaponObjects;
        set => _weaponObjects = value;
    }
}
