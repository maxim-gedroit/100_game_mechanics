using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public Data[] _Datas;
    
    [System.Serializable]
    public class Data
    {
        public string Id;
        public Transform Weapon;
    }
}
