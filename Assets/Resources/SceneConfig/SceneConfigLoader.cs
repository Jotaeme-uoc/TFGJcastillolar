using System;

public static class SceneConfigLoader
{
    public static ISceneConfig Load(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 1: return new SceneConfig_Test();
            case 2: return new SceneConfig_HelloWorld();
            default:
                throw new Exception($"No config defined for scene '{sceneIndex}'");
        }
    }
}