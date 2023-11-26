using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "SpriteShip", order = 1)]


public class SpriteShip : ScriptableObject
{
    [SerializeField] Sprite life66;
    [SerializeField] Sprite life33;
    [SerializeField] Sprite life0;

    #region Properties
    public Sprite Life66
    {
        get
        {
            return life66;
        }
    }

    public Sprite Life33
    {
        get
        {
            return life33;
        }
    }

    public Sprite Life0
    {
        get
        {
            return life0;
        }
    }
    #endregion
}
