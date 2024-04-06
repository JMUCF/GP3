using UnityEngine;

public class ElevatorAnimationTrigger : MonoBehaviour

{
    public GameObject animatedObject1; // Reference to the first GameObject with the Animator component
    public GameObject animatedObject2; // Reference to the second GameObject with the Animator component

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player or another object you want to trigger the animation
        if (other.CompareTag("Player"))
        {
            // Trigger the animations on both specified GameObjects
            TriggerAnimation(animatedObject1);
            TriggerAnimation(animatedObject2);
        }
    }

    private void TriggerAnimation(GameObject obj)
    {
        Animator animator = obj.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("TriggerElevator");
            animator.SetTrigger("TriggerElevator1");
        }
        else
        {
            Debug.LogWarning("No Animator component found on the specified GameObject.");
        }
    }
}
