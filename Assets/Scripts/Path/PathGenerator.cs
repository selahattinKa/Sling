using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
    {
        private int width, height;
        private List<Vector2Int> pathCells;
        public int direction;
    

        public PathGenerator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public List<Vector2Int> GeneratePath()
        {
            pathCells = new List<Vector2Int>();

            int y = (int)(height / 2);
            int x = 0;
            int consecutiveZeros = 0; // Ardışık sıfır sayısını takip etmek için bir sayaç
            int moveCount = 0; // Toplam dünüş sayısını takip etmek için bir sayaç

            while (x < width)
            {
                pathCells.Add(new Vector2Int(x,y));

                bool validMove = false;
            

                while (!validMove)
                {
                    int move = Random.Range(0, 3);



                    if ((move == 0 || move == 1 || move == 2) && moveCount <= 10) // 1 veya 2 hareketleri ve her 10 dönüşe izin ver
                    {
                        if ((move == 0 && consecutiveZeros < 3) || x % 2 == 0 || x > (width - 2))
                        {
                            x ++;
                            validMove = true;
                            consecutiveZeros++;
                            direction = 0;
                        }
                        else if (move == 1  && CellIsEmpty(x,y +1) && y < (height - 3))
                        {
                            y++;
                            validMove = true;
                            consecutiveZeros = 0; 
                            moveCount++;
                            direction = 1;



                        }
                        else if (move == 2 && CellIsEmpty(x,y -1) && y>2)
                        {
                            y--;
                            validMove = true;
                            consecutiveZeros = 0; 
                            moveCount++;
                            direction = 2;


                        }
                    }
                    else if (move == 0 && moveCount > 10)
                    {
                        x ++;
                        validMove = true;
                        consecutiveZeros++;
                        direction = 0;


                    }
                    else
                    {
                        validMove = true;

                    }
                    if (consecutiveZeros >= 10) // Ardışık 10 sıfır olduysa moveCount'u sıfır yapıp tekrardan dönüşlere izin ver
                    {
                        moveCount = 0;
                        validMove = true;
                    }

                }
            }
            return pathCells;
        }

    

        private bool CellIsEmpty(int x, int y)
        {
            return !pathCells.Contains(new Vector2Int(x, y));
        }

        private bool CellIsTaken(int x, int y)
        {
            return pathCells.Contains(new Vector2Int(x, y));

        }

        public int getCellNeighbourValue(int x, int y)
        {
            int returnValue = 0;

            if (!CellIsTaken(x, y - 1))
            {
                returnValue += 1;
            }

            if (CellIsTaken(x-1, y))
            {
                returnValue += 2;
            } 
            if (CellIsTaken(x+1, y))
            {
                returnValue += 4;
            }
            if (!CellIsTaken(x, y + 1))
            {
                returnValue += 8;
            }

            return returnValue;
        }
    
    
    }
