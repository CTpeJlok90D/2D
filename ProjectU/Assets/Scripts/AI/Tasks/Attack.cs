using UnityEngine;

[RequireComponent(typeof(AIShoot))]
public class Attack : Task
{
    [SerializeField] private Transform _danguresObject;
    private AIShoot _aiShoot;

    public override void DoIt()
    {
        _aiShoot.Shoot(_danguresObject);
    }

    public void SetDanguresObject(Transform _newObject)
    {
        _danguresObject = _newObject;
    }

    protected override void Awake()
    {
        base.Awake();
        _aiShoot = GetComponent<AIShoot>();
    }
}
