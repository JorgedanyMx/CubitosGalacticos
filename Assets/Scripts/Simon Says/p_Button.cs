using UnityEngine;

public class p_Button : MonoBehaviour, p_IButton
{
    public int number;
    int p_IButton.Clicked()
    {
        return number;
    }
}
