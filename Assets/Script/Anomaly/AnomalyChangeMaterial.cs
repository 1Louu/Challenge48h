using UnityEngine;

[CreateAssetMenu(fileName = "AnomalyChangeTexture", menuName = "Scriptable Objects/AnomalyChangeTexture")]
public class AnomalyChangeM : AnomalyAction
{
    public float TextureBlending;

    public override void Execute(Item me)
    {
        me.ChangeText(TextureBlending);
    }
}
