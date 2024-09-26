using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();


        if (controller != null)
        {
            controller.changeHealth(-1 * damage);
        }
    }
}
