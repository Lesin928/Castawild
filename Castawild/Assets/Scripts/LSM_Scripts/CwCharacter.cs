using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// ĳ���� �߻� Ŭ����,
/// ��� ĳ���ʹ� �� Ŭ������ ��ӹ޾ƾ� �� 
/// </summary>
public abstract class CwCharacter : MonoBehaviour
{
    #region Character Info  
    [Header("Character Info")]
    [SerializeField] private string characterName; //ĳ���� �ĺ���
    [SerializeField] private float maxHp; //�ִ�ü��
    [SerializeField] private float currentHp; //���� ü��
    [SerializeField] private float armor; //����
    [SerializeField] private float attack; //���ݷ� 
    [SerializeField] private float moveSpeed; //�̵��ӵ� 
    #endregion
      
    #region Setters and Getters

    protected virtual string CharacterName
    {
        get => characterName;
        set => characterName = value;
    }
    ///<summary>
    ///�ִ�ü�� ���� �� ��ȯ �Լ�
    ///</summary>
    protected virtual float MaxHp
    {
        get => maxHp;
        set
        {
            maxHp = value;
            if (currentHp > maxHp)
                currentHp = value;
        }
    }

    ///<summary>
    ///����ü�� ��ȯ �Լ�
    ///</summary>
    public virtual float CurrentHp
    {
        get => currentHp;
        set => currentHp = value;
    }

    ///<summary>
    ///���� ���� �� ��ȯ �Լ�
    ///</summary>
    protected virtual float Armor
    {
        get => armor;
        set => armor = value;
    }

    ///<summary>
    ///���ݷ� ���� �� ��ȯ �Լ�
    ///</summary>
    protected virtual float Attack
    {
        get => attack;
        set => attack = value;
    } 
    ///<summary>
    ///�̵��ӵ� ���� �� ��ȯ �Լ�
    ///</summary>
    public virtual float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    #endregion

    /// <summary>    
    /// ���� ������ ������ ����ȭ �Լ� 
    /// </summary>
    /// <typeparam name="T">��ũ���ͺ� ������Ʈ Ÿ��</typeparam>
    /// <param name="data"> �������� ��ũ���ͺ� ������Ʈ </param>    
    protected virtual void CharacterInitialize<T>(T data) where T : CharacterData
    {
        CharacterName = data.characterName;
        MaxHp = data.maxHp;
        Armor = data.armor;
        Attack = data.attack;
        MoveSpeed = data.moveSpeed;
    }

    // �����ε�: �ڽ� ScriptableObject Ÿ�Ե� ����
    protected virtual void CharacterInitialize<TBase, TDerived>(TDerived data)
        where TBase : CharacterData
        where TDerived : TBase
    {
        CharacterInitialize<TBase>(data); // �⺻ CharacterData �ʵ� �ʱ�ȭ

        // �ڽ� �������� �߰� �ʵ尡 �ִٸ� ���⼭ ó�� (����)
        // var derivedData = data as TDerived;
        // if (derivedData != null) { ... }
    } 
    protected virtual async void Start()
    {
        // Addressables�� ���� ĳ���� �����͸� �񵿱������� �ε�
        AsyncOperationHandle<CharacterData> handle = Addressables.LoadAssetAsync<CharacterData>(CharacterName);

        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            CharacterInitialize(handle.Result);
        }
        else
        {
            Debug.LogError($"[Addressables] Failed to load CharacterData for: {CharacterName}");
        }
    }

    /// <summary>    
    /// �ǰ� �Լ�
    /// </summary>
    /// <param name="_damage"> ���� ��ü�� �ִ� ���� ������ </param>   
    public virtual void TakeDamage(float _damage)
    { 
        CurrentHp -= (float)((Mathf.Pow(_damage, 2f) / ((double)Armor + (double)_damage)));

        //ü���� 0 ���ϸ� Die() ȣ��
        if (CurrentHp <= 0)
        {
            CurrentHp = 0;
            Die();
        }
    }

    /// <summary>    
    /// �ش� ĳ���Ͱ� �׾��� �� ȣ��Ǵ� �޼���
    /// </summary>
    protected abstract void Die();


    /// <summary>    
    /// �����̻� ȿ�� �޼���
    /// </summary>
    protected abstract void StatusEffect();
}
