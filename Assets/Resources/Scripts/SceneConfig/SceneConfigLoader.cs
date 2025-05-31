using System;

public static class SceneConfigLoader
{
    public static ISceneConfig Load(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 2: return new SceneConfig_HelloWorld();
            case 3: return new SceneConfig_HelloWorldExercise1();
            case 4: return new SceneConfig_HelloWorldExercise2();
            case 5: return new SceneConfig_Var_Creation();
            case 6: return new SceneConfig_Var_Creation_Exercise1();
            case 7: return new SceneConfig_Var_Creation_Exercise2();
            case 8: return new SceneConfig_RandomVars_Theory();
            case 9: return new SceneConfig_RandomVars_Exercise();
            case 10: return new SceneConfig_Assign_Values_Theory();
            case 11: return new SceneConfig_Assign_Values_Exercise();
            case 12: return new SceneConfig_Var_Assign_Theory();
            case 13: return new SceneConfig_Var_Assign_Exercise();
            case 14: return new SceneConfig_Var_Assign_Problem_Formulation();
            case 15: return new SceneConfig_Var_Assign_Problem();
            case 16: return new SceneConfig_Sum_Operation_Theory();
            case 17: return new SceneConfig_Sum_Operation_Exercise();
            case 18: return new SceneCongig_VarSum_Theory();
            case 19: return new SceneConfig_VarSum_Exercise();
            case 20: return new SceneCongig_SameVarSum_Theory();
            case 21: return new SceneConfig_SameVarSum_Exercise();
            case 22: return new SceneConfig_SameVarSum_Exercise2();
            case 23: return new SceneConfig_OtherOperations_Theory();
            case 24: return new SceneConfig_OtherOperations_Exercise1();
            case 25: return new SceneConfig_OtherOperations_Exercise2();
            case 26: return new SceneConfig_OtherOperations_Exercise3();
            case 27: return new SceneConfig_OtherOperations_Exercise4();
            case 28: return new SceneConfig_ModOperation_Theory();
            case 29: return new SceneConfig_ModOperation_Exercise1();
            case 30: return new SceneConfig_ModOperation_Exercise2();
            case 31: return new SceneConfig_ModOperation_Exercise3();
            case 32: return new SceneConfig_Operations_Problem_Formulation();
            case 33: return new SceneConfig_Operations_Problem();
            case 34: return new SceneConfig_Game_End();
            case 35: return new SceneConfig_Sample(); 
            case 36: return new SceneConfig_Test();

            default:
                throw new Exception($"No config defined for scene '{sceneIndex}'");
        }
    }

    
}