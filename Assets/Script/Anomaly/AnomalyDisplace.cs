using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyDisplace", menuName = "Anomaly/Anomaly Displace")]
public class AnomalyDisplace : AnomalyAction
{
    [Header("Anomaly Basis")]
    public Vector3 definedPosition;
    public Quaternion definedRotation;
    public Vector3 definedScale;
    public override void Execute(Item me)
    {
        me.transform.position.Set(this.definedPosition.x, this.definedPosition.y, this.definedPosition.z);
        me.transform.rotation = this.definedRotation;
        me.transform.localScale = this.definedScale;
    }
}
