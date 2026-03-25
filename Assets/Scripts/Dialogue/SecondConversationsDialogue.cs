using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondConversationsDialogue : MonoBehaviour
{
    public GameObject fadeInTransition;
    [SerializeField] GameObject textBox;
    public GameObject mainText;
    public GameObject charName;

    public bool skipped = false;

    public bool dialogueFinished = false;
    public string nextSceneName = "23-GuessTheVampire";

    public GameObject louInteraction;
    public GameObject archieInteraction;
    public GameObject quintonInteraction;
    public GameObject zekeInteraction;
    public GameObject missEvelynInteraction;
    public GameObject louGlow;
    public GameObject archieGlow;
    public GameObject quintonGlow;
    public GameObject zekeGlow;
    public GameObject missEvelynGlow;

    public bool louTalked;
    public bool archieTalked;
    public bool quintonTalked;
    public bool zekeTalked;
    public bool missEvelynTalked;

    public GameObject eloiseNeutral;
    public GameObject eloiseSuspicious;
    public GameObject louNeutral;
    public GameObject louLookingOff;
    public GameObject archieNeutral;
    public GameObject archieSurprised;
    public GameObject quintonNeutral;
    public GameObject quintonShocked;
    public GameObject zekeNeutral;
    public GameObject zekeNervous;
    public GameObject missEvelyn;


    // Start is called before the first frame update
    void Start()
    {
        fadeInTransition.SetActive(true);
        mainText.SetActive(false);
        textBox.SetActive(false);

        disableInteractions();

        louTalked = false;
        archieTalked = false;
        quintonTalked = false;
        zekeTalked = false;
        missEvelynTalked = false;

        disableSprites();

        StartCoroutine(DialogueStart());

    }

    IEnumerator DialogueStart()
    {
        yield return new WaitForSeconds(2);
        fadeInTransition.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        mainText.SetActive(true);

        yield return StartCoroutine(currentDialogue("", ""));

        StartCoroutine(continueStory());
    }

    IEnumerator continueStory()
    {
        mainText.SetActive(false);
        textBox.SetActive(false);

        enabledInteractions();


        yield return new WaitUntil(() => louTalked && archieTalked && quintonTalked && zekeTalked && missEvelynTalked);

        disableInteractions();

        mainText.SetActive(true);
        textBox.SetActive(true);

        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>The missing funds… the blood packets… the lies… Mei uncovered something before she died.</i>"));
        yield return StartCoroutine(currentDialogue("Eloise", "<i>One of you is hiding the truth.</i>"));
        dialogueFinished = true;
        yield return StartCoroutine(currentDialogue("", "<i>And I think I finally know who the vampire is.</i>"));
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
        if (dialogueFinished)
        {
            SceneManager.LoadScene(nextSceneName);
        }

        yield break;
    }

    //Character Conversations

    public IEnumerator louConversation()
    {
        disableInteractions();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "What were you up to before the meeting?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "I was in the west corridor putting some stuff away in my locker."));
        eloiseSuspicious.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>Hm... That's close to where the bathroom is.</i>"));
        eloiseSuspicious.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Before you ask, I did see Mei. We briefly exchanged glances."));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "What did she look like?"));
        eloiseNeutral.SetActive(false);
        louNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "Focused. Determined, like she'd already made up her mind about something."));
        yield return StartCoroutine(currentDialogue("Lou", "She was holding some sort of agenda close to her chest, like she didn't want anyone to see it."));
        eloiseNeutral.SetActive(true);
        louNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Did she say anything to you?"));
        eloiseNeutral.SetActive(false);
        louLookingOff.SetActive(true);
        yield return StartCoroutine(currentDialogue("Lou", "No. She just walked past."));
        louLookingOff.SetActive(false);
        louTalked = true;

        enabledInteractions();

        Debug.Log("Finished Lou's conversation");
    }

    public IEnumerator archieConversation()
    {
        disableInteractions();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Where were you before the meeting?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", "East corridor by myself. I know how that looks."));
        yield return StartCoroutine(currentDialogue("Archie", "Doesn’t help that I lost track of time and came late."));
        eloiseNeutral.SetActive(true);
        archieNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "When did you last speak to Mei?"));
        eloiseNeutral.SetActive(false);
        archieNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Archie", " Yesterday. I said some things I shouldn't have. I've been trying to clear my head ever since."));
        yield return StartCoroutine(currentDialogue("Archie", "I just… can’t believe this happened."));
        eloiseNeutral.SetActive(true);
        archieNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Yeah... me too."));
        eloiseNeutral.SetActive(false);
        archieTalked = true;

        enabledInteractions();

        Debug.Log("Finished Archie's conversation");
    }

    public IEnumerator quintonConversation()
    {
        disableInteractions();

        eloiseSuspicious.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "Where were you before the meeting?"));
        eloiseSuspicious.SetActive(false);
        quintonShocked.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "Wait, wait. Slow down!"));
        quintonShocked.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "I met her earlier this week."));
        yield return StartCoroutine(currentDialogue("Quinton", "But it was just to check some numbers on the council’s accounts. Something wasn’t adding up."));
        eloiseSuspicious.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Oh come on, Quinton"));
        eloiseSuspicious.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "She started acting weird with me. I feel like she found something out that she shouldn’t have, and told me she wasn’t going to confront it herself. That’s all."));
        eloiseNeutral.SetActive(true);
        quintonNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Confront who?"));
        eloiseNeutral.SetActive(false);
        quintonNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Quinton", "She didn’t tell me."));
        quintonNeutral.SetActive(false);
        quintonTalked = true;

        enabledInteractions();

        Debug.Log("Finished Quinton's conversation");
    }

    public IEnumerator zekeConversation()
    {
        disableInteractions();

        eloiseNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Eloise", "So you’re in charge of the funds aren't you?"));
        eloiseNeutral.SetActive(false);
        zekeNeutral.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "Y-yes… I manage the approvals."));
        eloiseSuspicious.SetActive(true);
        zekeNeutral.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "Seems like you were trying to cover your tracks."));
        eloiseSuspicious.SetActive(false);
        zekeNervous.SetActive(true);
        yield return StartCoroutine(currentDialogue("Zeke", "I… I didn’t mean to. I thought the notes were fine… I didn’t realize they were unusual."));
        eloiseSuspicious.SetActive(true);
        zekeNervous.SetActive(false);
        yield return StartCoroutine(currentDialogue("Eloise", "<i>He’s not normally this nervous… Something is definitely up.</i>"));
        eloiseSuspicious.SetActive(false);
        zekeTalked = true;

        enabledInteractions();

        Debug.Log("Finished Zeke's conversation");
    }

    public IEnumerator missEvelynConversation()
    {
        disableInteractions();

        missEvelyn.SetActive(true);
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "What did you mean when you said Mei was murdered?"));
        yield return StartCoroutine(currentDialogue("Eloise", "T-There was blood splattered everywhere and she wasn’t moving."));
        yield return StartCoroutine(currentDialogue("Eloise", "I saw bite marks on her neck… I think someone here did this to her. I think someone here is a vampire."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "A vampire? Don’t jump to dramatic conclusions, Eloise. This is serious."));
        yield return StartCoroutine(currentDialogue("Eloise", "I am serious!"));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Vampires. The fictional creatures who sucks human blood, the ones that are afraid of garlic, the ones that burn from the sun and silver."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "You do know how ridiculous you sound, right?"));
        yield return StartCoroutine(currentDialogue("Eloise", "Whatever. Don’t believe me for all I care. I’ll figure out who did this on my own."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "Normally, I’d advise you to refrain from doing such a thing and wait for the authorities to arrive."));
        yield return StartCoroutine(currentDialogue("Miss Evelyn", "However, something tells me you will do it anyways. Please do not be rash."));

        enabledInteractions();

        Debug.Log("Finished Miss Evelyn's conversation");
    }

    //Enable + Disable

    private void disableInteractions()
    {
        louInteraction.SetActive(false);
        archieInteraction.SetActive(false);
        quintonInteraction.SetActive(false);
        zekeInteraction.SetActive(false);
        missEvelynInteraction.SetActive(false);
        louGlow.SetActive(false);
        archieGlow.SetActive(false);
        quintonGlow.SetActive(false);
        zekeGlow.SetActive(false);
        missEvelynGlow.SetActive(false);

    }

    private void enabledInteractions()
    {
        louInteraction.SetActive(true);
        archieInteraction.SetActive(true);
        quintonInteraction.SetActive(true);
        zekeInteraction.SetActive(true);
        missEvelynInteraction.SetActive(true);
        louGlow.SetActive(true);
        archieGlow.SetActive(true);
        quintonGlow.SetActive(true);
        zekeGlow.SetActive(true);
        missEvelynGlow.SetActive(true);

    }
    private void disableSprites()
    {
        eloiseNeutral.SetActive(false);
        eloiseSuspicious.SetActive(false);
        louNeutral.SetActive(false);
        louLookingOff.SetActive(false);
        archieNeutral.SetActive(false);
        archieSurprised.SetActive(false);
        quintonNeutral.SetActive(false);
        quintonShocked.SetActive(false);
        zekeNeutral.SetActive(false);
        zekeNervous.SetActive(false);
        missEvelyn.SetActive(false);
    }
}