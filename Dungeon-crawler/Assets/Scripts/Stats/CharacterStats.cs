using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private GameManager gm;

    public int maxHealth = 100;
    public int currentHealth; //{ get; private set; }

    public Stat damage;
    public Stat armour;

    public event System.Action<int, int> OnHealthChanged;


    private void Awake()
    {
        currentHealth = maxHealth;
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.T))
        //{
        //    TakeDamage(10);
        //}
    }

    public void TakeDamage(int damage)
    {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
        Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, transform.name + " takes " + damage + " damage.", Color.red);

        OnHealthChanged?.Invoke(maxHealth, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, "Healed " + heal + " health.", Color.green);
    }
    public virtual void Die()
    {
        //Die in someway
        //This method is meant to be overwritten
        Debug.Log(transform.name + " has died.");
        Messenger.Instance.CreateMessage(gm.doDestroy, gm.destroyChatTime, gm.chatMessagePrefab, gm.chatMessageParent, transform.name + " has died.", Color.red);
    }

}
