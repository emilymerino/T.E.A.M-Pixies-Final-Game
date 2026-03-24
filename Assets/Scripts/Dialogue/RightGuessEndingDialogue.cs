using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RightGuessEndingDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    public GameObject fadeOutTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject eloisePointing;
    public GameObject louNeutral;
    public GameObject louLookingOff;
    public GameObject louNervous;
    public GameObject louCaught;
    public GameObject archieNeutral;
    public GameObject archieSurprised;
    public GameObject quinton;
    public GameObject zeke;
    public GameObject missEvelynNeutral;
    public GameObject missEvelynStern;

    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        fadeOutTransition.SetActive(false);
        mainText.SetActive(false);
        textBox.SetActive(false);

        eloiseNeutral.SetActive(false);
        eloiseSuspicious.SetActive(false);
        eloisePointing.SetActive(false);
        louNeutral.SetActive(false);
        louLookingOff.SetActive(false);
        louNervous.SetActive(false);
        louCaught.SetActive(false);
        archieNeutral.SetActive(false);
        archieSurprised.SetActive(false);
        quinton.SetActive(false);
        zeke.SetActive(false);
        missEvelynNeutral.SetActive(false);
        missEvelynStern.SetActive(false);

        StartCoroutine(DialogueStart());
    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "The one who killed Mei..."));
        eloiseNeutral.SetActive(false);
        eloisePointing.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Has to be you, Lou!"));
        eloisePointing.SetActive(false);
        louCaught.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "WHAT!?"));
        louCaught.SetActive(false);
        quinton.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Wait hold on, Eloise! We can’t just go around accusing people like that!"));
        quinton.SetActive(false);
        zeke.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Yeah that… seems to be really sudden. Especially when Archie’s right there."));
        zeke.SetActive(false);
        archieSurprised.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "Hey! I’m telling you, I didn’t do anything!"));
        eloiseNeutral.SetActive(true);
        archieSurprised.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "It couldn’t have been Archie. Mei was killed somewhere in the west corridor and Quinton passed by him in the east corridor when getting something for Miss Evelyn."));
        yield return StartCoroutine(currentDialogue("Eloise", "You did see Quinton, right Archie?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "I… I did."));
        eloiseNeutral.SetActive(true);
        archieNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Not only that, Miss Evelyn saw Zeke sometime before the meeting started which rules them out."));
        eloiseNeutral.SetActive(false);
        missEvelynNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "That is correct."));
        missEvelynNeutral.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Hey wait a minute! I also saw Archie and he was walking in the direction of the bathroom."));
        yield return StartCoroutine(currentDialogue("Lou", "How do you explain that?"));
        louNervous.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "What? But I never went anywhere near the bathroom…"));
        archieNeutral.SetActive(false);
        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "You lied, Lou."));
        eloiseSuspicious.SetActive(false);
        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Earlier you mentioned that you thought Archie wanted to catch Mei alone to confess his feelings."));
        yield return StartCoroutine(currentDialogue("Eloise", "However, no one knew Archie had feelings for Mei… Unless they read the love letter Mei had on her person."));
        eloiseNeutral.SetActive(false);
        louCaught.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "...!"));
        eloiseNeutral.SetActive(true);
        louCaught.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "You wanted to pin the murder on Archie, so you planted his love letter along with the missing transfer records in the storage room after reading Quinton’s note to Mei."));
        yield return StartCoroutine(currentDialogue("Eloise", "You lied so you could throw Archie under the bus."));
        eloiseNeutral.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "T-that still doesn’t prove I did it!"));
        eloiseNeutral.SetActive(true);
        louNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "That mark on your hand."));
        eloiseNeutral.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "W-what…?"));
        eloiseNeutral.SetActive(true);
        louNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Whoever murdered Mei was a vampire, she had bite marks on her neck as evidence."));
        yield return StartCoroutine(currentDialogue("Eloise", "Vampires are known to not only burn from the sun… but also from silver which was on Mei’s person."));
        yield return StartCoroutine(currentDialogue("Eloise", "You got hurt from Mei’s silver rings when you were killing her."));
        yield return StartCoroutine(currentDialogue("Eloise", " I find it hard to believe that the mark on your hand can come from a simple basketball injury."));
        eloiseNeutral.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "That’s…"));
        eloiseNeutral.SetActive(true);
        louNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "And if you need even more proof, I never mentioned exactly where Mei was murdered. So how did you know she died in the bathroom?"));
        eloiseNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Everyone", "…"));
        zeke.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "So it really was you, Lou."));
        zeke.SetActive(false);
        quinton.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Unbelievable."));
        quinton.SetActive(false);
        archieSurprised.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "Why… Why would you do that!?"));
        archieSurprised.SetActive(false);
        louNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "I-I… This is…"));
        yield return StartCoroutine(currentDialogue("Lou", "…"));
        yield return StartCoroutine(currentDialogue("Lou", "Fine. Yeah, I did murder her."));
        louNervous.SetActive(false);
        archieSurprised.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "But… But why? She didn’t have to die!"));
        archieSurprised.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Because she found out the truth"));
        yield return StartCoroutine(currentDialogue("Lou", "I was stealing the funds so I could get a stable supply of blood for myself. Mei knew about it and I couldn’t let that get out."));
        louNeutral.SetActive(false);
        louLookingOff.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "So I had to shut her up for good."));
        louLookingOff.SetActive(false);
        yield return StartCoroutine(currentDialogue("Everyone", "…"));
        missEvelynStern.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Your actions will have dire consequences, Lou. I will promptly let the authorities know about what you did."));

        textBox.SetActive(false);
        mainText.SetActive(false);
        fadeOutTransition.SetActive(true);
        yield return new WaitForSeconds(2);
        missEvelynStern.SetActive(false);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", "The police eventually came and arrested Lou."));
        yield return StartCoroutine(currentDialogue("", "Eloise should feel good. She found Mei’s killer and got justice."));
        yield return StartCoroutine(currentDialogue("", "But despite everything, she felt nothing. It didn’t bring Mei back in the end."));
        yield return StartCoroutine(currentDialogue("", "School was shut down for a while after the events which gave Eloise a lot of time to think."));
        yield return StartCoroutine(currentDialogue("", "Think about Mei, think about Lou, think about how she found those clues and connected them together herself."));
        yield return StartCoroutine(currentDialogue("", "Eloise never knew what she wanted to be in the future, but a clearer image was starting to form."));
        yield return StartCoroutine(currentDialogue("Eloise", "<i>A detective…</i>"));
        yield return StartCoroutine(currentDialogue("Eloise", "<i>I wonder if Mei would be proud of me if I decided to continue down this path.</i>"));
    }

    IEnumerator currentDialogue(string name, string dialogue)
    {
        mainText.GetComponent<TMP_Text>().text = dialogue;
        charName.GetComponent<TMP_Text>().text = name;

        while (skipped == false)
        {
            yield return new WaitForSeconds(0.1f);
        }

        skipped = false;
        Debug.Log("Skipped dialogue");
        yield break;

    }

}
