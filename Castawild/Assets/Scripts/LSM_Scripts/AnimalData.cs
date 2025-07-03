using UnityEngine;

[CreateAssetMenu(fileName = "AnimalData", menuName = "ScriptableObjects/AnimalData", order = 3)]
public class AnimalData : CharacterData
{
    public float age;               // ���� (���� ���� �ý��� ����� Ȱ�밡�ɼ� ����
    public float size;              // ũ�� (�λ깰 ���� �� Ȱ�� ���ɼ� ����)
    public float weight;            // ���� (�λ깰 ���� �� Ȱ�� ���ɼ� ����)
    public float detectionRadius;    // ���� �Ÿ�
    public float fleeThreshold;      // ü���� �� % ������ �� ����?
    public float wanderInterval;     // ���� ���� �̵� �ֱ� 
    public float attackRange;        // ���� ����
    public float attackCooldown;     // ���� ��Ÿ�� 
    public bool isAggressive;        // ���� ����
    public bool isFleeing;           // ���� ����
    public bool canBeHarvested;     // ���� �� ��ü ���� ����
    public enum SpawnType
    { 
        beach, forest, river, mountain
    }
}
