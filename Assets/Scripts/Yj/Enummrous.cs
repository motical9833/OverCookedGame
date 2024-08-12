using UnityEngine;

namespace Enummrous
{
    public enum PlayerAnimState
    {
        None,
        Idle,
        Walk,
        Hold,
        HoldWalk,
        Dead,
        Wash,
        Chop,
        End
    }

    public enum GrabState
    {
        Release,
        Grab,
        End
    }

    public enum IngredientSort
    {
        Onion,
        Beef,
        Mushroom,
    }

    public static class CollisionCheck
    {
        public static bool Check(Bounds bounds, GameObject other)
        {
            Collider[] hitColliders = Physics.OverlapBox(bounds.center, bounds.extents, Quaternion.identity);

            foreach (Collider collider in hitColliders)
            {
                if (collider.transform.gameObject == other)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
