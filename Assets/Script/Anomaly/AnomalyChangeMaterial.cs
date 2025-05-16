using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyChangeTexture", menuName = "Scriptable Objects/AnomalyChangeTexture")]
public class AnomalyChangeM : AnomalyAction
{
    public float TextureBlending;
    public float Hue;

    public override void Execute(Item me)
    {
        me.anomalyMaterial.SetFloat("_TextureBlending", TextureBlending);
        me.anomalyMaterial.SetFloat("_Hue", Hue);
    }
}
