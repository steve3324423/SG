using UnityEngine;

namespace SightMaster.Scripts.Shop
{
    public class WeaponToBuy : MonoBehaviour
    {
        [SerializeField] private int _price;
        [SerializeField] private int _id;

        public int Id => _id;
        public int Price => _price;
    }
}