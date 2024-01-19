using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX; // Add this namespace to use the Visual Effect component

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private Animator monster = null;
    [SerializeField] private DissolveEnemy dissolveEnemy = null;
    [SerializeField] private VisualEffect dissolveVFX = null; // Reference to the Visual Effect component

    private Dictionary<int, string> animationMap = new Dictionary<int, string>();

    void Start()
    {
        animationMap.Add(2, "Scene 2");
        animationMap.Add(5, "First Screemer");

        monster.Play("Scene 1", 0, 0.0f);
        dissolveVFX.Stop();
    }

    public void PlayMonster(int num)
    {
        if (animationMap.TryGetValue(num, out string animationName))
        {
            monster.Play(animationName, 0, 0.0f);
            
            // Start coroutine to check for the end of the animation
            if (animationName == "First Screemer")
            {
                StartCoroutine(WaitForAnimation(monster, animationName));
            }
        }
        else
        {
            Debug.Log($"No animation available for number: {num}");
        }
    }

    private IEnumerator WaitForAnimation(Animator animator, string animationName)
    {
        // Wait until the animation starts
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) == false);

        // Wait until the animation finishes
        yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);

        // After the animation finishes, call DissolveMonster and play the dissolve VFX
        if (dissolveEnemy != null)
        {
            dissolveEnemy.DissolveMonster();
            // Play the visual effect here
            dissolveVFX.Play();
        }
    }
}




