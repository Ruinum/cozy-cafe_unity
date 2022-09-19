using UnityEngine;

public class MoodSystem : MonoBehaviour {
    public static MoodSystem Singletone;
    public float CustomersMood { get; set; }

    [SerializeField] private float minMood;
    [SerializeField] private float maxMood;

    private void Awake() {
        Singletone = this;
        CustomersMood = 1f;
    }

    public void IncreaseMood(float amount) {
        if (CustomersMood + amount <= maxMood) {
            CustomersMood += amount;
        }
        else {
            CustomersMood = maxMood;
        }
    }

    public void DecreaseMood(float amount) {
        if (CustomersMood - amount >= minMood) {
            CustomersMood -= amount;
        }
        else {
            CustomersMood = minMood;
        }
    }
}