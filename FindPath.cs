using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
    public class FindPath
    {
        private FindPath() { }

        private static FindPath instance;

        public static FindPath Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new FindPath();
                }
                return instance;
            }
            
        }

        public Direction PathFinding(int[,] tileMap, in Position start, in Position end, List<Position> path)
        {

            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            ASNode startNode = new ASNode(start, new Position(), 0, Heuristic(start, end));
            nodes[startNode.currentPos.y, startNode.currentPos.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.currentPos.y, nextNode.currentPos.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.currentPos.x == end.x && nextNode.currentPos.y == end.y)
                {
                    path = new List<Position>();
                    
                    Position point = end;
                    while (!(point.x == start.x && point.y == start.y))
                    {
                        path.Add(point);
                        point = nodes[point.y, point.x].parentPos;
                    }
                    path.Add(start);


                    path.Reverse();

                }

                for (int i = 0; i < Direction1.Length; i++)
                {
                    int x = nextNode.currentPos.x + Direction1[i].x;
                    int y = nextNode.currentPos.y + Direction1[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == 0)
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;

                    int costStraight = 10;
                    int costDiagonal = 14;

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.currentPos.x == x || nextNode.currentPos.y == y) ? costStraight : costDiagonal);
                    int h = Heuristic(new Position(x, y), end);
                    ASNode newNode = new ASNode(new Position(x, y), nextNode.currentPos, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }

            }


            if (path == null)
            {
                return Direction.None;
            }
            else if (path.Count == 1) // path의 요소가 시작지점뿐인 상황
            {
                return Direction.None;
            }

            int directionX = path[1].x - path[0].x; // 0번 인덱스는 시작지점이므로 다음 이동 지점인 1번 인덱스를 사용
            int directionY = path[1].y - path[0].y; // this.pos , 길찾기를 사용하는 객체의 현 위치와 path[0]은 동일


            if (directionY < 0 && directionX == 0)
            {
                return Direction.Up;
            }
            else if (directionY == 0 && directionX < 0)
            {
                return Direction.Left;
            }
            else if (directionY > 0 && directionX == 0)
            {
                return Direction.Down;
            }
            else if (directionY == 0 && directionX > 0)
            {
                return Direction.Right;
            }
            else
            {
                Console.WriteLine("잘못된 방향입니다");
                return Direction.None;
            }
        }

        static Position[] Direction1 =
        {
            new Position(  0, -1 ),			// 상
			new Position(  0, +1 ),			// 하
			new Position( -1,  0 ),			// 좌
			new Position( +1,  0 ),			// 우
		};
        private static int Heuristic(Position start, Position end)
        {
            int costStraight = 10;
            int costDiagonal = 14;

            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            int straightCount = Math.Abs(xSize - ySize);
            int diagonalCount = Math.Max(xSize, ySize) - straightCount;

            return costStraight * straightCount + costDiagonal * diagonalCount;
        }

        private class ASNode
        {
            public Position currentPos;
            public Position parentPos;

            public int f;
            public int g;
            public int h;

            public ASNode(Position currentPos, Position parentPos, int g, int h)
            {
                this.currentPos = currentPos;
                this.parentPos = parentPos;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }



    }
}
