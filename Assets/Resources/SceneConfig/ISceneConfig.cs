// Base opcional
public interface ISceneConfig 
{
    int sceneIndex { get; }
}

// Para escenas de exploración
public interface ITheorySceneConfig : ISceneConfig
{
    int numPages { get; }
    string[] TheoryText { get; }
    string[] TitleText { get; }
}

// Para escenas de combate
public interface IExcerciseSceneConfig : ISceneConfig
{
    

    int varLimit { get; }
    bool canCreateVariables { get; }
    bool canCreateMethods { get; }


}

public class SceneConfig_Test : ITheorySceneConfig
{
    public int sceneIndex => 0;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "Test_Theory" };
    public string[] TitleText => new string[] { "Test_Title" };
}

public class SceneConfig_HelloWorld : ITheorySceneConfig
{
    public int sceneIndex => 1;
    public int numPages => 2;
    public string[] TheoryText => new string[] { "Welcome_Theory", "Hello_World_Theory" };
    public string[] TitleText => new string[] { "Welcome_Title", "Hello_World_Title" };
}
