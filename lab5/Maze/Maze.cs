using OpenTK;
using System;
using System.Collections.Generic;

namespace Maze
{
    internal class Maze
    {
        private const int _rowCount = 17;
        private const int _columnCount = 17;

        private readonly Texture _floorTexture;
        private readonly Texture _ceilTexture;

        private readonly List<Texture> _textures;
        private const int textureCount = 6;

        // TODO: Пол и потолок можно сделать по одной плоскости
        private readonly Wall[] _walls = new Wall[_rowCount * _columnCount];
        private readonly Wall[] _floor = new Wall[_rowCount * _columnCount];
        private readonly Wall[] _ceil = new Wall[_rowCount * _columnCount];


        // TODO: Можно передавать извне
        private readonly char[,] _mazePattern = new char[_rowCount, _columnCount]
        {
            { '*','*','*','*','*','*','*',' ','*','*','*','*','*','*','*','*','*' },
            { '*',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ','*' },
            { '*',' ','*','*','*',' ','*',' ','*','*','*','*','*',' ','*',' ','*' },
            { '*',' ','*',' ',' ',' ','*',' ',' ',' ',' ',' ','*',' ','*',' ','*' },
            { '*','*','*',' ','*','*','*',' ','*','*','*','*','*',' ','*',' ','*' },
            { '*',' ',' ',' ','*',' ',' ',' ','*',' ',' ',' ','*',' ','*',' ','*' },
            { '*',' ','*',' ','*',' ','*','*','*','*','*',' ','*',' ','*',' ','*' },
            { '*',' ','*',' ','*',' ','*',' ','*',' ',' ',' ','*',' ','*',' ','*' },
            { '*',' ','*','*','*',' ','*',' ','*',' ','*','*','*',' ','*',' ','*' },
            { '*',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ','*',' ','*',' ','*' },
            { '*',' ','*','*','*','*','*','*','*','*','*',' ','*',' ','*',' ','*' },
            { '*',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','*',' ','*',' ','*' },
            { '*','*','*','*','*',' ','*',' ','*','*','*','*','*',' ','*',' ','*' },
            { '*',' ','*',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*',' ','*' },
            { '*',' ','*',' ','*','*','*','*','*','*','*','*','*','*','*',' ','*' },
            { '*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*' },
            { '*','*','*','*','*','*','*','*','*',' ','*','*','*','*','*','*','*' },
        };

        public Maze()
        {
            _floorTexture = new Texture("floor.jpg");
            _ceilTexture = new Texture("ceiling.jpg");

            _textures = new List<Texture> {
                new Texture("wall_1.jpg"),
                new Texture("wall_2.jpg"),
                new Texture("wall_3.jpg"),
                new Texture("wall_4.jpg"),
                new Texture("wall_5.jpg"),
                new Texture("wall_6.jpg"),
            };

            int k = -1;

            var random = new Random();

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _columnCount; j++)
                {
                    k++;

                    _ceil[k] = new Wall(
                        j - _rowCount,
                        i - _columnCount,
                        j - _rowCount + 1,
                        i - _columnCount + 1,
                        1.0f,
                        2.0f,
                        _ceilTexture);

                    _floor[k] = new Wall(
                        j - _rowCount,
                        i - _columnCount,
                        j - _rowCount + 1,
                        i - _columnCount + 1,
                        -1.0f,
                        0,
                        _floorTexture);

                    if (_mazePattern[i, j] == ' ')
                    {
                        continue;
                    }

                    _walls[k] = new Wall(
                        j - _rowCount,
                        i - _columnCount,
                        j - _rowCount + 1,
                        i - _columnCount + 1,
                        0,
                        1,
                        _textures[random.Next(textureCount)]);
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _rowCount * _columnCount; i++)
            {
                _floor[i].Draw();
                _ceil[i].Draw();

                if (_walls[i] == null)
                {
                    continue;
                }

                _walls[i].Draw();
            }
        }

        public bool CheckCollision(Vector3 obj, float objWith, float objHeight)
        {
            // TODO: Искать пересечение только с ближними объектами

            for (int i = 0; i < _rowCount * _columnCount; i++)
            {
                if (_walls[i]?.CheckCollision(obj, objWith, objHeight) == true ||
                     _floor[i]?.CheckCollision(obj, objWith, objHeight) == true ||
                     _ceil[i]?.CheckCollision(obj, objWith, objHeight) == true)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
