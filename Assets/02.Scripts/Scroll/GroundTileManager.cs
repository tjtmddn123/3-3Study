using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GroundTileManager : MonoBehaviour
{
    public GameObject groundTilePrefab; // 지면 타일 프리팹 참조
    public int initialTilesCount = 30; // 초기에 생성할 타일의 수
    private float tileWidth; // 각 타일의 너비
    private float timeSinceLastSeen = 0.0f; // 타일이 마지막으로 보인 시간부터 경과한 시간

    private Queue<GameObject> groundTiles = new Queue<GameObject>(); // 타일들을 관리할 큐(오브젝트 풀)

    void Start()
    {
        // 첫 번째 타일을 생성하고 그 위치를 기준으로 타일 너비 설정
        GameObject firstTile = Instantiate(groundTilePrefab, new Vector3(-8.35f, -4.8f, 0), Quaternion.identity);
        tileWidth = firstTile.GetComponent<SpriteRenderer>().bounds.size.x;
        groundTiles.Enqueue(firstTile);

        // 초기 타일들을 생성하고 각각의 위치를 설정
        for (int i = 1; i < initialTilesCount; i++)
        {
            GameObject tile = Instantiate(groundTilePrefab);
            tile.transform.position = new Vector3(-8.35f + i * tileWidth, -4.8f, 0);
            groundTiles.Enqueue(tile);
        }
    }

    void Update()
    {
        GameObject firstTile = groundTiles.Peek(); // 큐의 첫 번째 타일 확인
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(firstTile.transform.position); // 타일의 뷰포트 위치 계산

        // 타일이 카메라 뷰포트 왼쪽으로 벗어나면 시간 측정
        if (viewportPos.x < 0)
        {
            timeSinceLastSeen += Time.deltaTime;
        }
        else
        {
            timeSinceLastSeen = 0.0f; // 타일이 보이면 타이머 리셋
        }

        // 타일이 일정 시간 동안 보이지 않으면 큐의 끝으로 이동
        if (timeSinceLastSeen >= 0.2f)
        {
            firstTile.transform.position = new Vector3(groundTiles.ToArray()[initialTilesCount - 1].transform.position.x + tileWidth, -4.8f, 0);
            groundTiles.Enqueue(groundTiles.Dequeue()); // 큐에서 제거하고 다시 추가
            timeSinceLastSeen = 0.0f; // 타이머 리셋
        }
    }
}




