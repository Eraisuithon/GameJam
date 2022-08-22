using UnityEngine;

[CreateAssetMenu(menuName = "Settings/PlayerSettings")]
public class PlayerTypeSO : ScriptableObject
{
    public enum PlayerType { Player, Shooter }
    public PlayerType playerType;

}
