using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public bool blue_button = false;
    public bool yellow_button = false;
    public bool red_button = false;

    public bool blue_activated = false;
    public bool yellow_activated = false;
    public bool red_activated = false;

    public GameObject blue_light, yellow_light, red_light;

    public GameObject PressFtoInteract;

    public Animator door3animator;

    void Update()
    {
        if (yellow_button == true & Input.GetKeyDown(KeyCode.F) && blue_activated == true)
        {
            yellow_light.SetActive(true);
            yellow_activated = true;
        }

        if (blue_button == true & Input.GetKeyDown(KeyCode.F))
        {
            blue_light.SetActive(true);
            blue_activated = true;
        }

        if (red_button == true & Input.GetKeyDown(KeyCode.F) && blue_activated == true && yellow_activated == true)
        {
            red_light.SetActive(true);
            red_activated = true;
        }

        if (blue_activated == true && yellow_activated == true && red_activated == true)
        {
            door3animator.SetBool("DoorOpen3", true);
        }

        if (blue_button == true || red_button == true || yellow_button == true)
        {
            PressFtoInteract.SetActive(true);
        } 
        else
        {
            PressFtoInteract.SetActive(false);
        }
    }
}