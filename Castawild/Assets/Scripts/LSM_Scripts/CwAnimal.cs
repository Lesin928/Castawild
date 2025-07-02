using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using static AnimalData;

/// <summary>
/// ���÷��̾�� ĳ���� Ŭ����
/// </summary>
public class CwAnimal : CwCharacter
{

    // Animal ���� �ʵ� �߰�
    // ���� ������ �񼱰������� �ٽ� ���� ����
    #region Animal Info  
    [Header("Animal Info")]
    [SerializeField] private float age;               // ���� (���� ���� �ý��� ����� Ȱ�밡�ɼ� ����
    [SerializeField] private float size;              // ũ�� (�λ깰 ���� �� Ȱ�� ���ɼ� ����)
    [SerializeField] private float weight;            // ���� (�λ깰 ���� �� Ȱ�� ���ɼ� ����)
    [SerializeField] public float detectionRadius;    // ���� �Ÿ�
    [SerializeField] public float fleeThreshold;      // ü���� �� % ������ �� ����?
    [SerializeField] public float wanderInterval;     // ���� ���� �̵� �ֱ� 
    [SerializeField] public float attackRange;        // ���� ����
    [SerializeField] public float attackCooldown;     // ���� ��Ÿ�� 
    [SerializeField] public SpawnType spawnType;      // ���� Ÿ�� (��ġ, ��, ��, �� ��)
    [SerializeField] public bool isAggressive;        // ���� ����
    [SerializeField] public bool isFleeing;           // ���� ����
    [SerializeField] public bool canBeHarvested;     // ���� �� ��ü ���� ���� 
    #endregion 

    protected override void CharacterInitialize<T>(T data)  
    {
        base.CharacterInitialize<T>(data);
        //Animal ���� �ʵ� �߰� 
    }

    protected override async void Start()
    {
        // Addressables�� ���� ĳ���� �����͸� �񵿱������� �ε�
        AsyncOperationHandle<AnimalData> handle = Addressables.LoadAssetAsync < AnimalData>(CharacterName);

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

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
    }

    protected override void Die()
    {

    }

    protected override void StatusEffect()
    {

    }
}

