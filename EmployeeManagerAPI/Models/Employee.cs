using Newtonsoft.Json;

namespace EmployeeManagerAPI.Models;

//public class Employee
//{
//    public int Id { get; set; }
//    public string? Name { get; set; }
//    public string? Department { get; set; }
//    public string? SubDepartment { get; set; }
//    public string? Manager { get; set; }
//    public string? ProjectName { get; set; }
//    public bool EngagedForClient { get; set; }
//    public bool OnBench { get; set; }
//    public bool OnPip { get; set; }
//    public bool IsBillable { get; set; }
//    public string? SkillSet { get; set; }
//    public string? Certification { get; set; }
//    public int Experience { get; set; }
//    public DateTime CreatedOn { get; set; }
//    public DateTime ModifiedOn { get; set; }
//}

//public class EmployeeResponse
//{
//    [JsonProperty("Name")]
//    public string? Name { get; set; }
//    [JsonProperty("Department")]
//    public string? Department { get; set; }
//    [JsonProperty("Sub Department")]
//    public string? SubDepartment { get; set; }
//    [JsonProperty("Manager")]
//    public string? Manager { get; set; }
//    [JsonProperty("Project Name")]
//    public string? ProjectName { get; set; }
//    [JsonProperty("Engaged For Client")]
//    [JsonConverter(typeof(CustomBooleanConverter))]
//    public bool EngagedForClient { get; set; }
//    [JsonProperty("On Bench")]
//    [JsonConverter(typeof(CustomBooleanConverter))]
//    public bool OnBench { get; set; }
//    [JsonProperty("On PIP")]
//    [JsonConverter(typeof(CustomBooleanConverter))]
//    public bool OnPip { get; set; }
//    [JsonProperty("Is Billable")]
//    [JsonConverter(typeof(CustomBooleanConverter))]
//    public bool IsBillable { get; set; }
//    [JsonProperty("SkillSet")]
//    public string? SkillSet { get; set; }
//    [JsonProperty("Certification")]
//    public string? Certification { get; set; }
//    [JsonProperty("Experience")]
//    public int Experience { get; set; }
//}

public class Employee
{
    public int Id { get; set; }
    [JsonProperty("Name")]
    public string? Name { get; set; }
    [JsonProperty("Department")]
    public string? Department { get; set; }
    [JsonProperty("Sub Department")]
    public string? SubDepartment { get; set; }
    [JsonProperty("Manager")]
    public string? Manager { get; set; }
    [JsonProperty("Project Name")]
    public string? ProjectName { get; set; }
    [JsonProperty("Engaged For Client")]
    [JsonConverter(typeof(CustomBooleanConverter))]
    public bool EngagedForClient { get; set; }
    [JsonProperty("On Bench")]
    [JsonConverter(typeof(CustomBooleanConverter))]
    public bool OnBench { get; set; }
    [JsonProperty("On PIP")]
    [JsonConverter(typeof(CustomBooleanConverter))]
    public bool OnPip { get; set; }
    [JsonProperty("Is Billable")]
    [JsonConverter(typeof(CustomBooleanConverter))]
    public bool IsBillable { get; set; }
    [JsonProperty("SkillSet")]
    public string? SkillSet { get; set; }
    [JsonProperty("Certification")]
    public string? Certification { get; set; }
    [JsonProperty("Experience")]
    public int Experience { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}