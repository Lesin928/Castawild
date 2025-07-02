using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


/// <summary>
/// �÷��̾�� ĳ���� Ŭ���� 
/// </summary>

public class CwPlayer : CwCharacter
{

    #region Player Info   
    //Player ���� �ʵ� �߰�
    #endregion

    protected override void CharacterInitialize<T>(T data)
    {
        base.CharacterInitialize<T>(data);
        //Player ���� �ʵ� �ʱ�ȭ
    }

    protected override async void Start()
    {
        // Addressables�� ���� ĳ���� �����͸� �񵿱������� �ε�
        AsyncOperationHandle<PlayerData> handle = Addressables.LoadAssetAsync<PlayerData>(CharacterName);

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

