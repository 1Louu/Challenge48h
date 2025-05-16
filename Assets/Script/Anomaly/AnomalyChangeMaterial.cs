using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyChangeMaterial1", menuName = "Anomaly/AnomalyChangeMaterial1")]
public class AnomalyChangeMaterial : AnomalyAction
{
    public Material material;

    public override void Execute(Item me)
    {
        me.GetComponent<MeshRenderer> ().material = material;
        Debug.Log ("AnomalyChangeMaterial executed");
    }

}
