using System.Reflection;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Utilites.Helpers;

public class TestDataHelper
{
    public static Project GetTestProject(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
                                    + Path.DirectorySeparatorChar + FileName);
        return JsonHelper.FromJson(json).ToObject<Project>();
    }

    public static Case GetTestCase(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + FileName);
        return JsonHelper.FromJson(json).ToObject<Case>();
    }
}