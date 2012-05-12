public class Product
{
    public string Course_id { get; set; }
    public string aGUID { get; set; }
    public string assignmentNumber { get; set; }
    public int Num_Assignment { get; set; }

    //default constructor
    public Product() { }

    //Copy constructor
      public Product(string inCourse_id, string inaGUID, string inAssignmentNumber, int inNum_Assignments)
    {
        this.Course_id = inCourse_id;
        this.aGUID = inaGUID;
        this.assignmentNumber = inAssignmentNumber;
        this.Num_Assignment = inNum_Assignments;
    }
}