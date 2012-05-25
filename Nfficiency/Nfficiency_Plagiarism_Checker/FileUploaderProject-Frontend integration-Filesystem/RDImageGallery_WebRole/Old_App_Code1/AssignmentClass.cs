public class AssignmentClass
{
    public string Course_id { get; set; }
    public string aGUID { get; set; }
    public string assignmentNumber { get; set; }
    public int Num_Assignment { get; set; }
    public string descripton { get; set; }

    //default constructor
    public AssignmentClass() { }

    //Copy constructor
      public AssignmentClass(string inCourse_id, string inaGUID, string inAssignmentNumber, int inNum_Assignments, string inDescription)
    {
        this.Course_id = inCourse_id;
        this.aGUID = inaGUID;
        this.assignmentNumber = inAssignmentNumber;
        this.Num_Assignment = inNum_Assignments;
        this.descripton = inDescription;
    }
}