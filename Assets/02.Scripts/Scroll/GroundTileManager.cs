using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GroundTileManager : MonoBehaviour
{
    public GameObject groundTilePrefab; // ���� Ÿ�� ������ ����
    public int initialTilesCount = 30; // �ʱ⿡ ������ Ÿ���� ��
    private float tileWidth; // �� Ÿ���� �ʺ�
    private float timeSinceLastSeen = 0.0f; // Ÿ���� ���������� ���� �ð����� ����� �ð�

    private Queue<GameObject> groundTiles = new Queue<GameObject>(); // Ÿ�ϵ��� ������ ť(������Ʈ Ǯ)

    void Start()
    {
        // ù ��° Ÿ���� �����ϰ� �� ��ġ�� �������� Ÿ�� �ʺ� ����
        GameObject firstTile = Instantiate(groundTilePrefab, new Vector3(-8.35f, -4.8f, 0), Quaternion.identity);
        tileWidth = firstTile.GetComponent<SpriteRenderer>().bounds.size.x;
        groundTiles.Enqueue(firstTile);

        // �ʱ� Ÿ�ϵ��� �����ϰ� ������ ��ġ�� ����
        for (int i = 1; i < initialTilesCount; i++)
        {
            GameObject tile = Instantiate(groundTilePrefab);
            tile.transform.position = new Vector3(-8.35f + i * tileWidth, -4.8f, 0);
            groundTiles.Enqueue(tile);
        }
    }

    void Update()
    {
        GameObject firstTile = groundTiles.Peek(); // ť�� ù ��° Ÿ�� Ȯ��
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(firstTile.transform.position); // Ÿ���� ����Ʈ ��ġ ���

        // Ÿ���� ī�޶� ����Ʈ �������� ����� �ð� ����
        if (viewportPos.x < 0)
        {
            timeSinceLastSeen += Time.deltaTime;
        }
        else
        {
            timeSinceLastSeen = 0.0f; // Ÿ���� ���̸� Ÿ�̸� ����
        }

        // Ÿ���� ���� �ð� ���� ������ ������ ť�� ������ �̵�
        if (timeSinceLastSeen >= 0.2f)
        {
            firstTile.transform.position = new Vector3(groundTiles.ToArray()[initialTilesCount - 1].transform.position.x + tileWidth, -4.8f, 0);
            groundTiles.Enqueue(groundTiles.Dequeue()); // ť���� �����ϰ� �ٽ� �߰�
            timeSinceLastSeen = 0.0f; // Ÿ�̸� ����
        }
    }
}




