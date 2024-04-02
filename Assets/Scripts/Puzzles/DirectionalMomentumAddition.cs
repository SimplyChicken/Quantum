using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMomentumAddition : MonoBehaviour
{

    [SerializeField] Vector2 direction;
    [SerializeField] float strength;
    [SerializeField] bool active;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("active", active);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void toggleActive()
    {
        active = !active;
        if (animator != null)
        {
            animator.SetBool("active", active);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.WorldAddMomentum(direction * strength);
        }
    }
}
