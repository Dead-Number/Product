using UnityEngine;

[CreateAssetMenu]
public class DialogueAsset : ScriptableObject
{
    [TextArea(2, 2)]
    public string[] dialogues;
}
