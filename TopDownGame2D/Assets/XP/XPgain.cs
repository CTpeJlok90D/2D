using UnityEngine;

public class XPgain : MonoBehaviour
{
    [SerializeField] private int _count = 10;
    private XPcontainer _container;

    public int Count => _count;

    public void SetLastHittedPlayer(XPcontainer xpContainer)
    {
        _container = xpContainer;
    }

    public void GainXP()
    {
        _container.XP += _count;
        Destroy(this);
    }
}
