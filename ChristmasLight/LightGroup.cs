namespace ChristmasLight
{
    public class LightGroup
    {
        private const int M = 1000;
        private const int N = 1000;

        private Bulb[,] _matrix = new Bulb[N,M];

        public LightGroup()
            => Initialize();

        private void Initialize()
        {
            for (int x = 0; x < M; x++)
                for (int y = 0; y < N; y++)
                    _matrix[x, y] = new Bulb();
        }

        public Bulb At(int x, int y) => _matrix[x, y];
    }
}