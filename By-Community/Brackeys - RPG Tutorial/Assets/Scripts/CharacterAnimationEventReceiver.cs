using UnityEngine;

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    public CharacterCombat combat;

    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }
}
