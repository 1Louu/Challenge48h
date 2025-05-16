using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyChangeTexture", menuName = "Anomaly/AnomalyChangeTexture")]
public class AnomalyChangeM : AnomalyAction
{
    public float TextureBlending;
    public float Hue;

    public override void Execute(Item me)
    {
        me.Material.SetFloat("_TextureBlending", TextureBlending);
        me.Material.SetFloat("_Hue", Hue);
    }
}
