namespace DojoSurveyWithModel.Models;

public class Survey
{
    public string Name {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    public string Location {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    public string Language {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    public int Number {get;set;} 
    public string Meal {get;set;} = null!; // Null-forgiving operator to suppress warning when we want a field to NOT be null
    public DateOnly Date {get;set;}
    public List<string> Days {get; set;} = new List<string>(); // With lists, you must instantiate an empty object like this!
    public string? Comment {get;set;} // Here the "?" means that we allow this to possibly be null

}