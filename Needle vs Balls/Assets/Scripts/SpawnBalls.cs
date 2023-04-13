using UnityEngine;
public class SpawObject : MonoBehaviour
{
    [SerializeField] private GameObject[] _object; // ������� ������� ������ � �������
    [SerializeField] float RandX; // ������������ �� � �������
    [SerializeField] Vector3 _whereToSpawn; // ��� ��������(���� � ��� �� ������� ��� ��� �����)
    [SerializeField] private float spawnRate = 2f; // ��� � ����� ����� ��������
    [SerializeField] float nextSpawn = 0.0f;
    public GameObject Obuchka;
    private PlayerMove Player;
    public int SNum;
    private void Start()
    {
        Player = FindObjectOfType<PlayerMove>();
        SNum = Player.SceneNumber;
    }
    private void Update()
    {
        if (SNum == 1)
        {
            if (Obuchka.activeSelf == false)
            {
                if (Time.time > nextSpawn)// && StarTime < 10f)
                {
                    nextSpawn = Time.time + spawnRate;
                    RandX = Random.Range(2.2f, -2.2f);
                    _whereToSpawn = new Vector3(RandX, 17.561f, -2.2f);
                    Instantiate(_object[Random.Range(0, _object.Length)], _whereToSpawn, Quaternion.identity);
                }
            }
        }
        else
        {
            if (Time.time > nextSpawn)// && StarTime < 10f)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(2.2f, -2.2f);
                _whereToSpawn = new Vector3(RandX, 17.561f, -2.2f);
                Instantiate(_object[Random.Range(0, _object.Length)], _whereToSpawn, Quaternion.identity);
            }
        }
    }
}