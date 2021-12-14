﻿namespace ChristmasLight
{
    public struct Matrix
    {
        private readonly Bulb[,] _matrix;

        public Matrix(int n, int m)
        {
            _matrix = new Bulb[n, m];
            _matrix = BuildMatrix(n, m);
        }

        private Bulb[,] BuildMatrix(int n, int m)
        {
            for (int x = 0; x < n; x++)
                for (int y = 0; y < m; y++)
                    _matrix[x, y] = new Bulb();

            return _matrix;
        }
        
        public Bulb At(int x, int y)  => _matrix[x, y];
    }
    
    public class LightGroup
    {
        private Matrix _matrix;

        public LightGroup()
            => _matrix = new(1000,1000);
        
        public Bulb At(int x, int y)
            => _matrix.At(x, y);
    }
}