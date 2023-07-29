
/*
class Dialog : MonoBehaviour {


    private float dialogDuration = 2f;
    private bool optionSeleted = false;
    private float currentTime = 0f;

    // <<set $decision1 to false>> 
    // Hola!
    // Quue tal!
    // <AwaitDialgue 1 conversasion1 "decision1">
    // <<if $decision1 == true>>
        // AJdklAJdlk jasdljladslk jlkas
    // <<else>>
        // JASKJDk hadha shdkahdjshjakd

    [YarnCommand("AwaitDialgue")]
    
    IEnumerator awaitingDialogue(float duration, string decision) {
        while (true) {
            currentTime += 0.16f
            // Yarn.setVariable(decision, true)
            if (optionSeleted == false || currentTime > duration) 
            {
                yield return new WaitForSeconds(0.16f);
            }
            else 
            {
                yield break   
            }
        }
    }

}
*/