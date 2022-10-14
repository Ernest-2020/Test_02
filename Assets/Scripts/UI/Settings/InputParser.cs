public class InputParser
{
    private CubeSettings _cubeSettings;
    public CubeSettings ParseSettings(string timeSpawn, string distance, string speed)
    {
            _cubeSettings = new CubeSettings(float.Parse(timeSpawn), float.Parse(distance), float.Parse(speed));
            return _cubeSettings;
    }
}
