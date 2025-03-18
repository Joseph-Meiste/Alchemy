using UnityEngine;

public class DanceAnimationController : MonoBehaviour
{
    public Animator animator;
    public float speed;

    void Start()
    {
        animator.speed = speed;
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Ensure the Animator is not in a paused or stopped state
        if (animator != null)
        {
            // Play the dance animation immediately (assuming the animation is named "Dance")
            animator.Play("Dance");  // Replace "Dance" with the name of your animation clip

            // Set the animation to loop (if needed)
            animator.SetBool("IsLooping", true);  // You can set parameters in the Animator controller if you want control
        }
    }
}
