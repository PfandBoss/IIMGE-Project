using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


public class FighterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FirstPersonControllerInput firstPersonControllerInput;
    [SerializeField] private FighterStats fighterStats;
 
    [System.Serializable]
    private class Hand
    {
        public GameObject handObj;
        public Color baseColor;
        public Color rechargeColor;
        public GameObject initialPos;
        public GameObject gotoPos;
    }
    
    [SerializeField] private Hand rightHand;
    [SerializeField] private Hand leftHand;

    private CoroutineQueue coroutineQueue;
    private Queue<AttackType> ComboQ = new Queue<AttackType>();

    private enum AttackType
    {
        Left,
        Right,
    }

    private float comboCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        coroutineQueue = new CoroutineQueue(this);
        coroutineQueue.StartLoop();

        if (gameObject.layer != LayerMask.NameToLayer("Player")) 
            return;
        
        var leftLatch = LatchObservables.Latch(this.UpdateAsObservable(), firstPersonControllerInput.LeftPunch, false)
            .Where(data => data)
            .Select(input => AttackType.Left);

        var rightLatch = LatchObservables.Latch(this.UpdateAsObservable(), firstPersonControllerInput.RightPunch, false)
            .Where(data => data)
            .Select(input => AttackType.Right);

        leftLatch.Merge(rightLatch).Buffer(TimeSpan.FromMilliseconds(500)).Where(data => data.Count > 3)
             .Subscribe(inputs =>
             {
                 if (comboCooldown > 0)
                     return;

                 foreach (var i in inputs)
                 {
                     if (i is AttackType.Left)
                     {
                         ComboQ.Enqueue(AttackType.Left);
                     }
                     else if (i is AttackType.Right)
                     {
                         ComboQ.Enqueue(AttackType.Right);
                     }
                 }
             });

        leftLatch.Merge(rightLatch)
            .Subscribe(input =>
            {
                if (coroutineQueue.Count > 0)
                    return;

                if (input is AttackType.Left)
                {
                    coroutineQueue.EnqueueAction(Punch(AttackType.Left, fighterStats.punchSpeed));
                    coroutineQueue.EnqueueWait(fighterStats.punchSpeed);
                }
                else if (input is AttackType.Right)
                {
                    coroutineQueue.EnqueueAction(Punch(AttackType.Right, fighterStats.punchSpeed));
                    coroutineQueue.EnqueueWait(fighterStats.punchSpeed);
                }
            });
    }

    private void Update()
    {
        if(comboCooldown > 0)
        {
            comboCooldown -= Time.deltaTime;
            var ratio = Mathf.Abs(Mathf.Sin(Time.time * 4));
            leftHand.handObj.GetComponent<Renderer>().material.color = Color.Lerp(leftHand.baseColor, leftHand.rechargeColor, ratio);
            rightHand.handObj.GetComponent<Renderer>().material.color = Color.Lerp(rightHand.baseColor, rightHand.rechargeColor, ratio);
        }
        else
        {
            if(leftHand.handObj.GetComponent<Renderer>().material.color != leftHand.baseColor)
            {
                leftHand.handObj.GetComponent<Renderer>().material.color = leftHand.baseColor;
                rightHand.handObj.GetComponent<Renderer>().material.color = rightHand.baseColor;
            }
        }

        if (ComboQ.Count == 0 || coroutineQueue.Count > 0)
            return;

        comboCooldown = fighterStats.comboCooldown;

        foreach (var q in ComboQ)
        {
            coroutineQueue.EnqueueAction(Punch(q, fighterStats.punchSpeed / (ComboQ.Count), ComboQ.ToList().IndexOf(q) + 1));
            coroutineQueue.EnqueueWait(fighterStats.punchSpeed / (ComboQ.Count));
        }

        ComboQ.Clear();
    }

    private IEnumerator Punch(AttackType type, float punchTime, int comboHit = 1)
    {
        Hand hand = leftHand;
        if (type is AttackType.Right)
            hand = rightHand;

        float elapsedTime = 0;
        while (elapsedTime < punchTime / 2)
        {
            hand.handObj.transform.position = Vector3.Lerp(hand.initialPos.transform.position, hand.gotoPos.transform.position, (elapsedTime / (punchTime / 2)));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        yield return new WaitForSeconds(punchTime / 2);

        RaycastHit raycastHit;   
        if(Physics.Raycast(transform.position, transform.forward * 2.5f, out raycastHit, 2f))
        {
            raycastHit.collider.gameObject.SendMessage("ApplyDamage", fighterStats.baseDamage * comboHit, SendMessageOptions.DontRequireReceiver);
        }

        //Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward), Color.red, 2);

        elapsedTime = 0;

        while (elapsedTime < punchTime / 2)
        {
            hand.handObj.transform.position = Vector3.Lerp(hand.gotoPos.transform.position, hand.initialPos.transform.position, (elapsedTime / (punchTime / 2)));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        hand.handObj.transform.position = hand.initialPos.transform.position;
        yield return null;
    }

    
}
