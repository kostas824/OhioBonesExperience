using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BatterySocket : MonoBehaviour
{
    public AudioSource electricSound; // Ο ήχος ηλεκτρισμού που παίζεται στο Battery Holder
    public ParticleSystem electricSparks; // Το Particle System για τους σπινθήρες
    private XRSocketInteractor socketInteractor; // Το XR Socket Interactor

    // Νέο AudioSource για το γειτονικό GameObject με διαφορετικό ήχο
    public AudioSource externalElectricSound; // Ο ήχος που θα παίξει στο γειτονικό GameObject

    public float delayBeforeExternalSound = 1f; // Καθυστέρηση πριν ακουστεί ο ήχος του externalElectricSound

    void Start()
    {
        // Παίρνουμε το XRSocketInteractor του αντικειμένου
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.selectEntered.AddListener(OnBatteryInserted); // Προσθήκη Listener για την εισαγωγή της μπαταρίας
    }

    // Μέθοδος που καλείται όταν η μπαταρία μπαίνει στη θήκη
    private void OnBatteryInserted(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Battery")) // Ελέγχουμε αν το αντικείμενο είναι μπαταρία
        {
            // Παίζει τον ήχο του ηλεκτρισμού στο Battery Holder
            electricSound.Play();

            // Παίζει το Particle System για τους σπινθήρες
            electricSparks.Play();

            // Παίζει τον ήχο του externalElectricSound μετά από μια καθυστέρηση
            if (externalElectricSound != null)
            {
                Invoke("PlayExternalElectricSound", delayBeforeExternalSound);
            }

            // Σταματάμε το Particle System μετά από 5 δευτερόλεπτα
            Invoke("StopParticles", 5f); // Θα το σταματήσει μετά από 5 δευτερόλεπτα
        }
    }

    // Μέθοδος για να παίξει ο ήχος του externalElectricSound με καθυστέρηση
    private void PlayExternalElectricSound()
    {
        externalElectricSound.Play();
    }

    // Μέθοδος για να σταματήσει το Particle System μετά από 5 δευτερόλεπτα
    void StopParticles()
    {
        electricSparks.Stop(); // Σταματάει το Particle System
    }
}








