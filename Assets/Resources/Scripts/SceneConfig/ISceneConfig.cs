// Base opcional
using System.Collections.Generic;
using Unity.VisualScripting;

public interface ISceneConfig 
{
    int sceneIndex { get; }
}

public interface ITheorySceneConfig : ISceneConfig
{
    int numPages { get; }
    string[] TheoryText { get; }
    string[] TitleText { get; }
    string[] imagesPaths { get; }
}

public interface IExcerciseSceneConfig : ISceneConfig
{
    

    int varLimit { get; }
    bool canCreateVariables { get; }
    bool canCreateMethods { get; }
    bool stringsAllowed { get; }
    bool manualValuesAllowed { get; }
    string formulation { get; }
    Dictionary<string, (string val,bool isRandom)> vars { get; }
    Dictionary<string, string[]> methods { get; }
    string[] availableMethods { get; }
    Dictionary<string, string> varsToCheck { get; }
    string solvedExercise { get; }
    string printMethodInitialValue { get; }

}

public class SceneConfig_Sample : IExcerciseSceneConfig
{
    public int sceneIndex => 0;
    public int varLimit => 5;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => true;
    public bool manualValuesAllowed => true; // Allows manual values in the exercise
    public string formulation => "Formulation_SampleScene";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "var1", ("1", false) }
        //{ "var2", ("2", false) }
    };
    public string printMethodInitialValue => "";

    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
        /*{ "AddMethod", new string[] { "var1","1", "2" } },
        { "SubstractMethod", new string[] { "var1","1", "2" } },
        { "MultiplyMethod", new string[] { "var1","1", "2" } },
        { "DivideMethod", new string[] { "var1","1", "2" } },
        { "ModMethod", new string[] { "var1","1", "2" } },
        { "AssignMethod", new string[] { "var1","1" } }*/

    };

    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "ModMethod", "AssignMethod"};

    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        /*{ "x", "5" },
        { "0", "1" },
        { "z", "a" }*/
    };
    public string solvedExercise => "return \"Hello World!\"";/*"diff = 7 - var1\r\n" +
                                    "var1 = var1 + diff\r\n" +*/
                                    //"return var1";
}

public class SceneConfig_Test : ITheorySceneConfig
{
    public int sceneIndex => 1;
    public int numPages => 3;
    public string[] TheoryText => new string[] { "Test_Theory_1", "Test_Theory_2", "Test_Theory_3" };
    public string[] TitleText => new string[] { "Test_Title", "Test_Title", "Test_Title" };
    public string[] imagesPaths =>new string[] { "Images/Image_Theory_Scene", "", "Images/Image_Theory_Scene" };
}

public class SceneConfig_HelloWorld : ITheorySceneConfig
{
    public int sceneIndex => 4;
    public int numPages => 2;
    public string[] TheoryText => new string[] { "Welcome_Theory", "Hello_World_Theory" };
    public string[] TitleText => new string[] { "Welcome_Title", "Hello_World_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_HelloWorld1", "Images/Image_HelloWorld2" };
}

public class SceneConfig_HelloWorldExercise1 : IExcerciseSceneConfig
{
    public int sceneIndex => 5;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => false;
    public bool stringsAllowed => true;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_HelloWorld_Exercise1";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        
    };
    public string printMethodInitialValue => "";
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
        /*{ "AddMethod", new string[] { "var1","1", "2" } },
        { "SubstractMethod", new string[] { "var1","1", "2" } },
        { "MultiplyMethod", new string[] { "var1","1", "2" } },
        { "DivideMethod", new string[] { "var1","1", "2" } },
        { "ModMethod", new string[] { "var1","1", "2" } },
        { "AssignMethod", new string[] { "var1","1" } }*/
    };
    public string[] availableMethods => new string[] {};
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        /*{ "x", "5" },
        { "0", "1" },
        { "z", "a" }*/
    };
    public string solvedExercise => "";
}

public class SceneConfig_HelloWorldExercise2 : IExcerciseSceneConfig
{
    public int sceneIndex => 6;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => false;
    public bool stringsAllowed => true;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_HelloWorld_Exercise2";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {

    };
    public string printMethodInitialValue => "";
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
        /*{ "AddMethod", new string[] { "var1","1", "2" } },
        { "SubstractMethod", new string[] { "var1","1", "2" } },
        { "MultiplyMethod", new string[] { "var1","1", "2" } },
        { "DivideMethod", new string[] { "var1","1", "2" } },
        { "ModMethod", new string[] { "var1","1", "2" } },
        { "AssignMethod", new string[] { "var1","1" } }*/
    };
    public string[] availableMethods => new string[] { };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        /*{ "x", "5" },
        { "0", "1" },
        { "z", "a" }*/
    };
    public string solvedExercise => "return \"" + LocalizationManager.Instance.GetText("Hello_World") + "\"";
}

public class SceneConfig_Var_Creation : ITheorySceneConfig
{
    public int sceneIndex => 7;
    public int numPages => 3;
    public string[] TheoryText => new string[] { "Var_Creation_Intro", "Var_Creation_Instructions", "Var_Creation_Access" };
    public string[] TitleText => new string[] { "Var_Creation_Title", "Var_Creation_Title", "Var_Creation_Title"};
    public string[] imagesPaths => new string[] { "Images/Image_Theory_VarCreation", "Images/Image_Theory_VarCreation2", "Images/Image_Theory_VarCreation3" };
}

public class SceneConfig_Var_Creation_Exercise1 : IExcerciseSceneConfig
{
    public int varLimit => 1;

    public bool canCreateVariables => true;

    public bool canCreateMethods => false;

    public bool stringsAllowed => false;

    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_VarCreationExercise1";

    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {

    };

    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {

    };

    public string[] availableMethods => new string[] { };

    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        { "0", "a" }
    };

    public string solvedExercise => "";

    public string printMethodInitialValue => "";

    public int sceneIndex => 8;
}


public class SceneConfig_Var_Creation_Exercise2 : IExcerciseSceneConfig
{
    public int varLimit => 1;

    public bool canCreateVariables => true;

    public bool canCreateMethods => false;

    public bool stringsAllowed => false;

    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_VarCreationExercise2";

    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {

    };

    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {

    };

    public string[] availableMethods => new string[] { };

    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        { "x", "7" }
    };

    public string solvedExercise => "return 7";

    public string printMethodInitialValue => "";

    public int sceneIndex => 9;
}

public class SceneConfig_RandomVars_Theory : ITheorySceneConfig
{
    public int sceneIndex => 10;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "Random_Var_Theory" };
    public string[] TitleText => new string[] { "RandomVars_Title"};
    public string[] imagesPaths => new string[] { "Images/Image_Random_Var" };
}

public class SceneConfig_RandomVars_Exercise : IExcerciseSceneConfig
{
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => false;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_RandomVarsExercise";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "aleatoria", ("0", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
       
    };
    public string solvedExercise => "";
    public string printMethodInitialValue => "aleatoria";
    public int sceneIndex => 11;
}

public class SceneConfig_Assign_Values_Theory : ITheorySceneConfig
{
    public int sceneIndex => 12;
    public int numPages => 3;
    public string[] TheoryText => new string[] { "Assign_Values_Theory1", "Assign_Values_Theory2", "Assign_Values_Theory3", };
    public string[] TitleText => new string[] { "Assign_Values_Title", "Assign_Values_Title", "Assign_Values_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_Assign_Values1", "Images/Image_Assign_Values2", "Images/Image_Assign_Values3" };
}

public class SceneConfig_Assign_Values_Exercise : IExcerciseSceneConfig
{
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_Assign_Values_Exercise";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
        
    };
    public string[] availableMethods => new string[] { "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        
    };
    public string solvedExercise => "return 5";
    public string printMethodInitialValue => "x";
    public int sceneIndex => 13;
}

public class SceneConfig_Var_Assign_Theory : ITheorySceneConfig
{
    public int numPages => 1;

    public string[] TheoryText => new string[] {"Var_Assign_Theory"};

    public string[] TitleText => new string[] { "Var_Assign_Theory_Title"};

    public string[] imagesPaths => new string[] { "Images/Image_Var_Assign" };

    public int sceneIndex => 14;
}

public class SceneConfig_Var_Assign_Exercise : IExcerciseSceneConfig
{
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_Var_Assign_Exercise";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", false) },
        { "y", ("5", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {

    };
    public string[] availableMethods => new string[] { "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {

    };
    public string solvedExercise => "return 5";
    public string printMethodInitialValue => "x";
    public int sceneIndex => 15;
}

public class SceneConfig_Var_Assign_Problem_Formulation : ITheorySceneConfig
{
    public int sceneIndex => 16;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "Var_Assign_Problem_Formulation" };
    public string[] TitleText => new string[] { "Var_Assign_Problem_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_Var_Assign_Problem" };
}

public class SceneConfig_Var_Assign_Problem : IExcerciseSceneConfig
{
    public int varLimit => 8;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public string formulation => "Formulation_Var_Assign_Problem";
    public bool manualValuesAllowed => true;
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", true) },
        { "y", ("5", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {

    };
    public string solvedExercise => "z = var1\n" +
                                    "var1 = var2\n" +
                                    "var2 = z\n" +
                                    "return tostring(var1) .. \" \" .. tostring(var2)";
    public string printMethodInitialValue => "x, y";
    public int sceneIndex => 16;
}

public class SceneConfig_Sum_Operation_Theory: ITheorySceneConfig
{
    public int sceneIndex => 17;
    public int numPages => 2;
    public string[] TheoryText => new string[] { "Sum_Theory1", "Sum_Theory2", };
    public string[] TitleText => new string[] { "Sum_Title", "Sum_Title" };
    public string[] imagesPaths => new string[] { "", "Images/Image_Sum_Operation" };
}

public class SceneConfig_Sum_Operation_Exercise : IExcerciseSceneConfig
{
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_Sum_Operation_Exercise";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("0", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 7";
    public string printMethodInitialValue => "x";

    public int sceneIndex => 18;
}

public class SceneCongig_VarSum_Theory : ITheorySceneConfig
{
    public int sceneIndex => 19;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "VarSum_Theory" };
    public string[] TitleText => new string[] { "VarSum_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_VarSum" };
}

public class SceneConfig_VarSum_Exercise: IExcerciseSceneConfig
{
    public int sceneIndex => 20;

    public int varLimit => 3;

    public bool canCreateVariables => true;

    public bool canCreateMethods => true;

    public bool stringsAllowed => false;

    public bool manualValuesAllowed => false;

    public string formulation => "Formulation_VarSum_Exercise";

    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("6", true) },
        { "y", ("8", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
        { "sum", "a" }
    };
    public string solvedExercise => "return var1 + var2";
    public string printMethodInitialValue => "";
}

public class SceneCongig_SameVarSum_Theory : ITheorySceneConfig
{
    public int sceneIndex => 21;
    public int numPages => 3;
    public string[] TheoryText => new string[] { "SameVarSum_Theory1", "SameVarSum_Theory2", "SameVarSum_Theory3" };
    public string[] TitleText => new string[] { "SameVarSum_Title", "SameVarSum_Title", "SameVarSum_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_SameVarSum1", "Images/Image_SameVarSum2", "Images/Image_SameVarSum3" };
}

public class SceneConfig_SameVarSum_Exercise : IExcerciseSceneConfig
{
    public int sceneIndex => 22;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;

    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_SameVarSum_Exercise";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return var1 + 4";
    public string printMethodInitialValue => "x";
}

public class SceneConfig_SameVarSum_Exercise2 : IExcerciseSceneConfig
{
    public int sceneIndex => 23;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;

    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_SameVarSum_Exercise2";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return var1 +var1";
    public string printMethodInitialValue => "x";
}

public class SceneConfig_OtherOperations_Theory: ITheorySceneConfig
{
    public int sceneIndex => 24;
    public int numPages => 2;
    public string[] TheoryText => new string[] { "OtherOperations_Theory1", "OtherOperations_Theory2" };
    public string[] TitleText => new string[] { "OtherOperations_Title", "OtherOperations_Title", };
    public string[] imagesPaths => new string[] { "Images/Image_OtherOperations1", "Images/Image_OtherOperations2" };
}

public class SceneConfig_OtherOperations_Exercise1 : IExcerciseSceneConfig
{
    public int sceneIndex => 25;
    public int varLimit => 5;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => true;
    public string formulation => "Formulation_OtherOperations_Exercise1";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
        {
            { "x", ("3", true) },
            { "y", ("5", true) }
        };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return (var1 + 10) * var2";
    public string printMethodInitialValue => "";
}

public class SceneConfig_OtherOperations_Exercise2 : IExcerciseSceneConfig
{
    public int sceneIndex => 26;
    public int varLimit => 5;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_OtherOperations_Exercise2";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
        {
            { "x", ("3", true) },
        };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return var1*var1";
    public string printMethodInitialValue => "";
}

public class SceneConfig_OtherOperations_Exercise3 : IExcerciseSceneConfig
{
    public int sceneIndex => 27;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_OtherOperations_Exercise3";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("20", false) },
        { "y", ("2", false) },
        { "z", ("6", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 4";
    public string printMethodInitialValue => "";
}

public class SceneConfig_OtherOperations_Exercise4 : IExcerciseSceneConfig
{
    public int sceneIndex => 28;
    public int varLimit => 1;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_OtherOperations_Exercise4";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("17", false) },
        { "y", ("8", false) },
        { "z", ("6", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "AssignMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 8";
    public string printMethodInitialValue => "";
}

public class SceneConfig_ModOperation_Theory : ITheorySceneConfig
{
    public int sceneIndex => 29;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "ModOperation_Theory"};
    public string[] TitleText => new string[] { "ModOperation_Title" };
    public string[] imagesPaths => new string[] { "Images/Image_ModOperation" };
}

public class SceneConfig_ModOperation_Exercise1: IExcerciseSceneConfig
{
    public int sceneIndex => 30;
    public int varLimit => 1;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_ModOperation_Exercise1";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("37", false) },
        { "y", ("10", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "ModMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 7";

    public string printMethodInitialValue => "";
}

public class SceneConfig_ModOperation_Exercise2 : IExcerciseSceneConfig
{
    public int sceneIndex => 31;
    public int varLimit => 1;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_ModOperation_Exercise2";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("4", false) },
        { "y", ("3", false) },
        { "z", ("2", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "ModMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 0";
    public string printMethodInitialValue => "";
}

public class SceneConfig_ModOperation_Exercise3 : IExcerciseSceneConfig
{
    public int sceneIndex => 32;
    public int varLimit => 1;
    public bool canCreateVariables => true;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public bool manualValuesAllowed => false;
    public string formulation => "Formulation_ModOperation_Exercise3";
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("5", false) },
        { "y", ("4", false) },
        { "z", ("3", false) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "ModMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {
    };
    public string solvedExercise => "return 0";
    public string printMethodInitialValue => "";
}

public class SceneConfig_Operations_Problem_Formulation : ITheorySceneConfig
{
    public int sceneIndex => 16;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "Operations_Problem_Formulation" };
    public string[] TitleText => new string[] { "Operations_Problem_Title" };
    public string[] imagesPaths => new string[] { "" };
}

public class SceneConfig_Operations_Problem : IExcerciseSceneConfig
{
    public int varLimit => 8;
    public bool canCreateVariables => false;
    public bool canCreateMethods => true;
    public bool stringsAllowed => false;
    public string formulation => "Formulation_Operations_Problem";
    public bool manualValuesAllowed => true;
    public Dictionary<string, (string val, bool isRandom)> vars => new Dictionary<string, (string, bool)>
    {
        { "x", ("3", true) },
        { "y", ("5", true) }
    };
    public Dictionary<string, string[]> methods => new Dictionary<string, string[]>
    {
    };
    public string[] availableMethods => new string[] { "AddMethod", "SubstractMethod", "MultiplyMethod", "DivideMethod", "ModMethod" };
    public Dictionary<string, string> varsToCheck => new Dictionary<string, string>
    {

    };
    public string solvedExercise => "z = var1\n" +
                                    "var1 = var2\n" +
                                    "var2 = z\n" +
                                    "return tostring(var1) .. \" \" .. tostring(var2)";
    public string printMethodInitialValue => "x, y";
    public int sceneIndex => 16;
}

public class SceneConfig_Game_End : ITheorySceneConfig
{
    public int sceneIndex => 16;
    public int numPages => 1;
    public string[] TheoryText => new string[] { "Game_End" };
    public string[] TitleText => new string[] { "Game_End_Title" };
    public string[] imagesPaths => new string[] { "" };
}