using UnityEngine;
using Player;

namespace Weapons 
{
    public abstract class Weapon : PickableItem
    {
        public abstract void Use();
    }
}