using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{    
    public string characterName; //��ƼƼ �̸�
    public float maxHp; //�ִ�ü�� 
    public float armor; //����
    public float attack; //���ݷ� 
    public float moveSpeed; //�̵��ӵ� 
}

