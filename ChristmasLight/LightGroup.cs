namespace ChristmasLight
{
    public class Matrix
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

    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
            => (X, Y) = (x, y);
    }
    
    
    public class LightGroup
    {
        private Matrix _matrix;

        public LightGroup()
            => _matrix = new(1000,1000);
        
        public Bulb At(int x, int y)
            => _matrix.At(x, y);

        public void Instruction
            (Coordinate cordA, Coordinate cordB, Instructions instructions)
        {
            for (int x = cordA.X; x <= cordB.X; x++)
            {
                for (int y = cordA.Y; y <= cordB.Y; y++)
                {
                    switch (instructions)
                    {
                        case Instructions.Toggle:
                            _matrix.At(x, y).Toggle();
                            break;
                        case Instructions.TurnOff:
                            _matrix.At(x, y).TurnOff();
                            break;
                        case Instructions.TurnOn:
                            _matrix.At(x, y).TurnOn();
                            break;
                    }
                }
            }
        }

        public int CountBulbOn()
        {
            int count = 0;
            for(int x = 0; x <= 999; x++)
                for (int y = 0; y <= 999; y++)
                    if (_matrix.At(x, y).Status() == 1) 
                        count++;
                    
            return count;
        }
    }
}