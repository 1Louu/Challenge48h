using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyChangeTexture", menuName = "Scriptable Objects/AnomalyChangeTexture")]
public class AnomalyChangeMaterial : AnomalyAction
{
    public string materialName;
    public float opacity;

    public virtual void Execute(Item Me)
    {
        Me.GetComponent<Renderer>().material.SetFloat("Opacity", opacity);
        Renderer[] list = Me.GetComponents<Renderer>();
        foreach (Renderer r in list)
        {
            if (r.material.name == materialName)
            {
                r.material.SetFloat("Opacity", opacity);
            }
        }
    }
}
